using System;
using System.Collections.Generic;
namespace zfoocs
{
    
    public class SignalAttachment
    {
        public int signalId;
        public int taskExecutorHash;
        // 0 for the server, 1 or 2 for the sync or async native client, 12 for the outside client such as browser, mobile
        public byte client;
        public long timestamp;
    }

    public class SignalAttachmentRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 0;
        }
    
        public void Write(ByteBuffer buffer, object packet)
        {
            if (packet == null)
            {
                buffer.WriteInt(0);
                return;
            }
            SignalAttachment message = (SignalAttachment) packet;
            buffer.WriteInt(-1);
            buffer.WriteByte(message.client);
            buffer.WriteInt(message.signalId);
            buffer.WriteInt(message.taskExecutorHash);
            buffer.WriteLong(message.timestamp);
        }
    
        public object Read(ByteBuffer buffer)
        {
            int length = buffer.ReadInt();
            if (length == 0)
            {
                return null;
            }
            int beforeReadIndex = buffer.GetReadOffset();
            SignalAttachment packet = new SignalAttachment();
            byte result0 = buffer.ReadByte();
            packet.client = result0;
            int result1 = buffer.ReadInt();
            packet.signalId = result1;
            int result2 = buffer.ReadInt();
            packet.taskExecutorHash = result2;
            long result3 = buffer.ReadLong();
            packet.timestamp = result3;
            if (length > 0)
            {
                buffer.SetReadOffset(beforeReadIndex + length);
            }
            return packet;
        }
    }
}