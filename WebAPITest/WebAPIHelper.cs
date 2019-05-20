using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace WebAPITest
{
    public class WebAPIHelper
    {
        /// <summary>
        /// 通过Post方式取得数据，不包含任何参数
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetResultByPost(string url)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;//创建请求
            request.Method = "POST";
            HttpWebResponse res;
            try
            {
                res = (HttpWebResponse)request.GetResponse(); //此处发送了请求并获得响应
            }
            catch (WebException ex)
            {
                res = (HttpWebResponse)ex.Response;
            }
            using (var sr = new StreamReader(res.GetResponseStream(), Encoding.UTF8))
            {
                string content = sr.ReadToEnd(); //响应转化为String字符串
                return content;
            }
        }
        /// <summary>
        /// 通过Post方式取得数据，包含参数
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetResultByPost(string url, IDictionary<string, string> parameters)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "POST";

            //File.AppendAllLines(@"d:\debug.txt", new[] {"URL::", url, string.Empty });

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {

                string json = JsonConvert.SerializeObject(parameters);

                //File.AppendAllLines(@"d:\debug.txt", new[] { "POST BODY JSON::", json, string.Empty });

                streamWriter.Write(json);

            }

            var response = (HttpWebResponse)request.GetResponse();

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {

                var rst = streamReader.ReadToEnd();

                //File.AppendAllLines(@"d:\debug.txt", new[] { "Result::", rst, string.Empty });

                return rst;
            }
        }
    }
}
