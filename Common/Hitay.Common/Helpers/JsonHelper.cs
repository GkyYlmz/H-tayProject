using Hitay.Common.Constatns;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Hitay.Common.Helpers
{
    public static class JsonHelper
    {
        /// <summary>
        /// verilen object value değerini json a çevirir. Hata alırsa string.empty çevirir.
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>string</returns>
        public static string ToJson(this object value)
        {
            try
            {
                return JsonConvert.SerializeObject(value, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// verilen string json değerini T tipine çevirir. Hata alırsa default(T) çevirir.
        /// </summary>
        /// <param name="json">string json</param>
        /// <returns>T</returns>
        public static T FromJson<T>(this string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json, new IsoDateTimeConverter() { DateTimeFormat = GeneralConstants.JsonDateFormat });
            }
            catch
            {
                return default(T);
            }
        }
    }
}
