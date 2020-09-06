using DesignPatterns.Creational.Builder.Builder.Os;
using DesignPatterns.Creational.Builder.Domain;

namespace DesignPatterns.Creational.Builder.Director
{
    public class OsManufacturer<TBuilder, TElement> : IDirector<TBuilder, TElement, OsBuildingSpecifications>
        where
            TElement : Os
        where
            TBuilder : OsBuilder<TElement>
    {
        public TBuilder Builder { get; set; }

        public void Construct(OsBuildingSpecifications specs)
        {
            Builder
                .WithName(specs.Name)
                .WithVersion(specs.Version)
                .WithApps(specs.SystemApps);
        }

        public TElement Get()
        {
            var os = Builder.Build();
            Builder.Reset();
            return os;
        }
    }
}
