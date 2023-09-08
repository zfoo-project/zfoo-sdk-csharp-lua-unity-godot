using System;
using System.Collections.Generic;
using CsProtocol.Buffer;

namespace CsProtocol
{
    
    public class SignalOnlyAttachment : IProtocol
    {
        public int signalId;
        public long timestamp;

        public static SignalOnlyAttachment ValueOf(int signalId, long timestamp)
        {
            var packet = new SignalOnlyAttachment();
            packet.signalId = signalId;
            packet.timestamp = timestamp;
            return packet;
        }


        public short ProtocolId()
        {
            return 1;
        }
    }


    public class SignalOnlyAttachmentRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 1;
        }

        public void Write(ByteBuffer buffer, IProtocol packet)
        {
            if (buffer.WritePacketFlag(packet))
            {
                return;
            }
            SignalOnlyAttachment message = (SignalOnlyAttachment) packet;
            buffer.WriteInt(message.signalId);
            buffer.WriteLong(message.timestamp);
        }

        public IProtocol Read(ByteBuffer buffer)
        {
            if (!buffer.ReadBool())
            {
                return null;
            }
            SignalOnlyAttachment packet = new SignalOnlyAttachment();
            int result0 = buffer.ReadInt();
            packet.signalId = result0;
            long result1 = buffer.ReadLong();
            packet.timestamp = result1;
            return packet;
        }
    }
}
