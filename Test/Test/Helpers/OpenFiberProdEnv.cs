using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Helpers
{
    class OpenFiberProdEnv:IEnvironment
    {
        public string EnvName(){return "OpenFiberProdEnv";}
        public string AnalyticsKeyAndroid(){return "b3c120a0-5a9b-4f2f-863b-3546e0ba8e17";}
        public string AnalyticsKeyIos(){return "77ed2365-e5d9-4b98-a110-105176cbf376";}
        public string EndpointUrl(){return "http://ws-mobile-connector-dba.appspot.com"; }
        public string LoginUrl() { return "/userLoginServlet?servletAction=login"; }
    }
}
