using System;
using System.Collections.Generic;

namespace zfoocs
{
    
    public class UdpHelloResponse
    {
        public string message;

        public static UdpHelloResponse ValueOf(string message)
        {
            var packet = new UdpHelloResponse();
            packet.message = message;
            return packet;
        }
    }


    public class UdpHelloResponseRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 1201;
        }

        public void Write(ByteBuffer buffer, object packet)
        {
            if (packet == null)
            {
                buffer.WriteInt(0);
                return;
            }
            UdpHelloResponse message = (UdpHelloResponse) packet;
            buffer.WriteInt(-1);
            buffer.WriteString(message.message);
        }

        public object Read(ByteBuffer buffer)
        {
            int length = buffer.ReadInt();
            if (length == 0)
            {
                return null;
            }
            int beforeReadIndex = buffer.ReadOffset();
            UdpHelloResponse packet = new UdpHelloResponse();
            string result0 = buffer.ReadString();
            packet.message = result0;
            if (length > 0) {
                buffer.SetReadOffset(beforeReadIndex + length);
            }
            return packet;
        }
    }
}
