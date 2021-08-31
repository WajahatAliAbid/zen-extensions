namespace System
{
    public interface IValidatableType
    {
        void Validate();
    }

    public interface IValidatableType<in T>
    {
        void Validate(T input1);
    }
}