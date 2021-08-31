namespace System
{
    public interface IValidatable
    {
        void Validate();
    }

    public interface IValidatable<in T>
    {
        void Validate(T input1);
    }
}