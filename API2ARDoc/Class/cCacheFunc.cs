using StackExchange.Redis;
using System;
using System.Linq;

namespace API2ARDoc.Class
{
    public class cCacheFunc
    {
        private volatile ConnectionMultiplexer oC_Redis;
        private readonly object oC_InitLock = new object();
        private readonly TimeSpan oC_ServerTimeSpan;
        private readonly TimeSpan oC_ClientTimeSpan;
        private readonly bool bC_ForceOverWrite;
        //private string tC_CacheKey;
        private string tC_RedisIP;

        //*Ton 64-05-20 By pass cCacheFunc
        //private ICache oC_Cache;

        //private ICache Cache
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(tC_RedisIP))
        //        {
        //            return null;
        //        }

        //        return oC_Cache ?? (oC_Cache = new RedisCache(tC_RedisIP));
        //    }
        //}

        public cCacheFunc(long pnServerCacheSecond = 60, long pnClientCacheSeconds = 60, bool pbForceOverWrite = false)
        {
            //*Ton 64-05-19
            //this.tC_RedisIP = ConfigurationManager.AppSettings.Get("redisIpAddress");
            this.tC_RedisIP = cAppSetting.Default.tRedisIpAddress;

            this.oC_ServerTimeSpan = TimeSpan.FromSeconds(pnServerCacheSecond);
            this.oC_ClientTimeSpan = TimeSpan.FromSeconds(pnClientCacheSeconds);
            this.bC_ForceOverWrite = pbForceOverWrite;

            if (!string.IsNullOrEmpty(tC_RedisIP))
            {
                if (oC_Redis == null || !oC_Redis.IsConnected || !oC_Redis.GetDatabase().IsConnected(default(RedisKey)))
                {
                    lock (oC_InitLock)
                    {
                        try
                        {
                            ConfigurationOptions oConfigOpt = new ConfigurationOptions
                            {
                                AllowAdmin = true,              // ConnectionMultiplexer.Connect(ipAdrress + ", allowAdmin = true");
                                AbortOnConnectFail = false,     // ConnectionMultiplexer.Connect(ipAdrress + ", allowAdmin = true, abortConnect=false");
                                ConnectTimeout = 60000,         // 60000 millisecond = 60 second = 1 minute
                                SyncTimeout = 60000,
                                ResponseTimeout = 60000,
                                ConnectRetry = 3
                            };

                            oConfigOpt.EndPoints.Add(tC_RedisIP);
                            //oConfigOpt.EndPoints.Add(new DnsEndPoint(tC_RedisIP.Split(':')[0], int.Parse(tC_RedisIP.Split(':')[1])));
                            oC_Redis = ConnectionMultiplexer.Connect(oConfigOpt);
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
            }

        }

        /// <summary>
        ///     Check key in redis.
        /// </summary>
        /// 
        /// <param name="ptKey">Key.</param>
        /// 
        /// <returns>
        ///     true : found.<br/>
        ///     false : not found.
        /// </returns>
        public bool C_CAHbExistsKey(string ptKey)
        {
            //*Ton 64-05-20 By pass cCacheFunc
            //try
            //{
            //    if (Cache != null && Cache.Exists(ptKey))
            //    {
            //        // ถ้ามี key ใน cache
            //        return true;
            //    }
            //}
            //catch (Exception)
            //{

            //}

            return false;
        }

        /// <summary>
        ///     Add key and value to redis.
        /// </summary>
        /// 
        /// <param name="ptKey">Key.</param>
        /// <param name="poValue">Value.</param>
        public void C_CAHxAddKey(string ptKey, object poValue)
        {
            //*Ton 64-05-20 By pass cCacheFunc
            //try
            //{
            //    if (Cache != null)
            //    {
            //        Cache.Add(ptKey, poValue, this.oC_ServerTimeSpan, this.bC_ForceOverWrite);
            //    }
            //}
            //catch (Exception)
            //{

            //}
        }

        /// <summary>
        ///     Get key and value from redis.
        /// </summary>
        /// 
        /// <typeparam name="T">Class of value.</typeparam>
        /// <param name="ptKey">key.</param>
        /// 
        /// <returns>
        ///     Value of key in type T.
        /// </returns>
        public T C_CAHoGetKey<T>(string ptKey)
        {
            //*Ton 64-05-20 By pass cCacheFunc
            //try
            //{
            //    if (Cache != null)
            //    {
            //        T oValue = Cache.Get<T>(ptKey);
            //        return oValue;
            //    }
            //}
            //catch (Exception)
            //{

            //}

            return default(T);
        }

        /// <summary>
        ///     Delete all key and value in pattern key.
        /// </summary>
        /// 
        /// <param name="ptKey">Key.</param>
        public void C_CAHxDeleteAllKeyByPattern(string ptKey)
        {
            //*Ton 64-05-20 By pass cCacheFunc
            //try
            //{
            //    if (Cache != null)
            //    {
            //        //RedisKey[] aoKeys = oC_Redis.GetServer(tC_RedisIP).Keys(pattern: ("*" + ptKey + "*").ToLower()).ToArray();
            //        RedisKey[] aoKeys = oC_Redis.GetServer(tC_RedisIP).Keys(pattern: ptKey.ToLower()).ToArray();
            //        foreach (RedisKey oKey in aoKeys)
            //        {
            //            Cache.Delete(oKey.ToString());
            //        }
            //    }
            //}
            //catch (Exception)
            //{

            //}
        }
    }
}