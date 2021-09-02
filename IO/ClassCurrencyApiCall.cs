using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Repository;

namespace IO
{
    public class ClassCurrencyApiCall : ClassApiCall
    {
        public ClassCurrencyApiCall()
        {

        }
        public async Task<ClassExchangeRates> GetApiData()
        {
            string strUrl = $"https://openexchangerates.org/api/latest.json?app_id=1795115851644ffeaaf958c8352f7e83&base=USD";
            
            string apiResponse = await GetDataFromWebApiAsync(strUrl);
            ClassExchangeRates cer = JsonConvert.DeserializeObject<ClassExchangeRates>(apiResponse);

            return cer;
        }
    }
}
