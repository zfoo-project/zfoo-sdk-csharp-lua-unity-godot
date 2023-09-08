using System.Threading.Tasks;
using CsProtocol;
using CsProtocol.Buffer;

namespace Summer.Net.Core
{
    public class EncodedPacketInfo
    {
        public TaskCompletionSource<IProtocol> task;
        public SignalOnlyAttachment attachment;
    }
}