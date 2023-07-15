namespace TutorialRedis.CacheContract;

public interface ICacheService
{
    /// <summary>
    /// Get Data using key
    /// </summary>
    /// <param name="key"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    T GetData<T>(string key);

    /// <summary>
    /// Set Data with Value and Expiration Time of Key
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="expirationTime"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    bool SetData<T>(string key, T value, DateTimeOffset expirationTime);
    
    /// <summary>
    /// Remove Data
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    object RemoveData(string key);
}