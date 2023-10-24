using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace zfoo
{
    public class HostAndPort
    {
        public string host;
        public int port;

        public static HostAndPort ValueOf(string host, int port)
        {
            HostAndPort hostAndPort = new HostAndPort();
            hostAndPort.host = host;
            hostAndPort.port = port;
            return hostAndPort;
        }

        /**
         * @param hostAndPort example -> localhost:port
         */
        public static HostAndPort ValueOf(string hostAndPort)
        {
            var split = Regex.Split(hostAndPort.Trim(), ":|：");
            return ValueOf(split[0].Trim(), int.Parse(split[1].Trim()));
        }

    }
}