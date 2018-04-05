using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Helpers
{
    class EnvironmentFactory
    {
        public static IEnvironment getInstance()
        {
            if (1 == 0)
                return new OpenFiberTestEnv();
            else
                return new OpenFiberProdEnv();
        }
    }
}
