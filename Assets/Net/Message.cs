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
        Disconnected,
        Error
    }
    
    
    [StructLayout(LayoutKind.Auto)]
    public struct Message
    {
        public MessageType messageType;
        public byte[] buffer;

        public Message(MessageType messageType, byte[] buffer)
        {
            this.messageType = messageType;
            this.buffer = buffer;
        }
    }
}