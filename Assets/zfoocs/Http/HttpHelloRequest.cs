using System;
using System.Collections.Generic;

namespace zfoocs
{
    
    public class HttpHelloRequest
    {
        public string message;

        public static HttpHelloRequest ValueOf(string message)
        {
            var packet = new HttpHelloRequest();
            packet.message = message;
            return packet;
        }
    }


    public class HttpHelloRequestRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 1700;
        }

        public void Write(ByteBuffer buffer, object packet)
        {
            if (packet == null)
            {
                buffer.WriteInt(0);
                return;
            }
            HttpHelloRequest message = (HttpHelloRequest) packet;
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
            HttpHelloRequest packet = new HttpHelloRequest();
            string result0 = buffer.ReadString();
            packet.message = result0;
            if (length > 0) {
                buffer.SetReadOffset(beforeReadIndex + length);
            }
            return packet;
        }
    }
}
