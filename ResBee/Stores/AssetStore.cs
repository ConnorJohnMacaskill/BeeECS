using Logging;
using Logging.Enums;
using ResBee.Assets;
using System;
using System.Collections.Generic;

namespace ResBee.Stores
{
    public class AssetStore
    {
        private static AssetStore instance;
        private Dictionary<Type, Dictionary<string, Asset>> assets;

        private AssetStore()
        {
            assets = new Dictionary<Type, Dictionary<string, Asset>>();
        }

        public static AssetStore Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new AssetStore();
                }

                return instance;
            }
        }

        public void AddAsset(Type assetType, Asset asset, bool replaceExisting = false)
        {
            try
            {
                if(!assets.ContainsKey(assetType))
                {
                    assets.Add(assetType, new Dictionary<string, Asset>());
                }

                //if (replaceExisting || !assets.ContainsKey(assetType))
                //{
                    assets[assetType][asset.Name] = asset;
                //}
                /*
                else
                {
                    if (assets[assetType].ContainsKey(asset.Name))
                    {
                        Logger.Log(LogType.Warning, string.Format("Attempted to add a duplicate asset '{0}'.", asset.Name));
                    }
                    else
                    {
                        assets[assetType][asset.Name] = asset;
                    }
                }
                */
            }
            catch (Exception ex)
            {
                Logger.Log(LogType.Error, string.Format("Error occured while attempting to add a asset. {0}", ex.ToString()));
                throw;
            }
        }

        public T GetAsset<T>(string name) where T : Asset
        {
            T retVal = null;
            Type type = typeof(T);

            try
            {
                if (assets.ContainsKey(type))
                {
                    retVal = (T)assets[type][name];
                }
                else
                {
                    Logger.Log(LogType.Error, string.Format("Attempted to get a asset '{0}' named '{1}' which doesn't exist.", type.Name, name));
                }
            }
            catch(Exception ex)
            {
                Logger.Log(LogType.Error, string.Format("Error occured while attempting to get a asset. {0}", ex.ToString()));
            }

            return retVal;
        }
    }
}
