using System;

namespace Zen.Core.Interfaces
{
    public interface IMapper<out TResult>
    {
        TResult Map();
    }

    public interface IMapper<in T1, out TResult>
    {
        TResult Map(T1 input1);
    }

    public interface IMapper<in T1, in T2, out TResult>
    {
        TResult Map(T1 input1, T2 input2);
    }
}