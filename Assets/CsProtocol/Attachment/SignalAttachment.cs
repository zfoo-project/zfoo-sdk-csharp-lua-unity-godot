using System;
using System.Collections.Generic;
using CsProtocol.Buffer;

namespace CsProtocol
{
    
    public class SignalAttachment : IProtocol
    {
        public int signalId;
        public int taskExecutorHash;
        public byte client;
        public long timestamp;

        public static SignalAttachment ValueOf(byte client, int signalId, int taskExecutorHash, long timestamp)
        {
            var packet = new SignalAttachment();
            packet.client = client;
            packet.signalId = signalId;
            packet.taskExecutorHash = taskExecutorHash;
            packet.timestamp = timestamp;
            return packet;
        }


        public short ProtocolId()
        {
            return 0;
        }
    }


    public class SignalAttachmentRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 0;
        }

        public void Write(ByteBuffer buffer, IProtocol packet)
        {
            if (buffer.WritePacketFlag(packet))
            {
                return;
            }
            SignalAttachment message = (SignalAttachment) packet;
            buffer.WriteByte(message.client);
            buffer.WriteInt(message.signalId);
            buffer.WriteInt(message.taskExecutorHash);
            buffer.WriteLong(message.timestamp);
        }

        public IProtocol Read(ByteBuffer buffer)
        {
            if (!buffer.ReadBool())
            {
                return null;
            }
            SignalAttachment packet = new SignalAttachment();
            byte result0 = buffer.ReadByte();
            packet.client = result0;
            int result1 = buffer.ReadInt();
            packet.signalId = result1;
            int result2 = buffer.ReadInt();
            packet.taskExecutorHash = result2;
            long result3 = buffer.ReadLong();
            packet.timestamp = result3;
            return packet;
        }
    }
}
