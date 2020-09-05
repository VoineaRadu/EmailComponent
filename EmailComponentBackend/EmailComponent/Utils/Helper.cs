namespace EmailComponent.Utils
{
    public static class Helper
    {
        public const string DbName = "emailcomponent";

        public const string MasterConnectionString = "Server=localhost;Integrated security=SSPI;database=master";

        public const string MyConnectionString = "Server=localhost;Integrated security=SSPI;database=" + DbName;
    }
}