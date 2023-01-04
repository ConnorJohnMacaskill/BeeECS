using ResBee.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResBee.Assets
{
    public sealed class AssetDefinition
    {
#warning Add some kind of filtering. should determine recursive loaading here.

        private AssetDefinition(string path, Type type, IAssetFactory assetFactory, bool loadRecursively)
        {
            Path = path;
            Type = type;
            AssetFactory = assetFactory;
            LoadResursively = loadRecursively;
        }

        public static AssetDefinition Create<T>(string path, IAssetFactory assetFactory, bool loadRecursively) where T : Asset
        {
            Type assetType = typeof(T);
            return new AssetDefinition(path, assetType, assetFactory, loadRecursively);
        }

        public string Path { get; private set; }
        public Type Type { get; private set; }
        public IAssetFactory AssetFactory { get; private set; }
        public bool LoadResursively { get; private set; }
    }
}
