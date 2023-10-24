using System;
using System.Collections.Generic;

namespace zfoocs
{
    
    public class GatewayToProviderRequest
    {
        public string message;

        public static GatewayToProviderRequest ValueOf(string message)
        {
            var packet = new GatewayToProviderRequest();
            packet.message = message;
            return packet;
        }
    }


    public class GatewayToProviderRequestRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 5000;
        }

        public void Write(ByteBuffer buffer, object packet)
        {
            if (packet == null)
            {
                buffer.WriteInt(0);
                return;
            }
            GatewayToProviderRequest message = (GatewayToProviderRequest) packet;
            buffer.WriteInt(-1);
            buffer.WriteString(message.message);
        }

        public object Read(ByteBuffer buffer)
        {
            int length = buffer.ReadInt();
            if (length == 0)
            {
                return null;
            }
            int beforeReadIndex = buffer.ReadOffset();
            GatewayToProviderRequest packet = new GatewayToProviderRequest();
            string result0 = buffer.ReadString();
            packet.message = result0;
            if (length > 0) {
                buffer.SetReadOffset(beforeReadIndex + length);
            }
            return packet;
        }
    }
}
