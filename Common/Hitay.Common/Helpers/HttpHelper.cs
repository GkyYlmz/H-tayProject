using Hitay.Common.Enums;
using Hitay.Common.Enums.General;
using System.IO;
using System.Net;
using System.Text;

namespace Hitay.Common.Helpers
{
    public class HttpHelper
    {
        /// <summary>
        /// verilen urle get işlemi uygular cevabı T tipine çevirir.
        /// </summary>
        /// <param name="url">String url</param>
        /// <returns>T</returns>
        public static T Get<T>(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString.FromJson<T>();
        }

        /// <summary>
        /// verilen urle, verilen entityi post eder cevabı R tipine çevirir.
        /// </summary>
        /// <param name="entity">T entity</param>
        /// <param name="url">String url</param>
        /// <returns>R</returns>
        public static R Post<R, T>(T entity, string url, HttpContentTypeEnum type = HttpContentTypeEnum.ApplicationJson)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            var postString = entity.ToJson();
            var postData = Encoding.UTF8.GetBytes(postString);

            request.Method = HttpMethodEnum.Post.Description();
            request.ContentType = type.Description();
            request.ContentLength = postData.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(postData, Int.Zero, postData.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString.FromJson<R>();
        }
    }
}
