namespace AuditPlus.Interfaces
{
    public interface IEnvironment
    {
        string GetEnvKey();
        string GetEnvName();
        string GetAnalyticsKeyAndroid();
        string GetAnalyticsKeyIos();
        string GetEndpointUrl();
        string GetLoginUrl();
    }
}
