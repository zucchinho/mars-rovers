using System;
using System.Linq;
using Nasa.MarsMission.Rovers.Core.Description.Terrain;

namespace Nasa.MarsMission.Rovers.Basic
{
    public class BasicGridTerrain : ITerrain<RoverLocation>
    {
        private int[] _dimensions;

        public int[] Dimensions
        {
            get => _dimensions;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (value.Length < 2 || value.Length > 3)
                {
                    throw new ArgumentException(
                        "Number of dimensions must be 2 or 3",
                        nameof(value));
                }

                if (value.Any(d => d < 1))
                {
                    throw new ArgumentException(
                        "All boundary values must be greater than 0",
                        nameof(value));
                }

                _dimensions = value;
            }
        }

        public bool IsOutOfBounds(RoverLocation roverStatus)
        {
            if (Dimensions == null)
            {
                throw new InvalidOperationException(
                    "The dimensions are not set on the terrain.");
            }

            var position = roverStatus.Position;

            if (position == null)
            {
                throw new ArgumentNullException(nameof(position));
            }

            if (position.Length != Dimensions.Length)
            {
                throw new ArgumentException(
                    $"The number of positional dimensions must be {Dimensions.Length}. Received: {position.Length}",
                    nameof(position));
            }

            // ReSharper disable once LoopCanBeConvertedToQuery
            for (var i = 0; i < position.Length; i++)
            {
                if (position[i] < 0 || position[i] > Dimensions[i])
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            return $"Dimensions: ({string.Join(',', Dimensions)})";
        }
    }
}