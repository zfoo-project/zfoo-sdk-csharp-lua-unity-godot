using System;
using System.Collections.Generic;
using CsProtocol.Buffer;

namespace CsProtocol
{
    
    public class JsonHelloResponse : IProtocol
    {
        public string message;

        public static JsonHelloResponse ValueOf(string message)
        {
            var packet = new JsonHelloResponse();
            packet.message = message;
            return packet;
        }


        public short ProtocolId()
        {
            return 1601;
        }
    }


    public class JsonHelloResponseRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 1601;
        }

        public void Write(ByteBuffer buffer, IProtocol packet)
        {
            if (buffer.WritePacketFlag(packet))
            {
                return;
            }
            JsonHelloResponse message = (JsonHelloResponse) packet;
            buffer.WriteString(message.message);
        }

        public IProtocol Read(ByteBuffer buffer)
        {
            if (!buffer.ReadBool())
            {
                return null;
            }
            JsonHelloResponse packet = new JsonHelloResponse();
            string result0 = buffer.ReadString();
            packet.message = result0;
            return packet;
        }
    }
}
