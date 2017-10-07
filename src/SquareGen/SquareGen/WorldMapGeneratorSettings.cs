using SquareGen.Layer;

namespace SquareGen
{
    public class WorldMapGeneratorSettings
    {
        public int Seed { get; set; } = 0;
        
        public HeightmapLayerSettings ElevationLayerSettings { get; } = new HeightmapLayerSettings();
        
        public HeightmapLayerSettings MoistureLayerSettings { get; } = new HeightmapLayerSettings();
    }
}