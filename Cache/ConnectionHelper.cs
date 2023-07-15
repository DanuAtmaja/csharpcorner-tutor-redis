using StackExchange.Redis;
using ConfigurationManager = TutorialRedis.Config.ConfigurationManager;

namespace TutorialRedis.Cache;

public class ConnectionHelper
{
    static ConnectionHelper()
    {
        ConnectionHelper.lazzyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect(ConfigurationManager.AppSetting["RedisURL"]);
        });
    }

    private static Lazy<ConnectionMultiplexer> lazzyConnection;
    
    public static ConnectionMultiplexer Connection
    {
        get
        {
            return lazzyConnection.Value;
        }
    }
}