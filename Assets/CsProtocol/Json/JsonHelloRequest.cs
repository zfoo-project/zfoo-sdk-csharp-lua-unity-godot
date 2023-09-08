using System;
using System.Collections.Generic;
using CsProtocol.Buffer;

namespace CsProtocol
{
    
    public class JsonHelloRequest : IProtocol
    {
        public string message;

        public static JsonHelloRequest ValueOf(string message)
        {
            var packet = new JsonHelloRequest();
            packet.message = message;
            return packet;
        }


        public short ProtocolId()
        {
            return 1600;
        }
    }


    public class JsonHelloRequestRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 1600;
        }

        public void Write(ByteBuffer buffer, IProtocol packet)
        {
            if (buffer.WritePacketFlag(packet))
            {
                return;
            }
            JsonHelloRequest message = (JsonHelloRequest) packet;
            buffer.WriteString(message.message);
        }

        public IProtocol Read(ByteBuffer buffer)
        {
            if (!buffer.ReadBool())
            {
                return null;
            }
            JsonHelloRequest packet = new JsonHelloRequest();
            string result0 = buffer.ReadString();
            packet.message = result0;
            return packet;
        }
    }
}
