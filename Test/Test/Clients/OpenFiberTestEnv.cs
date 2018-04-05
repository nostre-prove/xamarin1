using AuditPlus.Interfaces;

namespace AuditPlus.Helpers
{
    class OpenFiberTestEnv : IEnvironment
    {
        public string GetEnvKey()
        {
            return "OpenFiberTestEnv";
        }

        public string GetEnvName() {
            return "OpenFiber DEVELOPMENT";
        }

        public string GetAnalyticsKeyAndroid() {
            return "712736db-ac34-4db5-9745-d3af207766b4";
        }

        public string GetAnalyticsKeyIos() {
            return "77ed2365-e5d9-4b98-a110-105176cbf376";
        }

        public string GetEndpointUrl() {
            return "http://ws-mobile-connector-dba.appspot.com";
        }

        public string GetLoginUrl() {
            return "/userLoginServlet?servletAction=login";
        }

    }
}
