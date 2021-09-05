using System.Collections.Generic;

namespace Nasa.MarsMission.Rovers.Core
{
    public abstract class InputReceiverBase<TExecutable, TInput> : IInputReceiver<TInput>
    {
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
        /// Executes a defined action
        /// </summary>
        /// <param name="action">The action object.</param>
        protected abstract void Execute(TExecutable action);
        
        /// <summary>
        /// Interprets input as a sequence of executable actions
        /// </summary>
        /// <param name="input">The input object.</param>
        /// <returns></returns>
        protected abstract IEnumerable<TExecutable> Interpret(TInput input);
    }
}