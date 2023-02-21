using IMDb.Database;

namespace IMDb;

public class Config
{
	private static readonly Credentials Credentials = new Credentials();

	public static readonly string ConnectionString = $@"
            Server = {Credentials.Host};
            Port = {Credentials.Port};
            Database = {Credentials.Database};
            Uid = {Credentials.Username};
            Pwd = {Credentials.Password};
            UseAffectedRows = True;
            SslMode = none;";
}