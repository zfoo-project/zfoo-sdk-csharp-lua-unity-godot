using System;
using System.Collections.Generic;
using CsProtocol.Buffer;

namespace CsProtocol
{
    
    public class WebsocketHelloRequest : IProtocol
    {
        public string message;

        public static WebsocketHelloRequest ValueOf(string message)
        {
            var packet = new WebsocketHelloRequest();
            packet.message = message;
            return packet;
        }


        public short ProtocolId()
        {
            return 1400;
        }
    }


    public class WebsocketHelloRequestRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 1400;
        }

        public void Write(ByteBuffer buffer, IProtocol packet)
        {
            if (buffer.WritePacketFlag(packet))
            {
                return;
            }
            WebsocketHelloRequest message = (WebsocketHelloRequest) packet;
            buffer.WriteString(message.message);
        }

        public IProtocol Read(ByteBuffer buffer)
        {
            if (!buffer.ReadBool())
            {
                return null;
            }
            WebsocketHelloRequest packet = new WebsocketHelloRequest();
            string result0 = buffer.ReadString();
            packet.message = result0;
            return packet;
        }
    }
}
