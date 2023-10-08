using System.Threading.Tasks;
using CsProtocol.Buffer;

namespace Summer.Net
{
    public interface INetManager
    {
        void Connect(string url);

        void Close();

        void Send(IProtocol packet);
        
    }
}