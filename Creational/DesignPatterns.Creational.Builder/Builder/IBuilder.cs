namespace DesignPatterns.Creational.Builder.Builder
{
    public interface IBuilder<T>
    {
        void Reset();

        T Build();
    }
}
