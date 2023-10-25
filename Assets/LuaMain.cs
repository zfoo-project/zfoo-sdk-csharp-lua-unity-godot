using System;
using System.IO;
using System.Text;
using UnityEngine;
using XLua;
using zfoo;
using zfoocs;
using Message = zfoo.Message;

// TODO: A heartbeat packet needs to be sent to the server every second, otherwise the server will actively disconnect
// TODO: 需要每秒钟给服务器发个心跳包 Heartbeat，否则服务器会主动断开连接
namespace zfoolua
{
    public class LuaMain : MonoBehaviour
    {
        private static AbstractClient netClient;

        private static OnMessage _message;
        private static OnOpen _open;
        private static OnNetClose _close;
        private static OnNetError _error;

        public delegate void OnMessage(object packet);

        public delegate void OnOpen();

        public delegate void OnNetClose();

        public delegate void OnNetError();


        // -------------------------------------------------------------------------------------------------------------
        // lua
        private LuaEnv _luaEnv;
        public static readonly string TEST_PATH = "Assets/";

        private async void Start()
        {
            // 连接服务器
            Connect("127.0.0.1:9000");

            _luaEnv = new LuaEnv();
            _luaEnv.DoString("CS.UnityEngine.Debug.Log('start lua test')");

            // 初始化lua
            var luaDebugBuilder = new StringBuilder();
            // Rider的断点调试
            // luaDebugBuilder.Append("package.cpath = package.cpath .. ';C:/Users/Administrator/AppData/Roaming/JetBrains/Rider2022.3/plugins/EmmyLua/debugger/emmy/windows/x64/?.dll'").Append(System.Environment.NewLine);
            // luaDebugBuilder.Append("local dbg = require('emmy_core')").Append(System.Environment.NewLine);
            // luaDebugBuilder.Append("dbg.tcpConnect('localhost', 9966)").Append(System.Environment.NewLine);

            _luaEnv.DoString(luaDebugBuilder.ToString());

            _luaEnv.AddLoader(CustomLoader);

            var luaProtocolTestStr = File.ReadAllText("Assets/main.lua");
            _luaEnv.DoString(luaProtocolTestStr, "main");
            _luaEnv.Global.Get<LuaFunction>("initProtocol").Call();
            _luaEnv.Global.Get<LuaFunction>("sendTest").Call();
        }

        public static byte[] CustomLoader(ref string filepath)
        {
            filepath = filepath.Replace(".", "/") + ".lua";

            return File.ReadAllBytes(TEST_PATH + filepath);
        }

        private void Update()
        {
            if (netClient == null)
            {
                return;
            }

            Message message;
            while (netClient.GetNextMessage(out message))
            {
                switch (message.messageType)
                {
                    case MessageType.Connected:
                        Debug.Log("Connected server " + netClient.ToConnectUrl());
                        // do something when connected server
                        if (_open != null)
                        {
                            _open();
                        }

                        break;
                    case MessageType.Data:
                        Debug.Log("lua receiver bytes " + message.buffer.Length);
                        _luaEnv.Global.Get<LuaFunction>("receiver").Call(message.buffer);
                        break;
                    case MessageType.Disconnected:
                        Debug.Log("Disconnected");
                        Close();
                        break;
                }
            }
        }

        public void Connect(string url)
        {
            Debug.Log("开始连接服务器 url:" + url);
#if UNITY_WEBGL && !UNITY_EDITOR
            netClient = new WebsocketClient(url);
#else
            var hostAndPort = HostAndPort.ValueOf(url);
            netClient = new NetTcpClient(hostAndPort.host, hostAndPort.port);
#endif
            netClient.Start();
        }

        public void Close()
        {
            if (netClient != null)
            {
                netClient.Close();
                netClient = null;

                // do something when close
                if (_close != null)
                {
                    _close();
                }
            }
        }


        public const int PROTOCOL_HEAD_LENGTH = 4;

        public static void Send(MemoryStream mm, int len)
        {
            byte[] bytes = new byte[len];
            mm.Position = 0;
            mm.Read(bytes, 0, len);
            
            ByteBuffer byteBuffer = null;
            try
            {
                byteBuffer = ByteBuffer.ValueOf();

                byteBuffer.WriteRawInt(PROTOCOL_HEAD_LENGTH);

                byteBuffer.WriteBytes(bytes);

                byteBuffer.WriteBool(false);

                // 包的长度
                int length = byteBuffer.WriteOffset();

                int packetLength = length - PROTOCOL_HEAD_LENGTH;

                byteBuffer.SetWriteOffset(0);
                byteBuffer.WriteRawInt(packetLength);
                byteBuffer.SetWriteOffset(length);

                var sendSuccess = netClient.Send(byteBuffer.ToBytes());
                if (!sendSuccess)
                {
                    Debug.Log("send lua message error");
                    // do something when net error
                    if (_error != null)
                    {
                        _error();
                    }
                }
            }
            finally
            {
                if (byteBuffer != null)
                {
                    byteBuffer.Clear();
                }
            }
        }
    }
}