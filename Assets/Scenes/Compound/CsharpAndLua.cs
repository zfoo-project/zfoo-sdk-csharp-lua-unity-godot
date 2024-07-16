using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using XLua;
using zfoocs;

namespace zfoo
{
    public delegate void OnMessage(object packet);

    public delegate void OnOpen();

    public delegate void OnNetClose();

    public delegate void OnNetError();

    public class CsharpAndLua : MonoBehaviour
    {
        public static AbstractClient netClient;

        // Csharp
        public static OnMessage _c_message;
        public static OnOpen _c_open;
        public static OnNetClose _c_close;
        public static OnNetError _c_error;

        public async void sendPackTest()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                // 发送一个消息
                var request = new WebsocketHelloRequest();
                request.message = "这个是普通发送的消息";
                Send(request);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                // 使用await语法发送一个消息
                var myRequest = new WebsocketHelloRequest();
                myRequest.message = "这个是使用await语法发送的消息";
                var response = await asyncAsk(myRequest) as WebsocketHelloResponse;
                Debug.Log(JsonUtility.ToJson(response));
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                _luaEnv.Global.Get<LuaFunction>("sendTest").Call();
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                _luaEnv.Global.Get<LuaFunction>("asyncAskTest").Call();
            }
        }

        private void Start()
        {
            Debug.Log("start net init");

            initLua();
            initCsharp();

            // 连接服务器
            Connect("127.0.0.1:9000");
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


        // ----------------------------------------------Lua--------------------------------------------------------
        // Lua
        private LuaEnv _luaEnv;
        public static Action<byte[]> _lua_message;
        public static Action _lua_open;
        public static Action _lua_close;
        public static Action _lua_error;
        
        public TextAsset luaScript;
        public List<TextAsset> luas;
        public static List<TextAsset> myluas;

        private void initLua()
        {
            myluas = luas;
            
            _luaEnv = new LuaEnv();
            _luaEnv.DoString("CS.UnityEngine.Debug.Log('start lua init')");

            // 初始化lua
            var luaDebugBuilder = new StringBuilder();
            // Rider的断点调试
            // luaDebugBuilder.Append("package.cpath = package.cpath .. ';C:/Users/Administrator/AppData/Roaming/JetBrains/Rider2022.3/plugins/EmmyLua/debugger/emmy/windows/x64/?.dll'").Append(System.Environment.NewLine);
            // luaDebugBuilder.Append("local dbg = require('emmy_core')").Append(System.Environment.NewLine);
            // luaDebugBuilder.Append("dbg.tcpConnect('localhost', 9966)").Append(System.Environment.NewLine);

            _luaEnv.DoString(luaDebugBuilder.ToString());

            // 自定义lua加载路径
            _luaEnv.AddLoader(CustomLoader);

            _luaEnv.DoString(luaScript.text, "main");
            _luaEnv.Global.Get("onOpen", out _lua_open);
            _luaEnv.Global.Get("onClose", out _lua_close);
            _luaEnv.Global.Get("onError", out _lua_error);
            _luaEnv.Global.Get("onMessage", out _lua_message);
            _luaEnv.Global.Get<LuaFunction>("initProtocol").Call();
        }
        
        public static byte[] CustomLoader(ref string filepath)
        {
            filepath = filepath.Replace(".", "/") + ".lua.txt";
            foreach (var lua in myluas)
            {
                if (filepath.Contains(lua.name))
                {
                    return lua.bytes;
                }
            }

            Debug.LogError("lua load error  ");
            return null;
        }

        public static void SendInLua(MemoryStream mm, int len)
        {
            byte[] bytes = new byte[len];
            mm.Position = 0;
            mm.Read(bytes, 0, len);

            var sendSuccess = netClient.Send(bytes);
            if (!sendSuccess)
            {
                Debug.Log("send lua message error");
                // do something when net error
                if (_lua_error != null)
                {
                    _lua_error();
                }
            }
        }

        // ----------------------------------------------C#--------------------------------------------------------

        private void initCsharp()
        {
            // 初始化C#协议
            ProtocolManager.InitProtocol();
            // 委托绑定消息接受器
            _c_open += () => Debug.Log("csharp open connection");
            _c_close += () => Debug.Log("csharp close connection event");
            _c_error += () => Debug.Log("csharp error event");
            _c_message += packet => Debug.Log(JsonUtility.ToJson(packet));
        }


        [ThreadStatic] protected static byte[] protocolIdBytes;

        private void Update()
        {
            sendPackTest();

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
                        Open();
                        break;
                    case MessageType.Disconnected:
                        Close();
                        break;
                    case MessageType.Error:
                        Error();
                        break;
                    case MessageType.Data:
                        ProcessMessage(message.buffer);
                        break;
                }
            }
        }


        public void ProcessMessage(byte[] buffer)
        {
            // 解析包的id
            if (protocolIdBytes == null)
            {
                protocolIdBytes = new byte[2];
            }

            protocolIdBytes[0] = buffer[0];
            protocolIdBytes[1] = buffer[1];
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(protocolIdBytes);
            }

            var protocolId = BitConverter.ToInt16(protocolIdBytes, 0);

            // 这边判断哪些协议要在C#处理，哪些协议要在Lua中处理
            if (protocolId == 1401)
            {
                csharpMessage(buffer);
            }
            else
            {
                _lua_message(buffer);
            }
        }

        public void Open()
        {
            Debug.Log("Connected server " + netClient.ToConnectUrl());
            // do something when connected server
            if (_c_open != null)
            {
                _c_open();
            }

            if (_lua_open != null)
            {
                _lua_open();
            }
        }

        public void Close()
        {
            Debug.Log("Net Disconnected");
            if (netClient != null)
            {
                netClient.Close();
                netClient = null;

                // do something when close
                if (_c_close != null)
                {
                    _c_close();
                }

                if (_lua_close != null)
                {
                    _lua_close();
                }
            }
        }

        public void Error()
        {
            Debug.Log("Net Error");
            // do something when close
            if (_c_error != null)
            {
                _c_error();
            }

            if (_lua_error != null)
            {
                _lua_error();
            }
        }

        public const int PROTOCOL_HEAD_LENGTH = 4;

        public static void Send(object packet, object attachment)
        {
            ByteBuffer byteBuffer = null;
            try
            {
                byteBuffer = ByteBuffer.ValueOf();

                byteBuffer.WriteRawInt(PROTOCOL_HEAD_LENGTH);

                ProtocolManager.Write(byteBuffer, packet);

                // 包的附加包
                if (attachment == null)
                {
                    byteBuffer.WriteBool(false);
                }
                else
                {
                    byteBuffer.WriteBool(true);
                    ProtocolManager.Write(byteBuffer, attachment);
                }

                // 包的长度
                int length = byteBuffer.GetWriteOffset();

                int packetLength = length - PROTOCOL_HEAD_LENGTH;

                byteBuffer.SetWriteOffset(0);
                byteBuffer.WriteRawInt(packetLength);
                byteBuffer.SetWriteOffset(length);

                var sendSuccess = netClient.Send(byteBuffer.ToBytes());
                if (!sendSuccess)
                {
                    Debug.Log("send message error " + packet.GetType());
                    // do something when net error
                    if (_c_error != null)
                    {
                        _c_error();
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

        public static void Send(object packet)
        {
            Send(packet, null);
        }

        private void csharpMessage(byte[] buffer)
        {
            ByteBuffer byteBuffer = null;
            try
            {
                byteBuffer = ByteBuffer.ValueOf();
                byteBuffer.WriteBytes(buffer);
                var packet = ProtocolManager.Read(byteBuffer);
                object attachment = null;
                if (byteBuffer.IsReadable() && byteBuffer.ReadBool())
                {
                    attachment = ProtocolManager.Read(byteBuffer);
                }

                if (attachment == null)
                {
                    // do something when close
                    if (_c_message != null)
                    {
                        _c_message(packet);
                    }
                }
                else
                {
                    completeTask(packet, (SignalAttachment)attachment);
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


        // zfoo的await方法实现
        public static int signalId = 0;

        public static Dictionary<int, EncodedPacketInfo> taskMap = new Dictionary<int, EncodedPacketInfo>();

        public static Task<object> asyncAsk(object packet)
        {
            // 创建一个TaskCompletionSource对象
            TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
            // 0 for the server, 1 for the native argument client, 2 for the native no argument client, 12 for the outside client such as browser, mobile
            SignalAttachment attachment = new SignalAttachment();
            attachment.client = 12;
            attachment.taskExecutorHash = -1;
            lock (taskMap)
            {
                signalId++;
                attachment.signalId = signalId;
                var currentTime = DateTime.UtcNow.Millisecond;
                attachment.timestamp = currentTime;
                var encodedPacketInfo = new EncodedPacketInfo();
                encodedPacketInfo.attachment = attachment;
                encodedPacketInfo.task = tcs;
                taskMap.Add(signalId, encodedPacketInfo);

                // 因为有可能有些超时的包没有返回，这边循环遍历超时的包，超时时间设置为5秒
                List<int> removedAttachments = new List<int>();
                foreach (var element in taskMap)
                {
                    var value = element.Value;
                    if (value != null && (currentTime - value.attachment.timestamp > 5000))
                    {
                        removedAttachments.Add(element.Key);
                    }
                }

                foreach (var id in removedAttachments)
                {
                    taskMap.Remove(id);
                }
            }

            Send(packet, attachment);
            return tcs.Task;
        }

        public void completeTask(object packet, SignalAttachment attachment)
        {
            lock (taskMap)
            {
                var encodedPacketInfo = taskMap[attachment.signalId];
                var task = encodedPacketInfo.task;
                taskMap.Remove(attachment.signalId);
                task.SetResult(packet);
            }
        }
    }
}