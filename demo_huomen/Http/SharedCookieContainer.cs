using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace demo_huomen
{
    public sealed class SharedCookieContainer
    {
        private static readonly Lazy<SharedCookieContainer> lazyInstance = new Lazy<SharedCookieContainer>(() => new SharedCookieContainer());

        public CookieContainer CookieContainer { get; private set; }

        private SharedCookieContainer()
        {
            CookieContainer = new CookieContainer();
        }

        public static SharedCookieContainer Instance => lazyInstance.Value;
    }
}
