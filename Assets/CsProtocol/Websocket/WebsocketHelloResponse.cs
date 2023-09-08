using System;
using System.Collections.Generic;
using CsProtocol.Buffer;

namespace CsProtocol
{
    
    public class WebsocketHelloResponse : IProtocol
    {
        public string message;

        public static WebsocketHelloResponse ValueOf(string message)
        {
            var packet = new WebsocketHelloResponse();
            packet.message = message;
            return packet;
        }


        public short ProtocolId()
        {
            return 1401;
        }
    }


    public class WebsocketHelloResponseRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 1401;
        }

        public void Write(ByteBuffer buffer, IProtocol packet)
        {
            if (buffer.WritePacketFlag(packet))
            {
                return;
            }
            WebsocketHelloResponse message = (WebsocketHelloResponse) packet;
            buffer.WriteString(message.message);
        }

        public IProtocol Read(ByteBuffer buffer)
        {
            if (!buffer.ReadBool())
            {
                return null;
            }
            WebsocketHelloResponse packet = new WebsocketHelloResponse();
            string result0 = buffer.ReadString();
            packet.message = result0;
            return packet;
        }
    }
}
