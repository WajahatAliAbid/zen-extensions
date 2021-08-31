using System.Threading.Tasks;

namespace System
{
    public interface IAsyncValidatable
    {
        ValueTask ValidateAsync();
    }

    public interface IAsyncValidatable<in T>
    {
        ValueTask ValidateAsync(T input);
    }
}