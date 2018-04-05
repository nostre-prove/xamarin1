using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Helpers
{
    public interface IEnvironment
    {
        string EnvName();
        string AnalyticsKeyAndroid();
        string AnalyticsKeyIos();
        string EndpointUrl();
        string LoginUrl();
    }
}
