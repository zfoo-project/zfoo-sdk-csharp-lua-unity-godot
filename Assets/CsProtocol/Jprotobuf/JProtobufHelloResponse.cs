using System;
using System.Collections.Generic;
using CsProtocol.Buffer;

namespace CsProtocol
{
    
    public class JProtobufHelloResponse : IProtocol
    {
        public string message;

        public static JProtobufHelloResponse ValueOf(string message)
        {
            var packet = new JProtobufHelloResponse();
            packet.message = message;
            return packet;
        }


        public short ProtocolId()
        {
            return 1501;
        }
    }


    public class JProtobufHelloResponseRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 1501;
        }

        public void Write(ByteBuffer buffer, IProtocol packet)
        {
            if (buffer.WritePacketFlag(packet))
            {
                return;
            }
            JProtobufHelloResponse message = (JProtobufHelloResponse) packet;
            buffer.WriteString(message.message);
        }

        public IProtocol Read(ByteBuffer buffer)
        {
            if (!buffer.ReadBool())
            {
                return null;
            }
            JProtobufHelloResponse packet = new JProtobufHelloResponse();
            string result0 = buffer.ReadString();
            packet.message = result0;
            return packet;
        }
    }
}
