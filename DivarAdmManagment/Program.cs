﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using System.Text;
namespace DivarAdManagment
{
    enum State
    {
        WaitForAporve = 1,
        InQue = 2,
        Apprive = 3,
        WaitForPayment=4,
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
        const string postStatusWaitForPayment = "منتظر پرداخت";
        const string postDeleted = "حذف شده";




        private string _title, _date, _token,_management_token;
        private int _postTime;
        private State _statusCode =State.Other;

        public string token => _token;

        // new syntax for properties
        public string managementToken => _management_token;
        public int postTime => _postTime;

        public State statusCode => _statusCode;
        public DivarPost(string title,string manageToken, string token,State status,int postTime)
        {
            this._title = title;
            this._token = token;
            this._management_token = manageToken;
            this._statusCode = status;
            this._postTime = postTime;

        }
        public override string ToString()=> this._management_token;




        public static State GetStatusCode(string postStatus)
        {
            if ( postStatus==postStatusWaitForAprove)  return State.WaitForAporve;
            if (postStatus == postStatusInQueue)  return State.InQue;
            if (postStatus == postStatusApprove) return State.Apprive;
            if (postStatus == postStatusWaitForPayment) return State.WaitForPayment;
            else { return State.Other; }



        }
    }

    class Divar
    {
        public static WebClient client;
        public string accessToken;
        public static List<string> badTokens;
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


        public List<DivarPost> GetPosts()
        {
            this.Posts = GetData(this.accessToken);
            return this.Posts;
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
                    string persianTempTime = item["data"]["date"].ToString();

                    State newPostStatus = DivarPost.GetStatusCode(persianTempStatus);
                    int postTime = PublishTime.TimeToCode(persianTempTime);
                    DivarPost currentDivarPost = new DivarPost(newPostTitle, newPostToken, accessToken, newPostStatus, postTime);
             
                    posts.Add(currentDivarPost);
                }

                return posts;

            }
            catch (Exception)
            {

                return posts;
            }
           



        }


        public static void AproveAdvertisement(string accessToken, string managmentToken)
        {
            string aproveUrl = String.Format("https://api.divar.ir/v8/ongoingposts/{0}/claim", managmentToken);
            
            try
            {
                client.Headers.Remove("Authorization");
                client.Headers.Add("Authorization", "Bearer " + accessToken);
                string result = client.UploadString(aproveUrl, "");
            }
            catch (Exception)
            {

                MessageBox.Show("error in  send approve request");
            }
           

        }


        public static void DeleteAdvertisment(string accessToken,string managmentToken)
        {
            string deleteUrl = string.Format("https://api.divar.ir/v8/ongoingposts/{0}", managmentToken);
            string fullUrl = string.Format("{0}?answer=&question_tag=note&reason=R", deleteUrl);
            try
            {
                client.Headers.Remove("Authorization");
                client.Headers.Add("Authorization", "Bearer " + accessToken);
                client.UploadString(fullUrl, "DELETE","");
            }
            catch (Exception)
            {
                MessageBox.Show("error in deete advertismet api");

            }

            //string result = client.DownloadString(fullUrl);
        }

        public static void ApproveAdveretismentList(int DelayTime, List<DivarPost> postlists)
        {
            foreach (DivarPost post in postlists)
            {
                if (post.statusCode != State.WaitForAporve) continue;
                try
                {

                    AproveAdvertisement(post.token, post.managementToken);
                   
                }
                catch (Exception)
                {


                }
            }
        }
        public async void AproveAllAdvertisment(int DelayTime)
        {
            ApproveAdveretismentList(DelayTime, this.Posts);
        }
        public static void DeleteAdvertismentList(int type,int deleteTime,List<DivarPost> postlists)
        {

            badTokens = new List<string>();
            foreach (DivarPost post in postlists)
            {

 
                try
                {


                    State currentPostState = post.statusCode;
                    if (type>3) DeleteAdvertisment(post.token, post.managementToken);
                    if (type == 1 && currentPostState == State.InQue) DeleteAdvertisment(post.token, post.managementToken);
                    if (type == 3) DeleteAdvertisment(post.token, post.managementToken);

                    if (post.postTime < deleteTime) continue;

                    if (type == 2 && currentPostState == State.Apprive) DeleteAdvertisment(post.token, post.managementToken);


                }
                catch (Exception)
                {
                    badTokens.Add(post.token);

                }

            }
        }

        public void DeleteAllAdevertisment(int type,int deleteTime)
        {
            DeleteAdvertismentList(type, deleteTime, this.Posts);
        }
    }



    public static class Messages
    {
        const string ready = "plese select your excel file";

    }
}
