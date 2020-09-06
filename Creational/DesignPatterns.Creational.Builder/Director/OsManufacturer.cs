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
            throw new System.NotImplementedException();
        }

        public TElement Get()
        {
            throw new System.NotImplementedException();
        }
    }
}
