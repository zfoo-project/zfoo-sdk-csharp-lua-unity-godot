using System;
using System.Collections.Generic;

namespace zfoocs
{
    
    public class WebSocketObjectB
    {
        public bool flag;

        public static WebSocketObjectB ValueOf(bool flag)
        {
            var packet = new WebSocketObjectB();
            packet.flag = flag;
            return packet;
        }
    }


    public class WebSocketObjectBRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 2072;
        }

        public void Write(ByteBuffer buffer, object packet)
        {
            if (packet == null)
            {
                buffer.WriteInt(0);
                return;
            }
            WebSocketObjectB message = (WebSocketObjectB) packet;
            buffer.WriteInt(-1);
            buffer.WriteBool(message.flag);
        }

        public object Read(ByteBuffer buffer)
        {
            int length = buffer.ReadInt();
            if (length == 0)
            {
                return null;
            }
            int beforeReadIndex = buffer.ReadOffset();
            WebSocketObjectB packet = new WebSocketObjectB();
            bool result0 = buffer.ReadBool();
            packet.flag = result0;
            if (length > 0) {
                buffer.SetReadOffset(beforeReadIndex + length);
            }
            return packet;
        }
    }
}
