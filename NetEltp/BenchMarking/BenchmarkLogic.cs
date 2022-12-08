using RestSharp;
using System.Net;
namespace BenchMarking
{
    public class BenchmarkLogic
    {
        public string restrequest()
        {
            RestClient client = new RestClient("http://api.ipapi.com/api/103.129.97.63?access_key=ba22e041405f597bf03914c669f00a4a");
            client.= -1;
            var request = new RestRequest(Method.Get);
            IRestResponse response = client.Execute(request);
            return null;
        }
        public string webrequest()
        {
            var url = "http://api.ipapi.com/api/103.129.97.63?access_key=ba22e041405f597bf03914c669f00a4a";
            HttpWebRequest WebRequestObject = (HttpWebRequest)HttpWebRequest.Create(url);
            WebResponse Response = WebRequestObject.GetResponse();
            Stream WebStream = Response.GetResponseStream();
            StreamReader Reader = new StreamReader(WebStream);
            string webcontent = Reader.ReadToEnd();
            return null;
        }
    }
}
