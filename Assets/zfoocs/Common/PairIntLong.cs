using System;
using System.Collections.Generic;
namespace zfoocs
{
    
    public class PairIntLong
    {
        public int key;
        public long value;
    }

    public class PairIntLongRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 110;
        }
    
        public void Write(ByteBuffer buffer, object packet)
        {
            if (packet == null)
            {
                buffer.WriteInt(0);
                return;
            }
            PairIntLong message = (PairIntLong) packet;
            buffer.WriteInt(-1);
            buffer.WriteInt(message.key);
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
            PairIntLong packet = new PairIntLong();
            int result0 = buffer.ReadInt();
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