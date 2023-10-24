using System;
using System.Collections.Generic;

namespace zfoocs
{
    
    public class UdpHelloRequest
    {
        public string message;

        public static UdpHelloRequest ValueOf(string message)
        {
            var packet = new UdpHelloRequest();
            packet.message = message;
            return packet;
        }
    }


    public class UdpHelloRequestRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 1200;
        }

        public void Write(ByteBuffer buffer, object packet)
        {
            if (packet == null)
            {
                buffer.WriteInt(0);
                return;
            }
            UdpHelloRequest message = (UdpHelloRequest) packet;
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
            UdpHelloRequest packet = new UdpHelloRequest();
            string result0 = buffer.ReadString();
            packet.message = result0;
            if (length > 0) {
                buffer.SetReadOffset(beforeReadIndex + length);
            }
            return packet;
        }
    }
}
