using System;
using System.IO;
using System.Net;
using SquareGen.Layer;

namespace SquareGen.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SquareGen Demo");

            if (args.Length == 0)
            {
                Console.WriteLine("Please provide some args");
                return;
            }

            int.TryParse(args[0], out var dims);
            var ouf = args[1];

            var rng = new Random();

            var worldGen = new WorldMapGenerator(new WorldMapGeneratorSettings
            {
                Seed = rng.Next(),
                ElevationLayerSettings = new HeightmapLayerSettings
                {
                    OctaveFactors = new[] {0.62f, 0.30f, 0.27f, 0.13f, 0.06f, 0.03f},
                    Exponent = 2.8f
                },
                MoistureLayerSettings = new HeightmapLayerSettings
                {
                    OctaveFactors = new[] {1.00f, 0.75f, 0.33f, 0.33f, 0.33f, 0.50f},
                    Exponent = 1.0f
                },
            });
            worldGen.CreateLayers();

            // generate some Mep for us
            var mep = worldGen.GenerateRegion(0, 0, dims, dims);

            // serialize the mep to text
            using (var os = File.Open(ouf, FileMode.Create))
            {
                using (var sw = new StreamWriter(os))
                {
                    sw.Write($"{dims}x{dims}");
                    sw.WriteLine();

                    for (var i = 0; i < dims; i++)
                    {
                        for (var j = 0; j < dims; j++)
                        {
                            sw.Write((int) mep.Terrain[j, i]);
                            sw.Write(",");
                        }
                        sw.WriteLine();
                    }
                }
            }
        }
    }
}