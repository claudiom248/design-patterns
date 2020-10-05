using System;

namespace DesignPatterns.Creational.Builder.Domain
{
    public class Phone
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public Os Os { get; set; }

        public override bool Equals(object obj)
            => obj is Phone other &&
               Make == other.Make &&
               Model == other.Model &&
               (
                   ReferenceEquals(Os, other.Os) ||
                   Os != null && Os.Equals(other.Os)
               );

        public override int GetHashCode() => HashCode.Combine(Make, Model, Os);
    }
}