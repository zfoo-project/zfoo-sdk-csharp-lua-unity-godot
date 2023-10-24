using System;
using System.Collections.Generic;

namespace zfoocs
{
    
    public class Pong
    {
        public long time;

        public static Pong ValueOf(long time)
        {
            var packet = new Pong();
            packet.time = time;
            return packet;
        }
    }


    public class PongRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 104;
        }

        public void Write(ByteBuffer buffer, object packet)
        {
            if (packet == null)
            {
                buffer.WriteInt(0);
                return;
            }
            Pong message = (Pong) packet;
            buffer.WriteInt(-1);
            buffer.WriteLong(message.time);
        }

        public object Read(ByteBuffer buffer)
        {
            int length = buffer.ReadInt();
            if (length == 0)
            {
                return null;
            }
            int beforeReadIndex = buffer.ReadOffset();
            Pong packet = new Pong();
            long result0 = buffer.ReadLong();
            packet.time = result0;
            if (length > 0) {
                buffer.SetReadOffset(beforeReadIndex + length);
            }
            return packet;
        }
    }
}
