using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Tungsten.HttpRequests.Interfaces;

namespace Tungsten.HttpRequests.Concetes
{
    public class TungstenRequester : ITungstenHttpRequest
    {
        public string Request(string url, Method method)
        {
            var request = (HttpWebRequest)HttpWebRequest.Create(url);
            try
            {
                switch (method)
                {
                    case Method.Get:
                        request.Method = "GET";
                        request.KeepAlive = false;
                        request.Timeout = 60000;
                        using (var outputStream = (request.GetResponse() as HttpWebResponse).GetResponseStream())
                        {
                            using (var stream = new StreamReader(outputStream))
                            {
                                return stream.ReadToEnd();
                            }
                        }
                    case Method.Post:
                        //Not Implemented
                        return null;
                    default:
                        return null;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
