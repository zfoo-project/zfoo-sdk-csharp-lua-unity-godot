// incoming message queue of <connectionId, message>
// (not a HashSet because one connection can have multiple new messages)
// -> a struct to minimize GC

using System.Runtime.InteropServices;

namespace zfoo
{
    
    public enum MessageType
    {
        Connected,
        Data,
        Disconnected
    }
    
    
    [StructLayout(LayoutKind.Auto)]
    public struct Message
    {
        public MessageType messageType;
        public object packet;
        public object attachment;

        public Message(MessageType messageType, object packet, object attachment)
        {
            this.messageType = messageType;
            this.packet = packet;
            this.attachment = attachment;
        }
    }
}