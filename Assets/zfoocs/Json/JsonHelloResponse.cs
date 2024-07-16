using System;
using System.Collections.Generic;
namespace zfoocs
{
    
    public class JsonHelloResponse
    {
        public string message;
    }

    public class JsonHelloResponseRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 1601;
        }
    
        public void Write(ByteBuffer buffer, object packet)
        {
            if (packet == null)
            {
                buffer.WriteInt(0);
                return;
            }
            JsonHelloResponse message = (JsonHelloResponse) packet;
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
            int beforeReadIndex = buffer.GetReadOffset();
            JsonHelloResponse packet = new JsonHelloResponse();
            string result0 = buffer.ReadString();
            packet.message = result0;
            if (length > 0)
            {
                buffer.SetReadOffset(beforeReadIndex + length);
            }
            return packet;
        }
    }
}