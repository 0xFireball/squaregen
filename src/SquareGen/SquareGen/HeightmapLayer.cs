using System;
using LibNoise.Primitive;

namespace SquareGen
{
    public class HeightmapLayer
    {
        public HeightmapLayerSettings settings { get; }

        private SimplexPerlin _noiseSource;

        public HeightmapLayer(HeightmapLayerSettings settings)
        {
            this.settings = settings;
            _noiseSource = new SimplexPerlin
            {
                Seed = settings.noiseSeed
            };
        }

        private float getNoiseValue(float x, float y)
        {
            var v = 0f;
            var vd = 0f;
            // fractal weights
            for (var i = 0; i < settings.octaveFactors.Length; i++)
            {
                var j = settings.octaveFactors[i];
                var k = (int) Math.Pow(j, 2);
                v += _noiseSource.GetValue(x * settings.frequency * k,
                         y * settings.frequency * k) * j;
                vd += j;
            }
            v /= vd;
            // exponent
            v = (float) Math.Pow(v, settings.exponent);

            return v;
        }

        public float[,] generate(int x, int y, int w, int h)
        {
            var layerData = new float[w, h];
            for (var i = x; i < w; i++)
            {
                for (var j = y; j < h; j++)
                {
                    var v = getNoiseValue(i, j);
                    layerData[i, j] = v;
                }
            }

            return layerData;
        }
    }
}