using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using zfoo;
using zfoocs;
using Message = zfoo.Message;

// TODO: A heartbeat packet needs to be sent to the server every second, otherwise the server will actively disconnect
// TODO: 需要每秒钟给服务器发个心跳包 Heartbeat，否则服务器会主动断开连接
public class CsharpMain : MonoBehaviour
{
    
    private AbstractClient netClient;

    private OnMessage _message;
    private OnOpen _open;
    private OnNetClose _close;
    private OnNetError _error;
    
    public delegate void OnMessage(object packet);
    
    public delegate void OnOpen();

    public delegate void OnNetClose();

    public delegate void OnNetError();

    private async void Start()
    {
        Debug.Log("start cs test");
        // 初始化协议
        ProtocolManager.InitProtocol();
        
        // 连接服务器
        Connect("127.0.0.1:9000");
        // 委托绑定消息接受器
        _message += packet => Debug.Log(JsonUtility.ToJson(packet));
        
        // 发送一个消息
        var request = new TcpHelloRequest();
        request.message = "这个是普通发送的消息";
        Send(request);
        
        // 使用await语法发送一个消息
        var myRequest = new TcpHelloRequest();
        myRequest.message = "这个是使用await语法发送的消息";
        var response = await asyncAsk(myRequest) as TcpHelloResponse;
        Debug.Log(JsonUtility.ToJson(response));
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
                    // Debug.Log("Data: " + JsonUtils.object2String(message.packet));
                    ByteBuffer byteBuffer = null;
                    try
                    {
                        byteBuffer = ByteBuffer.ValueOf();
                        byteBuffer.WriteBytes(message.buffer);
                        var packet = ProtocolManager.Read(byteBuffer);
                        object attachment = null;
                        if (byteBuffer.IsReadable() && byteBuffer.ReadBool())
                        {
                            attachment = ProtocolManager.Read(byteBuffer);
                        }
                        if (attachment == null)
                        {
                            // do something when close
                            if (_message != null)
                            {
                                _message(packet);
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

    public void Send(object packet, object attachment)
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
            int length = byteBuffer.WriteOffset();

            int packetLength = length - PROTOCOL_HEAD_LENGTH;

            byteBuffer.SetWriteOffset(0);
            byteBuffer.WriteRawInt(packetLength);
            byteBuffer.SetWriteOffset(length);

            var sendSuccess = netClient.Send(byteBuffer.ToBytes());
            if (!sendSuccess)
            {
                Debug.Log("send message error " + packet.GetType());
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

    public void Send(object packet)
    {
        Send(packet, null);
    }


    // zfoo的await方法实现
    public static int signalId = 0;

    public static Dictionary<int, EncodedPacketInfo> taskMap = new Dictionary<int, EncodedPacketInfo>();

    public Task<object> asyncAsk(object packet)
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