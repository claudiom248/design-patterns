namespace DesignPatterns.Creational.Builder.Builder
{
    public interface IBuilder<out T>
    {
        void Reset();

        T Build();
    }
}