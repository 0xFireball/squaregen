namespace SquareGen.Map
{
    public enum Terrain
    {
        Water,
        Beach,
        Scorched,
        Bare,
        Tundra,
        Snow,
        TemperateDesert,
        Shrubland,
        Taiga,
        Grassland,
        TemperateDeciduousForest,
        TemperateRainforest,
        SubtropicalDesert,
        TropicalSeasonalForest,
        TropicalRainforest
    }

    public class MapRegion
    {
        public int X { get; }
        public int Y { get; }
        public int W { get; }
        public int H { get; }
        
        public Terrain[,] Terrain { get; }

        public MapRegion(int x, int y, int w, int h)
        {
            X = x;
            Y = y;
            W = w;
            H = h;
            Terrain = new Terrain[w, h];
        }
    }
}