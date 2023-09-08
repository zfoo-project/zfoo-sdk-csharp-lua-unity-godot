using System;
using System.Collections.Generic;
using CsProtocol.Buffer;

namespace CsProtocol
{
    
    public class WebSocketObjectB : IProtocol
    {
        public bool flag;

        public static WebSocketObjectB ValueOf(bool flag)
        {
            var packet = new WebSocketObjectB();
            packet.flag = flag;
            return packet;
        }


        public short ProtocolId()
        {
            return 2072;
        }
    }


    public class WebSocketObjectBRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 2072;
        }

        public void Write(ByteBuffer buffer, IProtocol packet)
        {
            if (buffer.WritePacketFlag(packet))
            {
                return;
            }
            WebSocketObjectB message = (WebSocketObjectB) packet;
            buffer.WriteBool(message.flag);
        }

        public IProtocol Read(ByteBuffer buffer)
        {
            if (!buffer.ReadBool())
            {
                return null;
            }
            WebSocketObjectB packet = new WebSocketObjectB();
            bool result0 = buffer.ReadBool();
            packet.flag = result0;
            return packet;
        }
    }
}
