using System;
using SquareGen.Layer;
using SquareGen.Map;

namespace SquareGen
{
    public class WorldMapGenerator
    {
        public WorldMapGeneratorSettings Settings { get; }

        public WorldMapGenerator(WorldMapGeneratorSettings settings)
        {
            Settings = settings;
        }


        private HeightmapLayer _elevationLayerGen;
        private HeightmapLayer _moistureLayerGen;

        public void CreateLayers()
        {
            var rng = new Random(Settings.Seed);

            // seed the layers
            Settings.ElevationLayerSettings.Seed = rng.Next();
            Settings.MoistureLayerSettings.Seed = rng.Next();

            // create the layers
            _elevationLayerGen = new HeightmapLayer(Settings.ElevationLayerSettings);
            _moistureLayerGen = new HeightmapLayer(Settings.ElevationLayerSettings);
        }

        public MapRegion GenerateRegion(int x, int y, int w, int h)
        {
            var region = new MapRegion(x, y, w, h);

            // layer generate
            var elev = _elevationLayerGen.Generate(x, y, w, h);
            var mois = _moistureLayerGen.Generate(x, y, w, h);

            // get terrain type
            for (var i = x; i < w; i++)
            {
                for (var j = y; j < h; j++)
                {
                    var t = TerrainBiome(elev[i, j], mois[i, j]);
                    region.Terrain[i, j] = t;
                }
            }

            return region;
        }

        private Terrain TerrainBiome(float e, float m)
        {
            if (e < 0.1f) return Terrain.Water;
            if (e < 0.12) return Terrain.Beach;

            if (e > 0.8)
            {
                if (m < 0.1) return Terrain.Scorched;
                if (m < 0.2) return Terrain.Bare;
                if (m < 0.5) return Terrain.Tundra;
                return Terrain.Snow;
            }

            if (e > 0.6)
            {
                if (m < 0.33) return Terrain.TemperateDesert;
                if (m < 0.66) return Terrain.Shrubland;
                return Terrain.Taiga;
            }

            if (e > 0.3)
            {
                if (m < 0.16) return Terrain.TemperateDesert;
                if (m < 0.50) return Terrain.Grassland;
                if (m < 0.83) return Terrain.TemperateDeciduousForest;
                return Terrain.TemperateRainforest;
            }

            if (m < 0.16) return Terrain.SubtropicalDesert;
            if (m < 0.33) return Terrain.Grassland;
            if (m < 0.66) return Terrain.TropicalSeasonalForest;
            return Terrain.TropicalRainforest;
        }
    }
}