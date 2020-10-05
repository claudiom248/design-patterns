namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain
{
    public class FileFormatType
    {
        private FileFormatType(string extension) => Extension = extension;

        public static FileFormatType Csv => new FileFormatType("csv");
        public static FileFormatType Pdf => new FileFormatType("pdf");

        public string Extension { get; }
    }
}