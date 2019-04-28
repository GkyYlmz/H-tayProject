using Hitay.Common.Constatns;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Hitay.API.Helper
{
    public static class ControllerHelper
    {
        public static HttpResponseMessage GetJsonResponseMessage(object obj)
        {
            HttpResponseMessage response = new HttpResponseMessage() { Content = new StringContent(JsonConvert.SerializeObject(obj, new IsoDateTimeConverter() { DateTimeFormat = GeneralConstants.JsonDateFormat }), Encoding.UTF8) };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(GeneralConstants.JsonContentType);

            return response;
        }
    }
}