using System;
using System.Collections.Generic;

namespace zfoocs
{
    
    public class PairLS
    {
        public long key;
        public string value;

        public static PairLS ValueOf(long key, string value)
        {
            var packet = new PairLS();
            packet.key = key;
            packet.value = value;
            return packet;
        }
    }


    public class PairLSRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 113;
        }

        public void Write(ByteBuffer buffer, object packet)
        {
            if (packet == null)
            {
                buffer.WriteInt(0);
                return;
            }
            PairLS message = (PairLS) packet;
            buffer.WriteInt(-1);
            buffer.WriteLong(message.key);
            buffer.WriteString(message.value);
        }

        public object Read(ByteBuffer buffer)
        {
            int length = buffer.ReadInt();
            if (length == 0)
            {
                return null;
            }
            int beforeReadIndex = buffer.ReadOffset();
            PairLS packet = new PairLS();
            long result0 = buffer.ReadLong();
            packet.key = result0;
            string result1 = buffer.ReadString();
            packet.value = result1;
            if (length > 0) {
                buffer.SetReadOffset(beforeReadIndex + length);
            }
            return packet;
        }
    }
}
