using System;
using System.Collections.Generic;

namespace zfoocs
{
    
    public class Error
    {
        public int module;
        public int errorCode;
        public string errorMessage;

        public static Error ValueOf(int errorCode, string errorMessage, int module)
        {
            var packet = new Error();
            packet.errorCode = errorCode;
            packet.errorMessage = errorMessage;
            packet.module = module;
            return packet;
        }
    }


    public class ErrorRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 101;
        }

        public void Write(ByteBuffer buffer, object packet)
        {
            if (packet == null)
            {
                buffer.WriteInt(0);
                return;
            }
            Error message = (Error) packet;
            buffer.WriteInt(-1);
            buffer.WriteInt(message.errorCode);
            buffer.WriteString(message.errorMessage);
            buffer.WriteInt(message.module);
        }

        public object Read(ByteBuffer buffer)
        {
            int length = buffer.ReadInt();
            if (length == 0)
            {
                return null;
            }
            int beforeReadIndex = buffer.ReadOffset();
            Error packet = new Error();
            int result0 = buffer.ReadInt();
            packet.errorCode = result0;
            string result1 = buffer.ReadString();
            packet.errorMessage = result1;
            int result2 = buffer.ReadInt();
            packet.module = result2;
            if (length > 0) {
                buffer.SetReadOffset(beforeReadIndex + length);
            }
            return packet;
        }
    }
}
