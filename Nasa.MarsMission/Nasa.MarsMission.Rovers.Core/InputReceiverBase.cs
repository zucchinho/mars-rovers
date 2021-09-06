using System.Collections.Generic;

namespace Nasa.MarsMission.Rovers.Core
{
    /// <summary>
    /// An entity that will receive and interpret input,
    /// subsequently executing the interpreted actions
    /// </summary>
    /// <typeparam name="TExecutable">The type of executable, usually an action to perform.</typeparam>
    /// <typeparam name="TInput">The type of input.</typeparam>
    public abstract class InputReceiverBase<TExecutable, TInput> : IInputReceiver<TInput>
    {
        /// <summary>
        /// Receives input and attempts to process it,
        /// interpreting then executing the interpreted actions
        /// </summary>
        /// <param name="input">The input object.</param>
        /// <returns>The receiver for chaining.</returns>
        public IInputReceiver<TInput> Receive(TInput input)
        {
            var actions = Interpret(input);

            foreach (var action in actions)
            {
                Execute(action);
            }

            return this;
        }

        /// <summary>
        /// Interprets input as a sequence of executable segments
        /// </summary>
        /// <param name="input">The input object.</param>
        /// <returns>The executable segments.</returns>
        protected abstract IEnumerable<TExecutable> Interpret(TInput input);

        /// <summary>
        /// Executes a defined segment of input
        /// </summary>
        /// <param name="executable">The action object.</param>
        protected abstract void Execute(TExecutable executable);
    }
}