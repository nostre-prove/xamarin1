namespace Test
{
    interface ILogging
    {
        void Debug(string sender, string message);
        void Info(string sender, string message);
        void Warn(string sender, string message);
        void Error(string sender, string message);
    }
}
