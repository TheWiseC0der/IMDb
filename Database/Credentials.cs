using Newtonsoft.Json;

namespace IMDb.Database;

public class Credentials
{
    [JsonProperty("username")] public string Username { get; set; }
    [JsonProperty("password")] public string Password { get; set; }
    [JsonProperty("host")] public string Host { get; set; }
    [JsonProperty("port")] public int Port { get; set; }
    [JsonProperty("databaseName")] public string Database { get; set; }

    public Credentials()
    {
        Username = "Survento";
        Password = "password123";
        Host = "localhost";
        Port = 3306;
        Database = "survento";

        if (!File.Exists(@"config.json"))
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            using (StreamWriter outFile = new StreamWriter(@"config.json"))
            {
                outFile.Write(json);
                Console.WriteLine("New database file created. Please add database credentials to config.json");
            }

            Environment.Exit(602);
        }

        JsonConvert.PopulateObject(File.ReadAllText(@"config.json"), this);
    }
}