using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace DivarAPI3
{

    public partial class Form1 : Form
    {

        static Divar divarInstance;
        MyExcel refrenceDataBase;
        List<string> tokens=new List<string>();
        List<DivarPost> publishList;
        int deletType = 2;
        static string operationType = "APPROVE";
        const string btnApplySend= "ارسال";
        const string btnApplycancel = "انصراف";

        static string state = "STOP";
        static int DelayTime = 1; //permint
        static int deletTime = 1;

        public void ChangeItemSate()
        {

            chkDeleteQueue.Enabled = !chkDeleteQueue.Enabled;
            chkDeleteRegister.Enabled = !chkDeleteRegister.Enabled;
            cmbdeleteTime.Enabled = !cmbdeleteTime.Enabled;
            cmbPeriod.Enabled = !cmbPeriod.Enabled;

        }
        public void FillTimes()
        {
            cmbPeriod.Items.Add(new TimeInterval("فوری", 0));
            cmbPeriod.Items.Add(new TimeInterval("هر 1 دقیقه", 1));
            cmbPeriod.Items.Add(new TimeInterval("هر 5 دقیقه", 5));
            cmbPeriod.Items.Add(new TimeInterval("هر 20 دقیقه", 20));
            cmbPeriod.Items.Add(new TimeInterval("هر 40 دقیقه", 40));
            cmbPeriod.Items.Add(new TimeInterval("هر یک ساعت", 60));

            cmbPeriod.Text = cmbPeriod.Items[0].ToString();
        }

        public void FillDeleteTimes()
        {
            cmbdeleteTime.Items.Add(new PublishTime("لحظاتی قبل", 0));
            cmbdeleteTime.Items.Add(new PublishTime("بیش از یک ربع پیش", 3));
            cmbdeleteTime.Items.Add(new PublishTime("بیش از یک نیم ساعت پیش", 4));

            cmbdeleteTime.Items.Add(new PublishTime("بیش از یک ساعت پیش",10));
            cmbdeleteTime.Items.Add(new PublishTime("بیش از 2 ساعت پیش", 11));
            cmbdeleteTime.Items.Add(new PublishTime("بیش از 4 ساعت پیش", 12));
            cmbdeleteTime.Items.Add(new PublishTime("بیش از 8 ساعت پیش", 13));
            cmbdeleteTime.Items.Add(new PublishTime("بیش از 9 ساعت پیش", 14));
            cmbdeleteTime.Items.Add(new PublishTime("بیش از 10 ساعت پیش", 15));
            cmbdeleteTime.Items.Add(new PublishTime("بیش از 11 ساعت پیش",16));
            cmbdeleteTime.Items.Add(new PublishTime("بیش از 12 ساعت پیش", 17));
            cmbdeleteTime.Items.Add(new PublishTime("بیش از 13 ساعت پیش", 18));
            cmbdeleteTime.Items.Add(new PublishTime("بیش از 18 ساعت پیش", 23));
            cmbdeleteTime.Items.Add(new PublishTime("بیش از 19 ساعت پیش", 24));
            cmbdeleteTime.Items.Add(new PublishTime("بیش از 20 ساعت پیش", 25));


            cmbdeleteTime.Items.Add(new PublishTime("بیش از یک روز پیش", 100));
            cmbdeleteTime.Items.Add(new PublishTime("بیش از 2 روز پیش", 110));
            cmbdeleteTime.Items.Add(new PublishTime("بیش از 3 روز پیش", 120));
            cmbdeleteTime.Items.Add(new PublishTime("بیش از 4 روز پیش", 130));
            cmbdeleteTime.Items.Add(new PublishTime("بیش از 5 روز پیش", 140));
            cmbdeleteTime.Items.Add(new PublishTime("بیش از 6 روز پیش", 150));

            cmbdeleteTime.Items.Add(new PublishTime("بیش از یک هفته پیش", 200));
            cmbdeleteTime.Text = cmbdeleteTime.Items[0].ToString();
        }

        public async  void Test()
        {
            for (int i = 0; i < 5; i++)
            {
                cmbPeriod.Items.Add(i.ToString());
                
            }
        }
        public async void StartDeleteOrApprove()
        {
            int index = 0;
            
            publishList = new List<DivarPost>();

            statusText.Text = "please wait:";

            // collect all tokens
            foreach (var token in tokens)
            {
                divarInstance = new Divar(token);
                divarInstance.GetPosts();
                if (divarInstance.Posts.Count() == 0) continue;
                foreach (DivarPost post in divarInstance.Posts)
                {
                    
                    publishList.Add(post);
                }
            }

            int totalNumber = publishList.Count();
            //operate 
            if (operationType == "APPROVE")
            {
                progressPrecent.Visible = true;



                foreach (DivarPost post in publishList)
                {
                    if (post.statusCode != State.WaitForAporve) continue;
                    try
                    {
                        index++;



                        Divar.AproveAdvertisement(post.token, post.managementToken);
                        progressPrecent.Value = (int)(100 * index / totalNumber);
                        statusText.Text = string.Format("process {0} from {1} post", index, totalNumber);
                        await Task.Delay(DelayTime);
                    }
                    catch (Exception)
                    {


                    }

                }
            }
            else if (operationType == "DELETE")
            {
                Divar.DeleteAdvertismentList(deletType, deletTime, publishList);
                MessageBox.Show(string.Format("{0} post process for deleting", totalNumber));
            }
            


            statusText.Text = "finish operation advertisment";
        }




        

        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// This method use to add
        /// </summary>
        /// <param name="dataGridToFill"></param>
        /// <param name="myList"></param>
        /// 
        public void EnterListInDataGridView(DataGridView dataGridToFill, List<string> myList)
        {
            int index = 1;
            foreach (var item in myList)
            {

                dataGridToFill.Rows.Add(index, item.ToString());
                index++;
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {

            refrenceDataBase = new MyExcel();
            refrenceDataBase.OpenExcelFileWithDialog();
            if (refrenceDataBase.isExcelFilePathValid)
            {
                statusText.Text = "please Wait";
                tokens = refrenceDataBase.ReadToken();
                statusText.Text = "tokens load";
                refrenceDataBase.Close();

                dataGridViewTokens.Rows.Clear();
                dataGridViewTokens.Refresh();
                EnterListInDataGridView(dataGridViewTokens, tokens);

                btnApply.Enabled = true;

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillTimes();
            FillDeleteTimes();


        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            // check for license
            Boolean licenseState = License.CheckLicense();
            if (!licenseState) return;
            
            if (btnApply.Text == btnApplySend)
            {
                btnApply.Text = btnApplycancel;
                state = "START";
                StartDeleteOrApprove();
                btnApply.Text = btnApplySend;
                //Test();

            }
            else
            {

                btnApply.Text = btnApplySend;
                state = "STOP";
            }
           
        }







        private void chkDeleteRegister_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeleteRegister.Checked) deletType += 2;
            else deletType -= 2;
        }

        private void chkDeleteQueue_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeleteQueue.Checked) deletType++;
            else deletType--;
        }

        private void cmbPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentItem = (TimeInterval)cmbPeriod.SelectedItem;
            DelayTime = 1000*60*currentItem.Value;


        }

        private void cmbdeleteTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentItem = (PublishTime)cmbdeleteTime.SelectedItem;
            deletTime = currentItem.Value;
        }

        private void rdoApprove_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoApprove.Checked)
            {
                operationType = "APPROVE";
                ChangeItemSate();
            }
            
        }

        private void rdoDelete_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDelete.Checked)
            {
                operationType = "DELETE";
                ChangeItemSate();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }









}
