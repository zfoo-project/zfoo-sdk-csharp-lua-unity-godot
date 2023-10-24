using System;
using System.Collections.Generic;

namespace zfoocs
{
    
    public class Ping
    {
        

        public static Ping ValueOf()
        {
            var packet = new Ping();
            
            return packet;
        }
    }


    public class PingRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 103;
        }

        public void Write(ByteBuffer buffer, object packet)
        {
            if (packet == null)
            {
                buffer.WriteInt(0);
                return;
            }
            Ping message = (Ping) packet;
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
            Ping packet = new Ping();
            
            if (length > 0) {
                buffer.SetReadOffset(beforeReadIndex + length);
            }
            return packet;
        }
    }
}
