using Nasa.MarsMission.Rovers.Core.Agent;
using Nasa.MarsMission.Rovers.Core.Fleet;

namespace Nasa.MarsMission.Rovers.Basic
{
    public abstract class CartesianFlatRover : BaseDeployedRover
    {
        public override int[] Move(int magnitude)
        {
            var vector = GetTranslation(magnitude);

            Position[0] += vector[0];
            Position[1] += vector[0];

            return Position;
        }

        public override int Rotate(int angleOfRotation)
        {
            return CalculateBearing(angleOfRotation);
        }

        protected abstract int[] GetTranslation(int magnitude);
        protected abstract int CalculateBearing(int angleOfRotation);

        public override int[] Position { get; set; } = {0, 0};
    }
}