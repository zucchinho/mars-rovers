using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Nasa.MarsMission.Rovers.Basic.Helpers;
using Nasa.MarsMission.Rovers.Core.Fleet;

namespace Nasa.MarsMission.Rovers.Basic
{
    public class BasicFleet : DeployedFleetBase<BasicRover, RoverLocation, BasicGridTerrain>
    {
        protected override Regex DeployRoverPattern => new Regex(@"^\d+ \d+ [NESW]{1}$");
        protected override Regex InstructRoverPattern => new Regex(@"^[LRM]+$");
        
        protected override BasicRover GetRoverInstance(RoverLocation roverStatus)
        {
            return new BasicRover
            {
                Ready = true,
                Status = roverStatus,
                Designation = Guid.NewGuid().ToString()
            };
        }

        protected override BasicRover GetActiveRover()
        {
            return Rovers.FirstOrDefault(r => r.Ready);
        }

        protected override RoverLocation ExtractRoverStatus(string input)
        {
            // input should be 2 numbers for location, 1 for bearing e.g. "1 5 S"
            var elements = input.Split(' ');

            if (elements.Length != 3)
            {
                throw new ArgumentException(
                    $"Input is invalid for rover status. Input: {input}",
                    nameof(input));
            }

            var positionElements = elements.Take(2);
            var position = ExtractPosition(positionElements.ToArray());            

            var directionElement = elements.Skip(2).SingleOrDefault();

            if (directionElement == null || directionElement.Length != 1)
            {
                throw new ArgumentException(
                    $"Input is invalid for rover status. Input: {input}",
                    nameof(input));
            }

            return new RoverLocation
            {
                Position = position,
                Bearing = OrientationHelpers.ConvertFromCompassDirection(directionElement)
            };
        }

        protected override BasicGridTerrain ExtractTerrain(string input)
        {
            // input should be 2 numbers, corresponding to a map point e.g. "5 5"
            var elements = input.Split(' ');
            
            if (elements.Length != 2)
            {
                throw new ArgumentException(
                    $"Input is invalid for rover status. Input: {input}",
                    nameof(input));
            }

            return new BasicGridTerrain
            {
                Dimensions = ExtractPosition(elements)
            };
        }

        private static int[] ExtractPosition(IReadOnlyList<string> positionElements)
        {
            var position = new int[2];
            for (var i = 0; i < 2; i++)
            {
                var positionElement = positionElements[i];
                if (int.TryParse(positionElement, out var value))
                {
                    position[i] = value;
                }
                else
                {
                    throw new ArgumentException(
                        $"Failed to convert position element to numeric value. Position element: {positionElement}");
                }
            }

            return position;
        }
    }
}