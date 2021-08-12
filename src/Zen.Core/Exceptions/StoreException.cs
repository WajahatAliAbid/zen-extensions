using System;
using System.Diagnostics.CodeAnalysis;

namespace Zen.Core.Exceptions
{
    [Serializable]
    public class StoreException : Exception
    {
        public StoreException([NotNull] string message) : base(message)
        {

        }

    }
}