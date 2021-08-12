using System.Threading.Tasks;

namespace System
{
    public interface IAsyncValidatable
    {
        ValueTask ValidateAsync();
    }
}