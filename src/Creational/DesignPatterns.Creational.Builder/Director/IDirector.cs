using DesignPatterns.Creational.Builder.Builder;

namespace DesignPatterns.Creational.Builder.Director
{
    public interface IDirector<TBuilder, out TElement, in TBuildingSpecifications>
        where
            TBuilder : IBuilder<TElement>
        where
            TBuildingSpecifications : IBuildingSpecifications
    {
        TBuilder Builder { get; set; }

        void Construct(TBuildingSpecifications specs);

        TElement Get();
    }
}
