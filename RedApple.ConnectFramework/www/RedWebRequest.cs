using Newtonsoft.Json;
using RedApple.ConnectFramework.www.exception;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace RedApple.ConnectFramework.www
{

    /// <summary>
    /// RedWebRequest HttpWebRequest kullanarak post ve get methodlarında web istekleri yapmamızı sağlar
    /// </summary>
    public class RedWebRequest : IRedWebRequest
    {
        HttpWebRequest _reuest;
        private string _token;
        public RedWebRequest()
        {

        }
        public RedWebRequest(string token)
        {
            this._token = token;
        }

        
        public void Dispose()
        {

        }

        public string Get(string url)
        {
            _reuest = (HttpWebRequest)WebRequest.Create(url);
            _reuest.Method = "GET";

            if (!string.IsNullOrEmpty(_token))
                _reuest.Headers.Add("Authorization", "Bearer " + _token);

            _reuest.Accept = "application/json";

            var httpResponse = (HttpWebResponse)_reuest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    return result;
                }
                else
                    throw new RedAppleRequestException(result, httpResponse.StatusCode);

            }
        }

        public T Get<T>(string url)
        {
            _reuest = (HttpWebRequest)WebRequest.Create(url);
            _reuest.Method = "GET";

            if (!string.IsNullOrEmpty(_token))
                _reuest.Headers.Add("Authorization", "Bearer " + _token);

            _reuest.Accept = "application/json";
            var httpResponse = (HttpWebResponse)_reuest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<T>(result);
                }
                else
                    throw new RedAppleRequestException(result, httpResponse.StatusCode);

            }
        }

        public string PostContentJson(string url, string jsonContent)
        {
            _reuest = (HttpWebRequest)WebRequest.Create(url);
            _reuest.ContentType = "application/json";
            _reuest.Method = "POST";
            if (!string.IsNullOrEmpty(_token))
                _reuest.Headers.Add("Authorization", "Bearer " + _token);
            using (var streamWriter = new StreamWriter(_reuest.GetRequestStream()))
            {

                streamWriter.Write(jsonContent);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)_reuest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    return result;
                }
                else
                    throw new RedAppleRequestException(result, httpResponse.StatusCode);

            }
        }

        public T PostContentJson<T>(string url, string jsonContent)
        {
            _reuest = (HttpWebRequest)WebRequest.Create(url);
            _reuest.ContentType = "application/json";
            _reuest.Method = "POST";
            if (!string.IsNullOrEmpty(_token))
                _reuest.Headers.Add("Authorization", "Bearer " + _token);
            using (var streamWriter = new StreamWriter(_reuest.GetRequestStream()))
            {

                streamWriter.Write(jsonContent);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)_reuest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<T>(result);
                }
                else
                    throw new RedAppleRequestException(result, httpResponse.StatusCode);

            }
        }

        public void SetAuthorizedHeader(string authorizeKey, string authorizedValue)
        {
            this._token = authorizedValue;
        }
    }


}
