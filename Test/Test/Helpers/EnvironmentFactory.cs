using AuditPlus.Interfaces;
using Xamarin.Forms;

namespace AuditPlus.Helpers
{
    class EnvironmentFactory
    {
        public static IEnvironment GetInstance()
        {
            IEnvironment client = null;
            if (Application.Current.Properties.ContainsKey(Constants.SITE_ID))
            {
                switch (Application.Current.Properties[Constants.SITE_ID] as string)
                {
                    case "OpenFiberProdEnv":
                        client = new OpenFiberProdEnv();
                        break;
                    case "OpenFiberTestEnv":
                        client = new OpenFiberTestEnv();
                        break;
                }
            }
            return client;
        }
    }
}
