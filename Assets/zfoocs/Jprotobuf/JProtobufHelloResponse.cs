using System;
using System.Collections.Generic;

namespace zfoocs
{
    
    public class JProtobufHelloResponse
    {
        public string message;

        public static JProtobufHelloResponse ValueOf(string message)
        {
            var packet = new JProtobufHelloResponse();
            packet.message = message;
            return packet;
        }
    }


    public class JProtobufHelloResponseRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 1501;
        }

        public void Write(ByteBuffer buffer, object packet)
        {
            if (packet == null)
            {
                buffer.WriteInt(0);
                return;
            }
            JProtobufHelloResponse message = (JProtobufHelloResponse) packet;
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
            JProtobufHelloResponse packet = new JProtobufHelloResponse();
            string result0 = buffer.ReadString();
            packet.message = result0;
            if (length > 0) {
                buffer.SetReadOffset(beforeReadIndex + length);
            }
            return packet;
        }
    }
}
