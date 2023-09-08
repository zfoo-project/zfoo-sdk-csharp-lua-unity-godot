using System;
using System.Collections.Generic;
using CsProtocol.Buffer;

namespace CsProtocol
{
    
    public class Heartbeat : IProtocol
    {
        

        public static Heartbeat ValueOf()
        {
            var packet = new Heartbeat();
            
            return packet;
        }


        public short ProtocolId()
        {
            return 102;
        }
    }


    public class HeartbeatRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 102;
        }

        public void Write(ByteBuffer buffer, IProtocol packet)
        {
            if (buffer.WritePacketFlag(packet))
            {
                return;
            }
            Heartbeat message = (Heartbeat) packet;
            
        }

        public IProtocol Read(ByteBuffer buffer)
        {
            if (!buffer.ReadBool())
            {
                return null;
            }
            Heartbeat packet = new Heartbeat();
            
            return packet;
        }
    }
}
