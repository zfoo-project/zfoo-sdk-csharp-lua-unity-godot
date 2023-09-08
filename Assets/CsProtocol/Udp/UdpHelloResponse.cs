using System;
using System.Collections.Generic;
using CsProtocol.Buffer;

namespace CsProtocol
{
    
    public class UdpHelloResponse : IProtocol
    {
        public string message;

        public static UdpHelloResponse ValueOf(string message)
        {
            var packet = new UdpHelloResponse();
            packet.message = message;
            return packet;
        }


        public short ProtocolId()
        {
            return 1201;
        }
    }


    public class UdpHelloResponseRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 1201;
        }

        public void Write(ByteBuffer buffer, IProtocol packet)
        {
            if (buffer.WritePacketFlag(packet))
            {
                return;
            }
            UdpHelloResponse message = (UdpHelloResponse) packet;
            buffer.WriteString(message.message);
        }

        public IProtocol Read(ByteBuffer buffer)
        {
            if (!buffer.ReadBool())
            {
                return null;
            }
            UdpHelloResponse packet = new UdpHelloResponse();
            string result0 = buffer.ReadString();
            packet.message = result0;
            return packet;
        }
    }
}
