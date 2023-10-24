using System.Threading.Tasks;
using zfoocs;

namespace zfoo
{
    public class EncodedPacketInfo
    {
        public TaskCompletionSource<object> task;
        public SignalAttachment attachment;
    }
}