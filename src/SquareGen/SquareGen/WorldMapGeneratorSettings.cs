using SquareGen.Layer;

namespace SquareGen
{
    public class WorldMapGeneratorSettings
    {
        public int Seed { get; set; } = 0;
        
        public HeightmapLayerSettings ElevationLayerSettings { get; set; } = new HeightmapLayerSettings();
        
        public HeightmapLayerSettings MoistureLayerSettings { get; set; } = new HeightmapLayerSettings();
    }
}