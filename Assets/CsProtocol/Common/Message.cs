using System;
using System.Collections.Generic;
using CsProtocol.Buffer;

namespace CsProtocol
{
    
    public class Message : IProtocol
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


        public short ProtocolId()
        {
            return 100;
        }
    }


    public class MessageRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 100;
        }

        public void Write(ByteBuffer buffer, IProtocol packet)
        {
            if (buffer.WritePacketFlag(packet))
            {
                return;
            }
            Message message = (Message) packet;
            buffer.WriteInt(message.code);
            buffer.WriteString(message.message);
            buffer.WriteByte(message.module);
        }

        public IProtocol Read(ByteBuffer buffer)
        {
            if (!buffer.ReadBool())
            {
                return null;
            }
            Message packet = new Message();
            int result0 = buffer.ReadInt();
            packet.code = result0;
            string result1 = buffer.ReadString();
            packet.message = result1;
            byte result2 = buffer.ReadByte();
            packet.module = result2;
            return packet;
        }
    }
}
