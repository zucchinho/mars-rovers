using Nasa.MarsMission.Rovers.Core.Description;

namespace Nasa.MarsMission.Rovers.Core
{
    public interface IInputReceiver<in TInput>
    {
        /// <summary>
        /// Receives a command and tries to process it
        /// </summary>
        /// <param name="input">The input object.</param>
        /// <returns>The receiver for chaining.</returns>
        IInputReceiver<TInput> Receive(TInput input);
    }
}