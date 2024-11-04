using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Ecommerce.Service.AuthAPI.Dtos
{
    public class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter(string format)
        {
            DateTimeFormat = format;
        }

    }
}