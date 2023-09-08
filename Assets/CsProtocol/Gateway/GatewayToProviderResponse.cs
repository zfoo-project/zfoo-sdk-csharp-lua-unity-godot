using System;
using System.Collections.Generic;
using CsProtocol.Buffer;

namespace CsProtocol
{
    
    public class GatewayToProviderResponse : IProtocol
    {
        public string message;

        public static GatewayToProviderResponse ValueOf(string message)
        {
            var packet = new GatewayToProviderResponse();
            packet.message = message;
            return packet;
        }


        public short ProtocolId()
        {
            return 5001;
        }
    }


    public class GatewayToProviderResponseRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 5001;
        }

        public void Write(ByteBuffer buffer, IProtocol packet)
        {
            if (buffer.WritePacketFlag(packet))
            {
                return;
            }
            GatewayToProviderResponse message = (GatewayToProviderResponse) packet;
            buffer.WriteString(message.message);
        }

        public IProtocol Read(ByteBuffer buffer)
        {
            if (!buffer.ReadBool())
            {
                return null;
            }
            GatewayToProviderResponse packet = new GatewayToProviderResponse();
            string result0 = buffer.ReadString();
            packet.message = result0;
            return packet;
        }
    }
}
