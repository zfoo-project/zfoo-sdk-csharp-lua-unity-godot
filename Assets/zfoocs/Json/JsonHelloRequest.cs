using System;
using System.Collections.Generic;

namespace zfoocs
{
    
    public class JsonHelloRequest
    {
        public string message;

        public static JsonHelloRequest ValueOf(string message)
        {
            var packet = new JsonHelloRequest();
            packet.message = message;
            return packet;
        }
    }


    public class JsonHelloRequestRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 1600;
        }

        public void Write(ByteBuffer buffer, object packet)
        {
            if (packet == null)
            {
                buffer.WriteInt(0);
                return;
            }
            JsonHelloRequest message = (JsonHelloRequest) packet;
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
            JsonHelloRequest packet = new JsonHelloRequest();
            string result0 = buffer.ReadString();
            packet.message = result0;
            if (length > 0) {
                buffer.SetReadOffset(beforeReadIndex + length);
            }
            return packet;
        }
    }
}
