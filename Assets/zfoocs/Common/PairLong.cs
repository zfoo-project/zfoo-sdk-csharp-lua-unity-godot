using System;
using System.Collections.Generic;
namespace zfoocs
{
    
    public class PairLong
    {
        public long key;
        public long value;
    }

    public class PairLongRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 111;
        }
    
        public void Write(ByteBuffer buffer, object packet)
        {
            if (packet == null)
            {
                buffer.WriteInt(0);
                return;
            }
            PairLong message = (PairLong) packet;
            buffer.WriteInt(-1);
            buffer.WriteLong(message.key);
            buffer.WriteLong(message.value);
        }
    
        public object Read(ByteBuffer buffer)
        {
            int length = buffer.ReadInt();
            if (length == 0)
            {
                return null;
            }
            int beforeReadIndex = buffer.GetReadOffset();
            PairLong packet = new PairLong();
            long result0 = buffer.ReadLong();
            packet.key = result0;
            long result1 = buffer.ReadLong();
            packet.value = result1;
            if (length > 0)
            {
                buffer.SetReadOffset(beforeReadIndex + length);
            }
            return packet;
        }
    }
}