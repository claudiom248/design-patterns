using DesignPatterns.Creational.Builder.Builder.Phone;
using DesignPatterns.Creational.Builder.Domain;

namespace DesignPatterns.Creational.Builder.Director
{
    public class PhoneStore<TBuilder, TElement> : IDirector<TBuilder, TElement, PhoneBuildingSpecifications>
        where
        TElement : Phone
        where
        TBuilder : PhoneBuilder<TElement>
    {
        public TBuilder Builder { get; set; }

        public void Construct(PhoneBuildingSpecifications specs)
            => Builder
                .WithMake()
                .WithModel(specs.Model)
                .WithOs(specs.Os);

        public TElement Get()
        {
            var product = Builder.Build();
            Builder.Reset();

            return product;
        }
    }
}