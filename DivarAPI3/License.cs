using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.VisualBasic;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;
namespace DivarAPI3
{
    class License
    {
        string apiURL;
        static string ID= "1602773814";
        static string licenseURL = "https://mjmi.ir/Panel/Licence/api";
        static string filePath=@"C:\test.txt";
        public static string RegisterEmail{
            get
            {
                return Properties.Settings.Default.email;
            }
            set
            {
                Properties.Settings.Default.email = value;
                Properties.Settings.Default.Save();
            }
        }

        public static void ChangeRegisterMail()

        {

            string message, title, defaultValue;
            string myValue;
            // Set prompt.
            message = "please input your email for registeration";
            // Set title.
            title = "Register";
            // Set default value.
            defaultValue = "test@test.ir";//Display message, title, and default value.
            RegisterEmail =Interaction.InputBox(message, title, defaultValue, 100, 100);// If user has clicked Cancel, set myValue to defaultValue 

        }
        public License()
        {


        }

        public static Boolean CheckInternetLicense()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            Boolean validLicense = false;

            //var client = new RestSharp.RestClient(apiURL);
            //client.Timeout = -1;
            //var request = new RestRequest(Method.POST);
            //request.AlwaysMultipartFormData = true;
            //request.AddParameter("ID", "1602773814");
            //request.AddParameter("Email", "sdf@sdf.sdf");
            //request.AddParameter("Action", "Check");
            //IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);





            WebClient client = new WebClient();
            client.QueryString.Add("ID", ID);
            client.QueryString.Add("Email", RegisterEmail);
            client.QueryString.Add("Action", "Check");
            var response=client.UploadValues(licenseURL, "POST", client.QueryString);




            var responseString = UnicodeEncoding.UTF8.GetString(response);
            JObject j = JObject.Parse(responseString);
            string status = j["status"].ToString();
            if (status == "200") validLicense = true;
            else ChangeRegisterMail();
            return validLicense;

        }

        public static Boolean CheckFileLincense()
        {
            
            bool result= File.Exists(filePath);
            return result;

        }
        
        public static Boolean CheckLicense()
        {
            Boolean internetLicense = License.CheckInternetLicense();
            Boolean fileLicense = License.CheckFileLincense();
            if (internetLicense && fileLicense) return true;
            else
            {
                System.Windows.Forms.MessageBox.Show("not valid license");
                return false;
            }
        }


    }
}
