using System;
using System.Collections.Generic;
using CsProtocol.Buffer;

namespace CsProtocol
{
    
    public class GatewayToProviderRequest : IProtocol
    {
        public string message;

        public static GatewayToProviderRequest ValueOf(string message)
        {
            var packet = new GatewayToProviderRequest();
            packet.message = message;
            return packet;
        }


        public short ProtocolId()
        {
            return 5000;
        }
    }


    public class GatewayToProviderRequestRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 5000;
        }

        public void Write(ByteBuffer buffer, IProtocol packet)
        {
            if (buffer.WritePacketFlag(packet))
            {
                return;
            }
            GatewayToProviderRequest message = (GatewayToProviderRequest) packet;
            buffer.WriteString(message.message);
        }

        public IProtocol Read(ByteBuffer buffer)
        {
            if (!buffer.ReadBool())
            {
                return null;
            }
            GatewayToProviderRequest packet = new GatewayToProviderRequest();
            string result0 = buffer.ReadString();
            packet.message = result0;
            return packet;
        }
    }
}
