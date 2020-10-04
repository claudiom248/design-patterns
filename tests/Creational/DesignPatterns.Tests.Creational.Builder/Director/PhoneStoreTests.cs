using DesignPatterns.Creational.Builder.Builder.Phone;
using DesignPatterns.Creational.Builder.Director;
using DesignPatterns.Creational.Builder.Domain;
using DesignPatterns.Tests.Creational.Builder.Common;
using Moq;
using NUnit.Framework;

namespace DesignPatterns.Tests.Creational.Builder.Director
{
    [TestFixture]
    public class PhoneStoreTests
    {
        private Mock<PhoneBuilder<Phone>> _builder;
        private PhoneStore<PhoneBuilder<Phone>, Phone> _director;

        [OneTimeSetUp]
        public void SetupFixture()
        {
            _builder = new Mock<PhoneBuilder<Phone>>();

            _director = new PhoneStore<PhoneBuilder<Phone>, Phone>
            {
                Builder = _builder.Object
            };
        }

        [Test]
        public void Construct_AssemblePhoneAccordingToSpecs()
        {
            var specs = new PhoneBuildingSpecifications
            {
                Model = "Model1",
                Os = OsDataProvider.Android10
            };

            _builder.Setup(x => x.WithMake()).Returns(_builder.Object);
            _builder.Setup(x => x.WithModel(It.IsAny<string>())).Returns(_builder.Object);
            _builder.Setup(x => x.WithOs(It.IsAny<Os>())).Returns(_builder.Object);

            _director.Construct(specs);

            _builder.Verify(x => x.WithMake(), Times.Once());
            _builder.Verify(x => x.WithModel(It.Is<string>(p => p == specs.Model)), Times.Once());
            _builder.Verify(x => x.WithOs(It.Is<Os>(p => Equals(p, specs.Os))), Times.Once());
        }

        [Test]
        public void Get_CallsReset()
        {
            _director.Get();

            _builder.Verify(x => x.Build(), Times.Once());
            _builder.Verify(x => x.Reset(), Times.Once());
        }
    }
}
