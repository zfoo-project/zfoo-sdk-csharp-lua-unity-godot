using System;
using System.Collections.Generic;

namespace zfoocs
{
    
    public class Heartbeat
    {
        

        public static Heartbeat ValueOf()
        {
            var packet = new Heartbeat();
            
            return packet;
        }
    }


    public class HeartbeatRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 102;
        }

        public void Write(ByteBuffer buffer, object packet)
        {
            if (packet == null)
            {
                buffer.WriteInt(0);
                return;
            }
            Heartbeat message = (Heartbeat) packet;
            buffer.WriteInt(-1);
        }

        public object Read(ByteBuffer buffer)
        {
            int length = buffer.ReadInt();
            if (length == 0)
            {
                return null;
            }
            int beforeReadIndex = buffer.ReadOffset();
            Heartbeat packet = new Heartbeat();
            
            if (length > 0) {
                buffer.SetReadOffset(beforeReadIndex + length);
            }
            return packet;
        }
    }
}
