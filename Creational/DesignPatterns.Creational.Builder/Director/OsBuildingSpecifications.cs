using System.Collections.Generic;

namespace DesignPatterns.Creational.Builder.Director
{
    public class OsBuildingSpecifications : IBuildingSpecifications
    {
        public string Name { get; set; }

        public string Version { get; set; }

        public List<string> SystemApps { get; set; }
    }
}
