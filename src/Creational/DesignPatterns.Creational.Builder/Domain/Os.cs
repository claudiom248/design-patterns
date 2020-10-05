using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Creational.Builder.Domain
{
    public class Os
    {
        public string Name { get; set; }

        public string Version { get; set; }

        public List<string> Apps { get; set; }

        public override bool Equals(object obj)
            => obj is Os os &&
               Name == os.Name &&
               Version == os.Version &&
               Apps.Count == os.Apps.Count && Apps.All(os.Apps.Contains);

        public override int GetHashCode() => HashCode.Combine(Name, Version, Apps);
    }
}