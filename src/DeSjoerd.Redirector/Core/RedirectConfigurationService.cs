using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeSjoerd.Redirector.Core
{
    public class RedirectConfigurationService
    {
        private readonly IConfiguration _configuration;

        public RedirectConfigurationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<RedirectConfigurationItem> GetRedirectConfigurations()
        {
            return _configuration.GetChildren()
                .Select(item => new RedirectConfigurationItem(item.Key, item.Value))
                .ToList();
        }
    }
}
