using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace System
{
    public interface IAsyncStore<T>
    {
        ValueTask StoreAsync([NotNull] T data);
    }
}