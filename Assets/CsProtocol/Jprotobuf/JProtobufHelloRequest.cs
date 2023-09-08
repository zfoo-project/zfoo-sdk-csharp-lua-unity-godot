using System;
using System.Collections.Generic;
using CsProtocol.Buffer;

namespace CsProtocol
{
    
    public class JProtobufHelloRequest : IProtocol
    {
        public string message;

        public static JProtobufHelloRequest ValueOf(string message)
        {
            var packet = new JProtobufHelloRequest();
            packet.message = message;
            return packet;
        }


        public short ProtocolId()
        {
            return 1500;
        }
    }


    public class JProtobufHelloRequestRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 1500;
        }

        public void Write(ByteBuffer buffer, IProtocol packet)
        {
            if (buffer.WritePacketFlag(packet))
            {
                return;
            }
            JProtobufHelloRequest message = (JProtobufHelloRequest) packet;
            buffer.WriteString(message.message);
        }

        public IProtocol Read(ByteBuffer buffer)
        {
            if (!buffer.ReadBool())
            {
                return null;
            }
            JProtobufHelloRequest packet = new JProtobufHelloRequest();
            string result0 = buffer.ReadString();
            packet.message = result0;
            return packet;
        }
    }
}
