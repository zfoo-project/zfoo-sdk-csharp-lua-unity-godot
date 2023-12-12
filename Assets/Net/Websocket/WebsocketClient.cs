#if UNITY_WEBGL && !UNITY_EDITOR
using System;

using zfoocs;

namespace zfoo
{
    public class WebsocketClient : AbstractClient
    {
        private string url;

        public WebsocketClient(string url)
        {
            this.url = url;
        }

        internal void HandleOnOpen()
        {
            receiveQueue.Enqueue(new Message(MessageType.Connected, null));
        }

        internal void HandleOnMessage(byte[] content)
        {
            var byteBuffer = ByteBuffer.ValueOf();
            byteBuffer.WriteBytes(content);
            byteBuffer.ReadRawInt();
            var bytes = byteBuffer.ReadBytes(content.Length - 4);
            // queue it
            receiveQueue.Enqueue(new Message(MessageType.Data, bytes));
        }

        internal void HandleOnClose()
        {
            receiveQueue.Enqueue(new Message(MessageType.Disconnected, null));
        }

        internal void HandleOnError()
        {
            receiveQueue.Enqueue(new Message(MessageType.Error, null));
        }


        public override void Start()
        {
            if (!WebSocketBridge.initialized)
            {
                WebSocketBridge.Initialize();
            }
            WebSocketBridge.WebSocketClose();
            WebSocketBridge.WebSocketConnect(url);
            WebSocketBridge.websocketClient = this;
        }

        public override bool Connected()
        {
            return WebSocketBridge.initialized;
        }

        public override void Close()
        {
            WebSocketBridge.WebSocketClose();
        }

        public override string ToConnectUrl()
        {
            return url;
        }

        public override bool Send(byte[] data)
        {
            WebSocketBridge.WebSocketSend(data, data.Length);
            return true;
        }

        protected override void SendMessagesBlocking(byte[] messages, int offset, int size)
        {
            throw new NotImplementedException();
        }

        protected override bool ReadMessageBlocking(out byte[] content)
        {
            throw new NotImplementedException();
        }
    }
}
#endif