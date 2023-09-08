using System;
using System.Collections.Generic;
using CsProtocol.Buffer;

namespace CsProtocol
{
    
    public class TripleLong : IProtocol
    {
        public long left;
        public long middle;
        public long right;

        public static TripleLong ValueOf(long left, long middle, long right)
        {
            var packet = new TripleLong();
            packet.left = left;
            packet.middle = middle;
            packet.right = right;
            return packet;
        }


        public short ProtocolId()
        {
            return 114;
        }
    }


    public class TripleLongRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 114;
        }

        public void Write(ByteBuffer buffer, IProtocol packet)
        {
            if (buffer.WritePacketFlag(packet))
            {
                return;
            }
            TripleLong message = (TripleLong) packet;
            buffer.WriteLong(message.left);
            buffer.WriteLong(message.middle);
            buffer.WriteLong(message.right);
        }

        public IProtocol Read(ByteBuffer buffer)
        {
            if (!buffer.ReadBool())
            {
                return null;
            }
            TripleLong packet = new TripleLong();
            long result0 = buffer.ReadLong();
            packet.left = result0;
            long result1 = buffer.ReadLong();
            packet.middle = result1;
            long result2 = buffer.ReadLong();
            packet.right = result2;
            return packet;
        }
    }
}
