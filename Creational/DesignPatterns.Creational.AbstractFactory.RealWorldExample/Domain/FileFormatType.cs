namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain
{
    public class FileFormatType
    {
        public static FileFormatType Csv => new FileFormatType("csv");
        public static FileFormatType Pdf => new FileFormatType("pdf");

        private FileFormatType(string extension) => Extension = extension;

        public string Extension { get; private set; }
    }
}
