namespace SquareGen
{
    public class HeightmapLayerSettings
    {
        public float[] octaveFactors = {1.0f, 0.5f, 0.25f, 0.13f, 0.65f, 0.37f};

        public float exponent { get; } = 1.0f;

        public float frequency = 1f;

        public int noiseSeed { get; } = 0;
    }
}