using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Creational.Builder.Domain
{
    public class Os
    {
        public string Name { get; set; }

        public string Version { get; set; }

        public IEnumerable<string> SystemApps { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Version: {Version}");

            return sb.ToString();
        }
    }
}
