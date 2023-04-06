using Microsoft.Extensions.Configuration;

namespace SpecflowGroupExcercise.Configurations
{
    public class ConfigurationFactory
    {
        private static IConfigurationRoot ConfigurationRoot
        {
            get
            {
                var configurationBuilder = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile($"settings.json", true);

                return configurationBuilder.Build();
            }
        }

        public static string GetRemoteAddress =>
            new string(ConfigurationRoot.GetSection("enviroment:remoteAddress").Value);


        public static TimeSpan GetTimeOut =>
             TimeSpan.Parse(ConfigurationRoot.GetSection("timeouts:ConditionTimeout").Value!);

        public static TimeSpan GetPollingInterval =>
             TimeSpan.Parse(ConfigurationRoot.GetSection("timeouts:PollingInterval").Value!);

        public IConfigurationRoot GetConfigurationRoot => ConfigurationRoot;
        
        public static string FileUpload => new string(ConfigurationRoot.GetSection("fileUpload:filePath").Value);

        public static string UploadImage => Path.Combine(Environment.CurrentDirectory, "testData", FileUpload);
    }
}