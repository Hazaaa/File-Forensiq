using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileForensiq.Redis
{
    public class RedisFunctions
    {
        readonly RedisClient redis = new RedisClient(RedisConfig.SingleHost);
        private System.Diagnostics.Process redisProcess;
        public int ServerStarted { get { return redisProcess != null ? redisProcess.Id : 0; } }

        /// <summary>
        /// Tries to start Redis Server.
        /// </summary>
        /// <returns>Bool that indicates if Redis Server is started or not.</returns>
        public bool StartRedisServer()
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo()
                {
                    FileName = Path.Combine(Environment.CurrentDirectory, @"Redis-x64-3.0.504\redis-server.exe"),
                    WindowStyle = ProcessWindowStyle.Minimized
                };

                redisProcess = Process.Start(startInfo);
                return (redisProcess != null && redisProcess.Id != 0) ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Tries to grecefully shutdown Redis Server.
        /// </summary>
        /// <returns>Bool that indicates if Redis Server is closed or not.</returns>
        public bool ShutDownRedisServer()
        {
            try
            {
                if(redisProcess != null)
                {
                    redisProcess.CloseMainWindow();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Clears all data in Redis db.
        /// </summary>
        /// <returns>Bool that indicates that if all data is deleted.</returns>
        public bool ClearRedis()
        {
            redis.FlushAll();
            return (redis.GetAllKeys().Count == 0) ? true : false;
        }

        /// <summary>
        /// Caches data in Redis db that will expire in 30 days.
        /// </summary>
        /// <returns>Bool if data is successfully cached.</returns>
        public bool AddNewCache(string key, string cache)
        {
            return redis.Set(key, cache, DateTime.Now.AddDays(30)); ;
        }

        /// <summary>
        /// Adds new config data to Redis.
        /// </summary>
        /// <returns>Bool if data is successfully cached.</returns>
        public bool AddNewConfig(string key, string value)
        {
            return redis.Set(key, value);
        }

        /// <summary>
        /// Returns all keys in Redis.
        /// </summary>
        /// <returns>List of keys as strings.</returns>
        public List<string> GetAllKeys()
        {
            return redis.GetAllKeys();
        }

        /// <summary>
        /// Returns data for key if it exists.
        /// </summary>
        /// <returns>Value for key.</returns>
        public string GetValueForKey(string key)
        {
            if (CheckIfKeyExists(key))
            {
                return redis.Get<string>(key);
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Checks if specify key in Redis db.
        /// </summary>
        /// <returns>Bool if data is successfully cached.</returns>
        public bool CheckIfKeyExists(string key)
        {
            var result = redis.Exists(key);
            return result != 0 ? true : false;
        } 

        /// <summary>
        /// This function forces Redis to save data to his local dump file.
        /// </summary>
        public void SaveData()
        {
            redis.SaveAsync();
        }
    }
}
