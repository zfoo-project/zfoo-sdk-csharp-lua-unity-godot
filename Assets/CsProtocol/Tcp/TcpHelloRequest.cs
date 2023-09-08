using System;
using System.Collections.Generic;
using CsProtocol.Buffer;

namespace CsProtocol
{
    
    public class TcpHelloRequest : IProtocol
    {
        public string message;

        public static TcpHelloRequest ValueOf(string message)
        {
            var packet = new TcpHelloRequest();
            packet.message = message;
            return packet;
        }


        public short ProtocolId()
        {
            return 1300;
        }
    }


    public class TcpHelloRequestRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 1300;
        }

        public void Write(ByteBuffer buffer, IProtocol packet)
        {
            if (buffer.WritePacketFlag(packet))
            {
                return;
            }
            TcpHelloRequest message = (TcpHelloRequest) packet;
            buffer.WriteString(message.message);
        }

        public IProtocol Read(ByteBuffer buffer)
        {
            if (!buffer.ReadBool())
            {
                return null;
            }
            TcpHelloRequest packet = new TcpHelloRequest();
            string result0 = buffer.ReadString();
            packet.message = result0;
            return packet;
        }
    }
}
