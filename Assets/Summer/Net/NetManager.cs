using System.Collections.Generic;
using System.Threading.Tasks;
using CsProtocol;
using CsProtocol.Buffer;
using Spring.Core;
using Spring.Event;
using Spring.Util;
using Summer.Base.Model;
using Summer.Net.Core;
using Summer.Net.Core.Model;
using Summer.Net.Core.Tcp;
using Summer.Net.Dispatcher;
using UnityEngine;
using Message = Summer.Net.Core.Message;

namespace Summer.Net
{
    [Bean]
    public class NetManager : AbstractManager, INetManager
    {
        public static readonly int PROTOCOL_HEAD_LENGTH = 4;

        private AbstractClient netClient;

        public override void Update(float elapseSeconds, float realElapseSeconds)
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
                        EventBus.SyncSubmit(NetOpenEvent.ValueOf());
                        break;
                    case MessageType.Data:
                        // Debug.Log("Data: " + JsonUtils.object2String(message.packet));
                        if (message.attachment == null)
                        {
                            PacketDispatcher.Receive(message.packet);
                        }
                        else
                        {
                            completeTask(message.packet, (SignalOnlyAttachment)message.attachment);
                        }
                        break;
                    case MessageType.Disconnected:
                        Debug.Log("Disconnected");
                        EventBus.AsyncSubmit(NetErrorEvent.ValueOf());
                        break;
                }
            }
        }

        public override void Shutdown()
        {
            Close();
        }

        public void Connect(string url)
        {
            Close();

            Debug.Log("开始连接服务器 url:" + url);
#if UNITY_WEBGL && !UNITY_EDITOR
            netClient = new Summer.Net.Core.Websocket.WebsocketClient(url);
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
            }

            EventBus.SyncSubmit(NetCloseEvent.ValueOf());
        }


        public void Send(IProtocol packet, IProtocol attachment)
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
                    Close();
                    EventBus.AsyncSubmit(NetErrorEvent.ValueOf());
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

        public void Send(IProtocol packet)
        {
            Send(packet, null);
        }
        

        // zfoo的await方法实现
        public static int signalId = 0;

        public static Dictionary<int, EncodedPacketInfo> taskMap = new Dictionary<int, EncodedPacketInfo>();

        public Task<IProtocol> asyncAsk(IProtocol packet)
        {
            // 创建一个TaskCompletionSource对象
            TaskCompletionSource<IProtocol> tcs = new TaskCompletionSource<IProtocol>();
            SignalOnlyAttachment attachment = new SignalOnlyAttachment();
            lock (taskMap)
            {
                signalId++;
                attachment.signalId = signalId;
                var currentTime = TimeUtils.CurrentTimeMillis();
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
                    if (value != null && (currentTime - value.attachment.timestamp > 5000)) {
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

        public void completeTask(IProtocol packet, SignalOnlyAttachment attachment)
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