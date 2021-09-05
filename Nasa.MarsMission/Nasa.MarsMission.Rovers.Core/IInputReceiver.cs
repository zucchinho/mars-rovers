using Nasa.MarsMission.Rovers.Core.Description;

namespace Nasa.MarsMission.Rovers.Core
{
    /// <summary>
    /// Represents an entity which will receive input
    /// </summary>
    /// <typeparam name="TInput">The type of input.</typeparam>
    public interface IInputReceiver<in TInput>
    {
        /// <summary>
        /// Receives input and attempts to process it
        /// </summary>
        /// <param name="input">The input object.</param>
        /// <returns>The receiver for chaining.</returns>
        IInputReceiver<TInput> Receive(TInput input);
    }
}