using Logging;
using Logging.Enums;
using ResBee.Assets;
using ResBee.Factories;
using ResBee.Stores;
using System;
using System.Collections.Generic;
using System.IO;

//How this is supposed to work
//Asset has a name and data, stored somewhere or other.
//For something like an animation the data would be an Xelement which is used to instantiate a Animations object.
//For textures the actual Texture2D would be created once and stored in the AssetStore.



namespace ResBee.Loaders
{
    public static class ResourceLoader
    {
        public static void LoadResources(List<AssetDefinition> assetDefinitions)
        {
            foreach(AssetDefinition assetDefinition in assetDefinitions)
            {           
                List<string> filesToLoad = new List<string>();

                if(Directory.Exists(assetDefinition.Path))
                {
                    //The initial path points to a directory, get all the files and load any nested files if applicable.
                    GetFilesInDirectory(assetDefinition.Path, assetDefinition.LoadResursively, ref filesToLoad);
                }
                else
                {
                    //If the path isn't a directory it is probably a file, validate it and add it if so.
                    if(File.Exists(assetDefinition.Path))
                    {
                        filesToLoad.Add(assetDefinition.Path);
                    }
                }

                filesToLoad.ForEach(x => LoadResourceFromFile(assetDefinition.Type, assetDefinition.AssetFactory, x));
            }
        }

        private static void GetFilesInDirectory(string directoryPath, bool loadRecursively, ref List<string> files)
        {
            string[] filesToLoad = Directory.GetFiles(directoryPath);

            files.AddRange(filesToLoad);

            //Get all the directories in our current directory and process them as well if we are loading recursively.s
            if (loadRecursively)
            {
                string[] directoriesToLoad = Directory.GetDirectories(directoryPath);

                foreach (string directory in directoriesToLoad)
                {
                    GetFilesInDirectory(directory, true, ref files);
                }
            }
        }

        private static void LoadResourceFromFile(Type assetType, IAssetFactory assetFactory, string filePath)
        {
            try
            {
                Asset asset = assetFactory.CreateAsset(filePath);
                AssetStore.Instance.AddAsset(assetType, asset);
            }
            catch(Exception ex)
            {
                Logger.Log(LogType.Error, string.Format("Error occured while attempting to load file resource '{0}'. {1}", filePath, ex.ToString()));
                throw;
            }
        }
    }
}
