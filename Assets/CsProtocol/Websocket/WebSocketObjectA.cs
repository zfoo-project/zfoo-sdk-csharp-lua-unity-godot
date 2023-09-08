using System;
using System.Collections.Generic;
using CsProtocol.Buffer;

namespace CsProtocol
{
    
    public class WebSocketObjectA : IProtocol
    {
        public int a;
        public WebSocketObjectB objectB;

        public static WebSocketObjectA ValueOf(int a, WebSocketObjectB objectB)
        {
            var packet = new WebSocketObjectA();
            packet.a = a;
            packet.objectB = objectB;
            return packet;
        }


        public short ProtocolId()
        {
            return 2071;
        }
    }


    public class WebSocketObjectARegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 2071;
        }

        public void Write(ByteBuffer buffer, IProtocol packet)
        {
            if (buffer.WritePacketFlag(packet))
            {
                return;
            }
            WebSocketObjectA message = (WebSocketObjectA) packet;
            buffer.WriteInt(message.a);
            buffer.WritePacket(message.objectB, 2072);
        }

        public IProtocol Read(ByteBuffer buffer)
        {
            if (!buffer.ReadBool())
            {
                return null;
            }
            WebSocketObjectA packet = new WebSocketObjectA();
            int result0 = buffer.ReadInt();
            packet.a = result0;
            WebSocketObjectB result1 = buffer.ReadPacket<WebSocketObjectB>(2072);
            packet.objectB = result1;
            return packet;
        }
    }
}
