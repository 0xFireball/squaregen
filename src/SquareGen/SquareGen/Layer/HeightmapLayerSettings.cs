namespace SquareGen.Layer
{
    public class HeightmapLayerSettings
    {
        public float[] OctaveFactors { get; set; } = {1.0f, 0.5f, 0.25f, 0.13f, 0.65f, 0.37f};

        public float Exponent { get; set; } = 1.0f;

        public float Frequency { get; set; } = 1f;

        public int Seed { get; set; } = 0;
    }
}