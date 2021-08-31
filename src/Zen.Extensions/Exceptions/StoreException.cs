using System.Diagnostics.CodeAnalysis;

namespace System
{
    [Serializable]
    public class StoreException : Exception
    {
        public StoreException([NotNull] string message) : base(message)
        {

        }

    }
}