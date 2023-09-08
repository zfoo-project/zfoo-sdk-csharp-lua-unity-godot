using System;
using System.Collections.Generic;
using CsProtocol.Buffer;

namespace CsProtocol
{
    
    public class TcpHelloResponse : IProtocol
    {
        public string message;

        public static TcpHelloResponse ValueOf(string message)
        {
            var packet = new TcpHelloResponse();
            packet.message = message;
            return packet;
        }


        public short ProtocolId()
        {
            return 1301;
        }
    }


    public class TcpHelloResponseRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 1301;
        }

        public void Write(ByteBuffer buffer, IProtocol packet)
        {
            if (buffer.WritePacketFlag(packet))
            {
                return;
            }
            TcpHelloResponse message = (TcpHelloResponse) packet;
            buffer.WriteString(message.message);
        }

        public IProtocol Read(ByteBuffer buffer)
        {
            if (!buffer.ReadBool())
            {
                return null;
            }
            TcpHelloResponse packet = new TcpHelloResponse();
            string result0 = buffer.ReadString();
            packet.message = result0;
            return packet;
        }
    }
}
