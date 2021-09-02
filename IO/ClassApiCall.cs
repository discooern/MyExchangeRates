using System;
using System.Collections.Generic;
using IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace IO
{
    public class ClassApiCall
    {
        public ClassApiCall()
        {
            
        }
        protected async Task<string> GetDataFromWebApiAsync(string inURL)
        {
            var content = new MemoryStream();
            var webReq = (HttpWebRequest)WebRequest.Create(inURL);
            using (WebResponse response = await webReq.GetResponseAsync())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    await responseStream.CopyToAsync(content);
                }
            }

            return Encoding.UTF8.GetString(content.ToArray());
        }
    }
}
