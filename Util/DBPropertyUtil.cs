using System.IO;
namespace Util
{
    public class DBPropertyUtil
    {
        public static string GetPropertyString(string fileName)
        {
            var properties = new Dictionary<string, string>();

            // Read the properties file
            foreach (var line in File.ReadLines(fileName))
            {
                var keyValue = line.Split('=');
                if (keyValue.Length == 2)
                {
                    properties[keyValue[0].Trim()] = keyValue[1].Trim();
                }
            }

            // Construct the connection string
            return $"Server={properties["db.hostname"]};Database={properties["db.dbname"]};User Id={properties["db.username"]};Password={properties["db.password"]};TrustServerCertificate=True;";
        }
    }
}
