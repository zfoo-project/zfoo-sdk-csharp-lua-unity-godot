using System;
using System.Collections.Generic;

namespace zfoocs
{
    
    public class TripleLSS
    {
        public long left;
        public string middle;
        public string right;

        public static TripleLSS ValueOf(long left, string middle, string right)
        {
            var packet = new TripleLSS();
            packet.left = left;
            packet.middle = middle;
            packet.right = right;
            return packet;
        }
    }


    public class TripleLSSRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 116;
        }

        public void Write(ByteBuffer buffer, object packet)
        {
            if (packet == null)
            {
                buffer.WriteInt(0);
                return;
            }
            TripleLSS message = (TripleLSS) packet;
            buffer.WriteInt(-1);
            buffer.WriteLong(message.left);
            buffer.WriteString(message.middle);
            buffer.WriteString(message.right);
        }

        public object Read(ByteBuffer buffer)
        {
            int length = buffer.ReadInt();
            if (length == 0)
            {
                return null;
            }
            int beforeReadIndex = buffer.ReadOffset();
            TripleLSS packet = new TripleLSS();
            long result0 = buffer.ReadLong();
            packet.left = result0;
            string result1 = buffer.ReadString();
            packet.middle = result1;
            string result2 = buffer.ReadString();
            packet.right = result2;
            if (length > 0) {
                buffer.SetReadOffset(beforeReadIndex + length);
            }
            return packet;
        }
    }
}
