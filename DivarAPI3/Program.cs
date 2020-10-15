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
    enum State
    {
        WaitForAporve = 1,
        InQue = 2,
        Apprive = 3,
        Other = 0,

    }
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

        const string postStatusWaitForAprove = "منتظر تایید شماره";
        const string postStatusInQueue = "در صف انتشار";
        const string postStatusApprove = "منتشر شده";
        const string postDeleted = "حذف شده";


        private string _title, _date, _token,_management_token;
        private State _statusCode =State.Other;
        
        public string token
        {
            get { return _token; }
        }

        public string managementToken
        {
            get { return _management_token; }
        }

        public State statusCode
        {
            get
            {
                return _statusCode;
            }
        }
        public DivarPost(string title,string manageToken, string token,State status)
        {
            this._title = title;
            this._token = token;
            this._management_token = manageToken;
            this._statusCode = status;

        }
        public override string ToString()
        {
            return this._management_token;
        }



        public static State GetStatusCode(string postStatus)
        {
            if ( postStatus==postStatusWaitForAprove)  return State.WaitForAporve;
            if (postStatus == postStatusInQueue)  return State.InQue;
            if (postStatus == postStatusApprove) return State.Apprive;
            else { return State.Other; }



        }
    }

    class Divar
    {
        public static WebClient client;
        public string accessToken;

        public List<DivarPost> Posts;



        public Divar(string accessToken)
        {
            client = new WebClient();
            this.accessToken = accessToken;

            client.Encoding = Encoding.UTF8;
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; " +
                      "Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Headers.Add("Authorization", "Bearer " + accessToken);
            Posts = new List<DivarPost>();
        }


        public void GetPosts()
        {
            this.Posts = GetData(this.accessToken);
        }

        public static List<DivarPost> GetData(string accessToken)
        {
            List<DivarPost> posts = new List<DivarPost>();

            string getPostUrl = "https://api.divar.ir/v8/ongoingposts/userposts";
            try
            {
                string result = client.DownloadString(getPostUrl);
                JObject j = JObject.Parse(result);

                foreach (var item in j["widget_list"])
                {
                    string newPostTitle = item["data"]["title"].ToString();
                    string newPostToken = item["data"]["manage_token"].ToString();
                    string persianTempStatus = item["data"]["status"].ToString();
                    State newPostStatus = DivarPost.GetStatusCode(persianTempStatus);
                    DivarPost currentDivarPost = new DivarPost(newPostTitle, newPostToken, accessToken, newPostStatus);
             
                    posts.Add(currentDivarPost);
                }

                return posts;

            }
            catch (Exception)
            {

                return posts;
            }
           



        }


        public void AproveAdvertisement(string accessToken, string managmentToken)
        {
            string aproveUrl = String.Format("https://api.divar.ir/v8/ongoingposts/{0}/claim", managmentToken);
            
            try
            {
                string result = client.UploadString(aproveUrl, "");
            }
            catch (Exception)
            {

                
            }
           

        }


        public void DeleteAdvertisment(string accessToken,string managmentToken)
        {
            string deleteUrl = string.Format("https://api.divar.ir/v8/ongoingposts/{0}", managmentToken);
            string fullUrl = string.Format("{0}?answer=&question_tag=note&reason=R", deleteUrl);
            try
            {
                client.UploadString(fullUrl, "DELETE","");
            }
            catch (Exception)
            {

                
            }

            //string result = client.DownloadString(fullUrl);
        }


        public void AproveAllAdvertisment()
        {
            foreach (DivarPost post in this.Posts)
            {
                try
                {
                    AproveAdvertisement(post.token, post.managementToken);
                }
                catch (Exception)
                {

                    
                }
            }
        }

        public void DeleteAllAdevertisment(int type)
        {
            foreach (DivarPost post in this.Posts)
            {
                try
                {
                    State currentPostState = post.statusCode;
                    if (type == 1 && currentPostState == State.InQue)  DeleteAdvertisment(post.token, post.managementToken);
                    if (type == 2 && currentPostState == State.Apprive)  DeleteAdvertisment(post.token, post.managementToken);
                    if (type == 3)  DeleteAdvertisment(post.token, post.managementToken);

                }
                catch (Exception)
                {

                    
                }

            }    
        }
    }



    public static class Messages
    {
        const string ready = "plese select your excel file";

    }
}
