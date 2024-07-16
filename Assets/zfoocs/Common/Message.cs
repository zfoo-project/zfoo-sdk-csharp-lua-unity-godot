using System;
using System.Collections.Generic;
namespace zfoocs
{
    
    public class Message
    {
        public int code;
        public string message;
    }

    public class MessageRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 100;
        }
    
        public void Write(ByteBuffer buffer, object packet)
        {
            if (packet == null)
            {
                buffer.WriteInt(0);
                return;
            }
            Message message = (Message) packet;
            buffer.WriteInt(-1);
            buffer.WriteInt(message.code);
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
            Message packet = new Message();
            int result0 = buffer.ReadInt();
            packet.code = result0;
            string result1 = buffer.ReadString();
            packet.message = result1;
            if (length > 0)
            {
                buffer.SetReadOffset(beforeReadIndex + length);
            }
            return packet;
        }
    }
}