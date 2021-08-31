namespace System
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

    public interface IMapper<in T1, in T2, in T3, out TResult>
    {
        TResult Map(T1 input1, T2 input2, T3 input3);
    }
}