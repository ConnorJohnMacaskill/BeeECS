using Newtonsoft.Json;

namespace Asteroids.Models
{
    [JsonObject]
    public class SpriteSheetData
    {
        [JsonProperty("frames")]
        public FrameData[] Frames { get; set; }

        [JsonProperty("meta")]
        public MetaData MetaData { get; set; }
    }

    [JsonObject()]
    public class FrameData
    {
        [JsonProperty("frame")]
        public DimensionsData DimensionsData { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }
    }

    [JsonObject("frame")]
    public class DimensionsData
    {
        [JsonProperty("x")]
        public int X { get; set; }

        [JsonProperty("y")]
        public int Y { get; set; }


        [JsonProperty("w")]
        public int Width { get; set; }


        [JsonProperty("h")]
        public int Height { get; set; }
    }

    [JsonObject("meta")]
    public class MetaData
    {
        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("frameTags")]
        public AnimationData[] Animations { get; set; }
    }

    [JsonObject()]
    public class AnimationData
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("from")]
        public int StartIndex { get; set; }

        [JsonProperty("to")]
        public int EndIndex { get; set; }

        [JsonProperty("direction")]
        public string Direction { get; set; }

    }
}
