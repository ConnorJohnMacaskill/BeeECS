using ResBee.Assets;

namespace ResBee.Factories
{
    public interface IAssetFactory
    {
        /// <summary>
        /// Create an Asset from a file.
        /// </summary>
        /// <param name="filePath">The path to the file.</param>
        /// <returns></returns>
        Asset CreateAsset(string filePath);
    }
}
