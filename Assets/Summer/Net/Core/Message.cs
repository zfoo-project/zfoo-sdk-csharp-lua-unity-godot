// incoming message queue of <connectionId, message>
// (not a HashSet because one connection can have multiple new messages)
// -> a struct to minimize GC

using System.Runtime.InteropServices;
using CsProtocol.Buffer;

namespace Summer.Net.Core
{
    [StructLayout(LayoutKind.Auto)]
    public struct Message
    {
        public MessageType messageType;
        public IProtocol packet;
        public IProtocol attachment;

        public Message(MessageType messageType, IProtocol packet, IProtocol attachment)
        {
            this.messageType = messageType;
            this.packet = packet;
            this.attachment = attachment;
        }
    }
}