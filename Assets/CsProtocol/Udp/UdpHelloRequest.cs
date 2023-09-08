using System;
using System.Collections.Generic;
using CsProtocol.Buffer;

namespace CsProtocol
{
    
    public class UdpHelloRequest : IProtocol
    {
        public string message;

        public static UdpHelloRequest ValueOf(string message)
        {
            var packet = new UdpHelloRequest();
            packet.message = message;
            return packet;
        }


        public short ProtocolId()
        {
            return 1200;
        }
    }


    public class UdpHelloRequestRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 1200;
        }

        public void Write(ByteBuffer buffer, IProtocol packet)
        {
            if (buffer.WritePacketFlag(packet))
            {
                return;
            }
            UdpHelloRequest message = (UdpHelloRequest) packet;
            buffer.WriteString(message.message);
        }

        public IProtocol Read(ByteBuffer buffer)
        {
            if (!buffer.ReadBool())
            {
                return null;
            }
            UdpHelloRequest packet = new UdpHelloRequest();
            string result0 = buffer.ReadString();
            packet.message = result0;
            return packet;
        }
    }
}
