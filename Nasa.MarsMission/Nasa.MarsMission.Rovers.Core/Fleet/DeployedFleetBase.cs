using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Nasa.MarsMission.Rovers.Core.Agent;
using Nasa.MarsMission.Rovers.Core.Description.Terrain;

namespace Nasa.MarsMission.Rovers.Core.Fleet
{
    /// <summary>
    /// A deployed fleet of rovers
    /// </summary>
    /// <typeparam name="TRover">The type of rover.</typeparam>
    /// <typeparam name="TStatus">The type of rover status.</typeparam>
    /// <typeparam name="TTerrain">The type of terrain.</typeparam>
    public abstract class DeployedFleetBase<TRover, TStatus, TTerrain>
        : InputReceiverBase<FleetInstruction, IReadOnlyList<string>>, IDeployedFleet<TRover>
        where TRover : IDeployedRover<TStatus>
        where TTerrain : ITerrain<TStatus>
    {
        private readonly List<TRover> _rovers = new List<TRover>();
        
        public IReadOnlyCollection<TRover> Rovers => _rovers;
        
        /// <summary>
        /// The pattern for valid Deploy commands
        /// </summary>
        protected abstract Regex DeployRoverPattern { get; }
        
        /// <summary>
        /// The pattern for valid Instruct commands
        /// </summary>
        protected abstract Regex InstructRoverPattern { get; }

        private TRover ActiveRover => GetActiveRover();
        private TTerrain Terrain { get; set; }

        /// <summary>
        /// Interprets input as a sequence of fleet instructions
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The fleet instructions.</returns>
        /// <exception cref="ArgumentException"></exception>
        protected override IEnumerable<FleetInstruction> Interpret(
            IReadOnlyList<string> input)
        {
            for (var i = 0; i < input.Count; i++)
            {
                var inputLine = input[i];

                // the first command will always be to set the terrain
                if (i == 0)
                {
                    yield return new FleetInstruction
                    {
                        Type = InstructionType.SetTerrain,
                        Content = inputLine
                    };
                }
                else if (DeployRoverPattern.IsMatch(inputLine))
                {
                    yield return new FleetInstruction
                    {
                        Type = InstructionType.DeployRover,
                        Content = inputLine
                    };
                }
                else if (InstructRoverPattern.IsMatch(inputLine))
                {
                    yield return new FleetInstruction
                    {
                        Type = InstructionType.InstructRover,
                        Content = inputLine
                    };
                }
                else if (!string.IsNullOrEmpty(inputLine)) // empty string is fine to ignore
                {
                    throw new ArgumentException($"Unable to interpret line {i} of input. Line: {inputLine}");
                }
            }
        }

        /// <summary>
        /// Executes a fleet instruction
        /// </summary>
        /// <param name="instruction">The instruction.</param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        protected override void Execute(FleetInstruction instruction)
        {
            if (instruction.Type != InstructionType.SetTerrain)
            {
                if (Terrain == null)
                {
                    throw new InvalidOperationException(
                        $"Unable to execute instruction: {instruction}. Terrain has not been set");
                }
            }
            
            switch (instruction.Type)
            {
                case InstructionType.SetTerrain:
                    // extract the terrain from the instruction
                    Terrain = ExtractTerrain(instruction.Content);
                    break;
                case InstructionType.DeployRover:
                    DeployRover(instruction.Content);
                    break;
                case InstructionType.InstructRover:
                    InstructRover(instruction.Content);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        /// <summary>
        /// Get an instance of a rover for deployment
        /// </summary>
        /// <param name="roverStatus"></param>
        /// <returns>A rover instance.</returns>
        protected abstract TRover GetRoverInstance(TStatus roverStatus);
        
        /// <summary>
        /// Gets the active rover, to be instructed.
        /// </summary>
        /// <returns>The active rover instance.</returns>
        protected abstract TRover GetActiveRover();
        
        /// <summary>
        /// Extracts the rover status from the input
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The extracted status.</returns>
        protected abstract TStatus ExtractRoverStatus(string input);
        
        /// <summary>
        /// Extracts the terrain spec from the input
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The terrain spec.</returns>
        protected abstract TTerrain ExtractTerrain(string input);

        /// <summary>
        /// Deploy a rover to the environment
        /// </summary>
        /// <param name="instruction">The instruction corresponding to the initial rover status.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void DeployRover(string instruction)
        {
            // extract the initial rover status from the instruction
            var roverStatus = ExtractRoverStatus(instruction);

            // check the initial status isn't out of bounds
            if (Terrain.IsOutOfBounds(roverStatus))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(roverStatus),
                    $"The initial rover status is out of the bounds of the terrain. Status: {roverStatus}");
            }
                    
            // create a new rover and add it to the collection
            _rovers.Add(GetRoverInstance(roverStatus));
        }

        /// <summary>
        /// Issues an instruction to the active rover
        /// </summary>
        /// <param name="instruction">The instruction.</param>
        /// <exception cref="InvalidOperationException"></exception>
        private void InstructRover(string instruction)
        {
            if (Rovers.Count < 1)
            {
                throw new InvalidOperationException(
                    "There are no rovers deployed.");
            }

            var rover = ActiveRover;
            
            if (rover == null)
            {
                throw new InvalidOperationException(
                    "There are no active rovers");
            }

            rover.Receive(instruction);

            if (Terrain.IsOutOfBounds(rover.Status))
            {
                throw new InvalidOperationException(
                    "The specified command moves the rover to a position out of the bounds of the terrain.");
            }
            
            rover.CommandsProcessed++;
            rover.Ready = false;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var rover in Rovers)
            {
                sb.AppendLine(rover.Status.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}