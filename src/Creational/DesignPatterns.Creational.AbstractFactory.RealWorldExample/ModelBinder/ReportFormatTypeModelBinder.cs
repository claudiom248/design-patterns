using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.ModelBinder
{
    public class ReportFormatTypeModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var original = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (original != ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            var format = original.FirstValue;
            FileFormatType result = null;

            if (format == FileFormatType.Csv.Extension)
            {
                result = FileFormatType.Csv;
            }
            else if (format == FileFormatType.Pdf.Extension)
            {
                result = FileFormatType.Pdf;
            }

            if (format != null)
            {
                bindingContext.Result = ModelBindingResult.Success(result);
            }

            return Task.CompletedTask;
        }
    }
}