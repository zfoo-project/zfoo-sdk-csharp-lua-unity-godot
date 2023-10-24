using System;
using System.Collections.Generic;

namespace zfoocs
{
    
    public class JProtobufHelloRequest
    {
        public string message;

        public static JProtobufHelloRequest ValueOf(string message)
        {
            var packet = new JProtobufHelloRequest();
            packet.message = message;
            return packet;
        }
    }


    public class JProtobufHelloRequestRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 1500;
        }

        public void Write(ByteBuffer buffer, object packet)
        {
            if (packet == null)
            {
                buffer.WriteInt(0);
                return;
            }
            JProtobufHelloRequest message = (JProtobufHelloRequest) packet;
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
            JProtobufHelloRequest packet = new JProtobufHelloRequest();
            string result0 = buffer.ReadString();
            packet.message = result0;
            if (length > 0) {
                buffer.SetReadOffset(beforeReadIndex + length);
            }
            return packet;
        }
    }
}
