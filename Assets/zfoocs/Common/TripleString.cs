using System;
using System.Collections.Generic;

namespace zfoocs
{
    
    public class TripleString
    {
        public string left;
        public string middle;
        public string right;

        public static TripleString ValueOf(string left, string middle, string right)
        {
            var packet = new TripleString();
            packet.left = left;
            packet.middle = middle;
            packet.right = right;
            return packet;
        }
    }


    public class TripleStringRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 115;
        }

        public void Write(ByteBuffer buffer, object packet)
        {
            if (packet == null)
            {
                buffer.WriteInt(0);
                return;
            }
            TripleString message = (TripleString) packet;
            buffer.WriteInt(-1);
            buffer.WriteString(message.left);
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
            TripleString packet = new TripleString();
            string result0 = buffer.ReadString();
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
