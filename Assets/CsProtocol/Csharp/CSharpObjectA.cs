using System;
using System.Collections.Generic;
using CsProtocol.Buffer;

namespace CsProtocol
{
    
    public class CSharpObjectA : IProtocol
    {
        public int value;
        public CSharpObjectB objectB;

        public static CSharpObjectA ValueOf(CSharpObjectB objectB, int value)
        {
            var packet = new CSharpObjectA();
            packet.objectB = objectB;
            packet.value = value;
            return packet;
        }


        public short ProtocolId()
        {
            return 1166;
        }
    }


    public class CSharpObjectARegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 1166;
        }

        public void Write(ByteBuffer buffer, IProtocol packet)
        {
            if (buffer.WritePacketFlag(packet))
            {
                return;
            }
            CSharpObjectA message = (CSharpObjectA) packet;
            buffer.WritePacket(message.objectB, 1167);
            buffer.WriteInt(message.value);
        }

        public IProtocol Read(ByteBuffer buffer)
        {
            if (!buffer.ReadBool())
            {
                return null;
            }
            CSharpObjectA packet = new CSharpObjectA();
            CSharpObjectB result0 = buffer.ReadPacket<CSharpObjectB>(1167);
            packet.objectB = result0;
            int result1 = buffer.ReadInt();
            packet.value = result1;
            return packet;
        }
    }
}
