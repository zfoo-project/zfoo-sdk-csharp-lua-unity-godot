using System;
using System.Collections.Generic;

namespace zfoocs
{
    
    public class GatewayToProviderResponse
    {
        public string message;

        public static GatewayToProviderResponse ValueOf(string message)
        {
            var packet = new GatewayToProviderResponse();
            packet.message = message;
            return packet;
        }
    }


    public class GatewayToProviderResponseRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 5001;
        }

        public void Write(ByteBuffer buffer, object packet)
        {
            if (packet == null)
            {
                buffer.WriteInt(0);
                return;
            }
            GatewayToProviderResponse message = (GatewayToProviderResponse) packet;
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
            GatewayToProviderResponse packet = new GatewayToProviderResponse();
            string result0 = buffer.ReadString();
            packet.message = result0;
            if (length > 0) {
                buffer.SetReadOffset(beforeReadIndex + length);
            }
            return packet;
        }
    }
}
