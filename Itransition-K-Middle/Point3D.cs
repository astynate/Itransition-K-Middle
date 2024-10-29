namespace Itransition_K_Middle
{
    public class Point3D
    {
        public float X { get; private set; } = 0;
        public float Y { get; private set; } = 0;
        public float Z { get; private set; } = 0;

        public Point3D(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}