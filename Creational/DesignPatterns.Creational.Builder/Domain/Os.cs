using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Creational.Builder.Domain
{
    public class Os
    {
        public string Name { get; set; }

        public string Version { get; set; }

        public IEnumerable<string> SystemApps { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Os os &&
                   Name == os.Name &&
                   Version == os.Version &&
                   SystemApps.Count() == os.SystemApps.Count() && SystemApps.All(os.SystemApps.Contains);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Version, SystemApps);
        }
    }
}
