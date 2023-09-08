using System;
using System.Collections.Generic;
using CsProtocol.Buffer;

namespace CsProtocol
{
    
    public class PairIntLong : IProtocol
    {
        public int key;
        public long value;

        public static PairIntLong ValueOf(int key, long value)
        {
            var packet = new PairIntLong();
            packet.key = key;
            packet.value = value;
            return packet;
        }


        public short ProtocolId()
        {
            return 110;
        }
    }


    public class PairIntLongRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 110;
        }

        public void Write(ByteBuffer buffer, IProtocol packet)
        {
            if (buffer.WritePacketFlag(packet))
            {
                return;
            }
            PairIntLong message = (PairIntLong) packet;
            buffer.WriteInt(message.key);
            buffer.WriteLong(message.value);
        }

        public IProtocol Read(ByteBuffer buffer)
        {
            if (!buffer.ReadBool())
            {
                return null;
            }
            PairIntLong packet = new PairIntLong();
            int result0 = buffer.ReadInt();
            packet.key = result0;
            long result1 = buffer.ReadLong();
            packet.value = result1;
            return packet;
        }
    }
}
