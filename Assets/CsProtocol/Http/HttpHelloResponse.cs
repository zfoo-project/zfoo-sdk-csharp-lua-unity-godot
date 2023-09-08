using System;
using System.Collections.Generic;
using CsProtocol.Buffer;

namespace CsProtocol
{
    
    public class HttpHelloResponse : IProtocol
    {
        public string message;

        public static HttpHelloResponse ValueOf(string message)
        {
            var packet = new HttpHelloResponse();
            packet.message = message;
            return packet;
        }


        public short ProtocolId()
        {
            return 1701;
        }
    }


    public class HttpHelloResponseRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 1701;
        }

        public void Write(ByteBuffer buffer, IProtocol packet)
        {
            if (buffer.WritePacketFlag(packet))
            {
                return;
            }
            HttpHelloResponse message = (HttpHelloResponse) packet;
            buffer.WriteString(message.message);
        }

        public IProtocol Read(ByteBuffer buffer)
        {
            if (!buffer.ReadBool())
            {
                return null;
            }
            HttpHelloResponse packet = new HttpHelloResponse();
            string result0 = buffer.ReadString();
            packet.message = result0;
            return packet;
        }
    }
}
