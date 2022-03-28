namespace Card_Sanctum.ModelBinders
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class DateTimeModelBinderProvider : IModelBinderProvider
    {
        private readonly string customDateTimeFormat;

        public DateTimeModelBinderProvider(string _customDateFormat)
        {
            customDateTimeFormat = _customDateFormat;
        }

        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(DateTime) || context.Metadata.ModelType == typeof(DateTime?))
            {
                return new DateTimeModelBinder(customDateTimeFormat);
            }

            return null;
        }
    }
}
