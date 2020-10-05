using DesignPatterns.Creational.Builder.Domain;

namespace DesignPatterns.Creational.Builder.Director
{
    public class PhoneBuildingSpecifications : IBuildingSpecifications
    {
        public string Model { get; set; }
        public Os Os { get; set; }
    }
}