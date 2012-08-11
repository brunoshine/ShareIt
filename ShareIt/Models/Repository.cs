using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using RedBranch.Hammock;

namespace ShareIt.Models
{
    public class Repository
    {
        public static Repository<T> Get<T>() where T : class
        {
            string databaseName = ConfigurationManager.AppSettings.Get("database_name");
#if DEBUG
            var connection = new Connection(new Uri(ConfigurationManager.ConnectionStrings["CLOUDANT_URL"].ConnectionString));
#else
            var connection = new Connection(new Uri(ConfigurationManager.AppSettings.Get("CLOUDANT_URL")));
#endif
            if (!connection.ListDatabases().Contains(databaseName))
            {
                connection.CreateDatabase(databaseName);
            }
            return new Repository<T>(connection.CreateSession(databaseName));
        }
    }
}