using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace BMA_Database
{
    class ConnectionStringProvider
    {
        //This adds another layer of sercurity to the database
        public static string ApplicationExeDirectory()
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var appRoot = Path.GetDirectoryName(location);
            return appRoot;
        }

        public static IConfigurationRoot GetAppSettings()
        {
            string appExeDirectory = ApplicationExeDirectory();
            var builder = new ConfigurationBuilder().SetBasePath(appExeDirectory).AddJsonFile("appsettings.json");
            return builder.Build();
        }
    }
}
