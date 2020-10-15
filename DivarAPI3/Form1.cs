using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DivarAPI3
{
    public partial class Form1 : Form
    {


        MyExcel refrenceDataBase;
        List<string> tokens;
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// This method use to add
        /// </summary>
        /// <param name="dataGridToFill"></param>
        /// <param name="myList"></param>
        public void EnterListInDataGridView(DataGridView dataGridToFill, List<string> myList)
        {
            int index = 1;
            foreach (var item in myList)
            {

                dataGridToFill.Rows.Add(index, item.ToString());
                index++;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //string accessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ1c2VyIjoiMDkxOTcyODcwNTgiLCJleHAiOjE2MDM5NTY4MTIuOTQ4MDQxLCJ2ZXJpZmllZF90aW1lIjoxNjAyNjYwODEyLjk0ODAyMiwidXNlci10eXBlIjoibWFya2V0cGxhY2UtYnVzaW5lc3MifQ.SaPGMEC21kAcjQKnN7ojp4EGYlqE4hGQDL_bFMEx-Nk";

            //Divar myDivar = new Divar();
            //List myDivar.GetData(accessToken);
            //MessageBox.Show(re);
            //Divar.GetData();
            //myDivar.GetData();
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
                statusText.Text = "finish";
                refrenceDataBase.Close();
                EnterListInDataGridView(dataGridViewTokens, tokens);

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
