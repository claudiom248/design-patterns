using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.ModelBinder
{
    public class ReportFormatTypeModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context) 
            => typeof(FileFormatType).IsAssignableFrom(context.Metadata.ModelType)
                ? new ReportFormatTypeModelBinder()
                : null;
    }
}
