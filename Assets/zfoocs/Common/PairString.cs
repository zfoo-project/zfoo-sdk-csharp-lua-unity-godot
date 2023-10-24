using System;
using System.Collections.Generic;

namespace zfoocs
{
    
    public class PairString
    {
        public string key;
        public string value;

        public static PairString ValueOf(string key, string value)
        {
            var packet = new PairString();
            packet.key = key;
            packet.value = value;
            return packet;
        }
    }


    public class PairStringRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 112;
        }

        public void Write(ByteBuffer buffer, object packet)
        {
            if (packet == null)
            {
                buffer.WriteInt(0);
                return;
            }
            PairString message = (PairString) packet;
            buffer.WriteInt(-1);
            buffer.WriteString(message.key);
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
            PairString packet = new PairString();
            string result0 = buffer.ReadString();
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
