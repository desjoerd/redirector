using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeSjoerd.Redirector.Core
{
    public class RedirectConfigurationItem
    {
        public RedirectConfigurationItem(string domain, string target)
        {
            Domain = domain;
            Target = target;
        }

        public string Domain { get; set; }

        public string Target { get; set; }

        public bool MatchesDomain(string host) => string.Equals(Domain, host, StringComparison.InvariantCultureIgnoreCase);
    }
}
