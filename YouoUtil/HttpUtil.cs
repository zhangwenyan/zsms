using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;

namespace YouoUtil
{
    /// <summary>
    /// http工具类
    /// </summary>
    public class HttpUtil
    {


        public static String doPost(String url, String postStr)
        {
            return doPost(new HttpPack(url) { postStr = postStr });
        }
        public static String doPost(String url, String postStr, CookieContainer cookieContainer)
        {
            return doPost(new HttpPack(url) { postStr = postStr, cookieContainer = cookieContainer });
        }
        /// <summary>
        /// 进行http请求
        /// </summary>
        /// <param name="pack"></param>
        /// <returns></returns>
        public static String doPost(HttpPack pack)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(pack.url);
            Encoding encoding = Encoding.UTF8;
            //encoding.GetBytes(postData);
            byte[] bs = Encoding.ASCII.GetBytes(pack.postStr);
            string responseData = String.Empty;
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = bs.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
                reqStream.Close();
            }

            using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), encoding))
                {
                    responseData = reader.ReadToEnd().ToString();
                }
                return responseData;
            }

        }


        /// <summary>
        /// 进行get访问
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static String doGet(String url)
        {
            return doGet(new HttpPack(url));
        }

        /// <summary>
        /// 进行get访问
        /// </summary>
        /// <param name="pack"></param>
        /// <returns></returns>
        public static String doGet(HttpPack pack)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(pack.url);
            request.Method = "GET";
            if (pack.cookieContainer != null)
            {
                request.CookieContainer = pack.cookieContainer;
            }
            if (pack.ContentType != null)
            {
                request.ContentType = pack.ContentType;
            }
            if (pack.headers != null)
            {
                foreach (HeaderModel header in pack.headers)
                {
                    request.Headers.Add(header.key, header.value);
                }
            }


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = null;
            if ((response.Headers["content-encoding"] != null) &&
               (response.Headers["content-encoding"].ToLower() == "gzip"))
            {
                resStream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
            }
            else
            {
                resStream = response.GetResponseStream();
            }
            StreamReader sr = new StreamReader(resStream);
            return sr.ReadToEnd();
        }
    }

    public class HttpPack
    {
        public HttpPack(String url)
        {
            this.url = url;
            headers = new List<HeaderModel>();
        }
        public String url { get; set; }
        /// <summary>
        /// post提交的数据，仅对post提交有效
        /// </summary>
        public String postStr { get; set; }
        /// <summary>
        /// 默认
        /// </summary>
        public String ContentType { get; set; }
        public CookieContainer cookieContainer { get; set; }

        public List<HeaderModel> headers { get; set; }

    }

    public class HeaderModel
    {
        public String key { get; set; }
        public String value { get; set; }
    }
}
