using System;
using System.Collections.Generic;
using CsProtocol.Buffer;

namespace CsProtocol
{
    
    public class CSharpObjectB : IProtocol
    {
        public bool flag;

        public static CSharpObjectB ValueOf(bool flag)
        {
            var packet = new CSharpObjectB();
            packet.flag = flag;
            return packet;
        }


        public short ProtocolId()
        {
            return 1167;
        }
    }


    public class CSharpObjectBRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 1167;
        }

        public void Write(ByteBuffer buffer, IProtocol packet)
        {
            if (buffer.WritePacketFlag(packet))
            {
                return;
            }
            CSharpObjectB message = (CSharpObjectB) packet;
            buffer.WriteBool(message.flag);
        }

        public IProtocol Read(ByteBuffer buffer)
        {
            if (!buffer.ReadBool())
            {
                return null;
            }
            CSharpObjectB packet = new CSharpObjectB();
            bool result0 = buffer.ReadBool();
            packet.flag = result0;
            return packet;
        }
    }
}
