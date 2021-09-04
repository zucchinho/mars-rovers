using Nasa.MarsMission.Rovers.Core.Agent;

namespace Nasa.MarsMission.Rovers.Basic
{
    public abstract class CartesianFlatRover : IRover
    {
        public int[] Move(int magnitude)
        {
            var vector = GetTranslation(magnitude);

            Position[0] += vector[0];
            Position[1] += vector[0];

            return Position;
        }

        public int Rotate(int angleOfRotation)
        {
            return CalculateBearing(angleOfRotation);
        }

        protected abstract int[] GetTranslation(int magnitude);
        protected abstract int CalculateBearing(int angleOfRotation);

        public int[] Position { get; set; } = {0, 0};
        public int Bearing { get; set; }
    }
}