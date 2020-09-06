using System.Text;

namespace DesignPatterns.Creational.Builder.Domain
{
    public class Phone
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public Os Os { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Make: {Make}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"Os: {Os}");

            return sb.ToString();
        }
    }
}
