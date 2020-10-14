using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using System.Text;
namespace DivarAPI3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    class DivarPost
    {
        private string _title, _date, _token;
        public DivarPost(string title,string token)
        {
            this._title = title;
            this._token = token;

        }
        public override string ToString()
        {
            return "_title ,_token".ToString();
        }
    }

    class Divar
    {
        public static WebClient client;
        public Divar()
        {
            client = new WebClient();
            client.Encoding = Encoding.UTF8;
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; " +
                      "Windows NT 5.2; .NET CLR 1.0.3705;)");
            //client.Headers[
        }

        public List<DivarPost> GetData(string accessToken)
        {
            List<DivarPost> posts = new List<DivarPost>();

            string getPostUrl = "https://api.divar.ir/v8/ongoingposts/userposts";

            client.Headers.Add("Authorization", "Bearer " + accessToken);

            string result = client.DownloadString(getPostUrl);

            JObject j = JObject.Parse(result);

            foreach (var item in j["widget_list"])
            {
                string newPostTitle = item["data"]["title"].ToString();
                string newPostToken = item["data"]["token"].ToString();

                DivarPost currentDivarPost = new DivarPost(newPostTitle, newPostToken);

                posts.Add(currentDivarPost);

  
            }

            return posts;


        }
    }



}
