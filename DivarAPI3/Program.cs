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
        private string _title, _date, _token,_management_token;
        
        public string token
        {
            get { return _token; }
        }

        public string managementToken
        {
            get { return managementToken; }
        }
        public DivarPost(string title, string token,string manageToken)
        {
            this._title = title;
            this._token = token;
            this._management_token = manageToken;

        }
        public override string ToString()
        {
            return "_title ,_token".ToString();
        }
    }

    class Divar
    {
        public static WebClient client;
        public static string accessToken;

        List<DivarPost> Posts;

        public Divar()
        {
            client = new WebClient();
            client.Encoding = Encoding.UTF8;
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; " +
                      "Windows NT 5.2; .NET CLR 1.0.3705;)");
            //client.Headers[
            Posts = new List<DivarPost>();
        }


        public void GetPosts()
        {
            this.Posts = GetData();
        }


        public static List<DivarPost> GetData()
        {
           return GetData(accessToken);

        }
        public static List<DivarPost> GetData(string accessToken)
        {
            List<DivarPost> posts = new List<DivarPost>();

            string getPostUrl = "https://api.divar.ir/v8/ongoingposts/userposts";

            client.Headers.Add("Authorization", "Bearer " + accessToken);

            string result = client.DownloadString(getPostUrl);

            JObject j = JObject.Parse(result);

            foreach (var item in j["widget_list"])
            {
                string newPostTitle = item["data"]["title"].ToString();
                string newPostToken = item["data"]["manage_token"].ToString();

                DivarPost currentDivarPost = new DivarPost(newPostTitle, newPostToken,accessToken);

                posts.Add(currentDivarPost);


            }

            return posts;


        }


        public void AproveAdvertisement(string accessToken, string managmentToken)
        {
            string aproveUrl = String.Format("https://api.divar.ir/v8/ongoingposts/{}/claim", managmentToken);
                
            client.Headers.Add("Authorization", "Bearer " + accessToken);
            string result = client.DownloadString(aproveUrl);

        }


        public void DeleteAdvertisment(string accessToken,string managmentToken)
        {
            string deleteUrl = String.Format("https://api.divar.ir/v8/ongoingposts/{}", managmentToken);
            string fullUrl = String.Format("{}?answer=&question_tag=note&reason=R", deleteUrl);


            client.Headers.Add("Authorization", "Bearer " + accessToken);
            client.UploadString(fullUrl, "DELETE");

            string result = client.DownloadString(fullUrl);
        }


        public void DeleteAllAdevertisment()
        {
            foreach (DivarPost post in this.Posts)
            {
                try
                {
                    DeleteAdvertisment(post.token, post.managementToken);
                }
                catch (Exception)
                {

                    throw;
                }

            }    
        }
    }

    public static class Messages
    {
        const string ready = "plese select your excel file";
    }
}
