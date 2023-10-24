using System;
using System.Collections.Generic;

namespace zfoocs
{
    
    public class WebsocketHelloRequest
    {
        public string message;

        public static WebsocketHelloRequest ValueOf(string message)
        {
            var packet = new WebsocketHelloRequest();
            packet.message = message;
            return packet;
        }
    }


    public class WebsocketHelloRequestRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 1400;
        }

        public void Write(ByteBuffer buffer, object packet)
        {
            if (packet == null)
            {
                buffer.WriteInt(0);
                return;
            }
            WebsocketHelloRequest message = (WebsocketHelloRequest) packet;
            buffer.WriteInt(-1);
            buffer.WriteString(message.message);
        }

        public object Read(ByteBuffer buffer)
        {
            int length = buffer.ReadInt();
            if (length == 0)
            {
                return null;
            }
            int beforeReadIndex = buffer.ReadOffset();
            WebsocketHelloRequest packet = new WebsocketHelloRequest();
            string result0 = buffer.ReadString();
            packet.message = result0;
            if (length > 0) {
                buffer.SetReadOffset(beforeReadIndex + length);
            }
            return packet;
        }
    }
}
