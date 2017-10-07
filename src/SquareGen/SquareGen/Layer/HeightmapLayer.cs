using System;
using LibNoise.Primitive;

namespace SquareGen.Layer
{
    public class HeightmapLayer
    {
        public HeightmapLayerSettings Settings { get; }

        private SimplexPerlin _noiseSource;

        public HeightmapLayer(HeightmapLayerSettings settings)
        {
            this.Settings = settings;
            _noiseSource = new SimplexPerlin
            {
                Seed = settings.Seed
            };
        }

        private float NoiseFunction(float x, float y)
        {
            var v = _noiseSource.GetValue(x, y);
            // rescale to 0..1
            v = (v + 1f / 2);
            return v;
        }

        private float GetNoiseValue(float x, float y)
        {
            var v = 0f;
            var vd = 0f;
            // fractal weights
            for (var i = 0; i < Settings.OctaveFactors.Length; i++)
            {
                var j = Settings.OctaveFactors[i];
                var k = (int) Math.Pow(j, 2);
                v += NoiseFunction(x * Settings.Frequency * k,
                         y * Settings.Frequency * k) * j;
                vd += j;
            }
            v /= vd;
            // exponent
            v = (float) Math.Pow(v, Settings.Exponent);

            return v;
        }

        public float[,] Generate(int x, int y, int w, int h)
        {
            var layerData = new float[w, h];
            for (var i = x; i < w; i++)
            {
                for (var j = y; j < h; j++)
                {
                    var v = GetNoiseValue(i, j);
                    layerData[i, j] = v;
                }
            }

            return layerData;
        }
    }
}