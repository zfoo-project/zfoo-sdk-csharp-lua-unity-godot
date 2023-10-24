using System;
using System.Collections.Generic;

namespace zfoocs
{
    
    public class Message
    {
        public byte module;
        public int code;
        public string message;

        public static Message ValueOf(int code, string message, byte module)
        {
            var packet = new Message();
            packet.code = code;
            packet.message = message;
            packet.module = module;
            return packet;
        }
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
            buffer.WriteByte(message.module);
        }

        public object Read(ByteBuffer buffer)
        {
            int length = buffer.ReadInt();
            if (length == 0)
            {
                return null;
            }
            int beforeReadIndex = buffer.ReadOffset();
            Message packet = new Message();
            int result0 = buffer.ReadInt();
            packet.code = result0;
            string result1 = buffer.ReadString();
            packet.message = result1;
            byte result2 = buffer.ReadByte();
            packet.module = result2;
            if (length > 0) {
                buffer.SetReadOffset(beforeReadIndex + length);
            }
            return packet;
        }
    }
}
