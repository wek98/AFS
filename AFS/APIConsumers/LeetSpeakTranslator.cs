using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AFS.APIConsumers
{
    public class LeetSpeakConsumer : ITranslator
    {

        /// <summary>
        /// Function that returns JSON of leet speak translation from userInput.
        /// Connection with funtranslations.com
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        public string GetLeetTextJSON(string userInput)
        {
            var builder = new UriBuilder("https://api.funtranslations.com/translate/leetspeak.json");
            var query = System.Web.HttpUtility.ParseQueryString(builder.Query);
            query["text"] = userInput;
            builder.Query = query.ToString();
            var uri = builder.Uri;
            using var client = new HttpClient();

            var responseTask = client.GetAsync(uri);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.StatusCode == HttpStatusCode.OK)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                return readTask.Result;
            }
            else
                return "Too much requests";
        }

        /// <summary>
        /// Function that gets translated string from inputJSON
        /// </summary>
        /// <param name="inputJSON"></param>
        /// <returns></returns>
        public string GetLeetText(string inputJSON)
        {
            if (inputJSON.Equals("Too much requests"))
                return "Too much requests! Try again later.";
            JObject jObject = JObject.Parse(inputJSON);
            string leetText = (string)jObject.SelectToken("contents.translated");
            return leetText;
        }


        public string Translate(string inputString)
        {
            return GetLeetText(GetLeetTextJSON(inputString));
        }
    }
}

