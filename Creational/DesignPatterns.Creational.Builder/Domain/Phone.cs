using System;

namespace DesignPatterns.Creational.Builder.Domain
{
    public class Phone
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public Os Os { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Phone phone &&
                   Make == phone.Make &&
                   Model == phone.Model &&
                   Os.Equals(phone.Os);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Make, Model, Os);
        }
    }
}
