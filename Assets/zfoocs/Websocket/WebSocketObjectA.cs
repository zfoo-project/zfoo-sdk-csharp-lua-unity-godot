using System;
using System.Collections.Generic;

namespace zfoocs
{
    
    public class WebSocketObjectA
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
    }


    public class WebSocketObjectARegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 2071;
        }

        public void Write(ByteBuffer buffer, object packet)
        {
            if (packet == null)
            {
                buffer.WriteInt(0);
                return;
            }
            WebSocketObjectA message = (WebSocketObjectA) packet;
            buffer.WriteInt(-1);
            buffer.WriteInt(message.a);
            buffer.WritePacket(message.objectB, 2072);
        }

        public object Read(ByteBuffer buffer)
        {
            int length = buffer.ReadInt();
            if (length == 0)
            {
                return null;
            }
            int beforeReadIndex = buffer.ReadOffset();
            WebSocketObjectA packet = new WebSocketObjectA();
            int result0 = buffer.ReadInt();
            packet.a = result0;
            WebSocketObjectB result1 = buffer.ReadPacket<WebSocketObjectB>(2072);
            packet.objectB = result1;
            if (length > 0) {
                buffer.SetReadOffset(beforeReadIndex + length);
            }
            return packet;
        }
    }
}
