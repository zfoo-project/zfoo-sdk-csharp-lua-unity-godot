using System;
using System.Collections.Generic;
namespace zfoocs
{
    
    public class TripleLong
    {
        public long left;
        public long middle;
        public long right;
    }

    public class TripleLongRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 114;
        }
    
        public void Write(ByteBuffer buffer, object packet)
        {
            if (packet == null)
            {
                buffer.WriteInt(0);
                return;
            }
            TripleLong message = (TripleLong) packet;
            buffer.WriteInt(-1);
            buffer.WriteLong(message.left);
            buffer.WriteLong(message.middle);
            buffer.WriteLong(message.right);
        }
    
        public object Read(ByteBuffer buffer)
        {
            int length = buffer.ReadInt();
            if (length == 0)
            {
                return null;
            }
            int beforeReadIndex = buffer.GetReadOffset();
            TripleLong packet = new TripleLong();
            long result0 = buffer.ReadLong();
            packet.left = result0;
            long result1 = buffer.ReadLong();
            packet.middle = result1;
            long result2 = buffer.ReadLong();
            packet.right = result2;
            if (length > 0)
            {
                buffer.SetReadOffset(beforeReadIndex + length);
            }
            return packet;
        }
    }
}