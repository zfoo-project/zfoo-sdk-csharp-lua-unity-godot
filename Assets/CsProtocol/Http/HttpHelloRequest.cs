using System;
using System.Collections.Generic;
using CsProtocol.Buffer;

namespace CsProtocol
{
    
    public class HttpHelloRequest : IProtocol
    {
        public string message;

        public static HttpHelloRequest ValueOf(string message)
        {
            var packet = new HttpHelloRequest();
            packet.message = message;
            return packet;
        }


        public short ProtocolId()
        {
            return 1700;
        }
    }


    public class HttpHelloRequestRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 1700;
        }

        public void Write(ByteBuffer buffer, IProtocol packet)
        {
            if (buffer.WritePacketFlag(packet))
            {
                return;
            }
            HttpHelloRequest message = (HttpHelloRequest) packet;
            buffer.WriteString(message.message);
        }

        public IProtocol Read(ByteBuffer buffer)
        {
            if (!buffer.ReadBool())
            {
                return null;
            }
            HttpHelloRequest packet = new HttpHelloRequest();
            string result0 = buffer.ReadString();
            packet.message = result0;
            return packet;
        }
    }
}
