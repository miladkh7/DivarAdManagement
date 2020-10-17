using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
namespace DivarAPI3
{
    class MyExcel
    {
        public Boolean isExcelFilePathValid = false;
        string path = string.Empty;
        string savingPath = string.Empty;
        _Application excel = new _Excel.Application();

        Workbook wb;
        Worksheet ws;
        /// <summary>
        /// for management excel file use this class
        /// </summary>
        /// <param name="path">path of excel file</param>
        /// <param name="sheet">active sheet</param>
        public MyExcel(string path, int sheet)
        {

            OpenExcelFile(path, sheet);

        }
        public MyExcel()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="sheet"></param>
        public void OpenExcelFile(string path, int sheet)
        {
            this.path = path;
            this.wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[sheet];
        }

        public void CreateNewFile()
        {
            this.wb = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            this.ws=wb.Worksheets[1];
        }

        public void CreateNewWorksheet()
        {
            wb.Worksheets.Add(After: ws);
        }

        /// <summary>
        /// Show Open Dialog box to select excel file and then open in in memeory
        /// </summary>
        public void OpenExcelFileWithDialog()
        {
            isExcelFilePathValid = false;
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "select Excel file 2003";
            openDialog.Filter = "excel 97to2003(*.xls)|*.xls|excel2007 and above(*.xlsx)|*.xlsx";
            openDialog.FilterIndex = 2;

            //this use for #Test Only
            try
            {
                openDialog.InitialDirectory = @"E:\gholami\DivarAPI3\test";
            }
            catch (Exception)
            {
                
            }

            try
            {
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    if (openDialog.FileName != null) this.path = openDialog.FileName;

                    OpenExcelFile(path, 1);
                    isExcelFilePathValid = true;

                }

            }
            catch (Exception)
            {

              
            }

        }
        
        public void SaveExcelFileWithDialog()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "select Excel file";
            saveDialog.Filter = "excel2007 and above(*.xlsx)|*.xlsx";
            saveDialog.FilterIndex = 1;
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveDialog.FileName != null) this.savingPath = saveDialog.FileName;
                this.SaveAs(this.savingPath);
                //OpenExcelFile(path, 1);

            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="i">index of Row</param>
        /// <param name="j">index of column</param>
        /// <returns>value of Cell in row i and column j</returns>
        public string ReadCell(int i, int j)
        {
            
            //check index of Row and culumn
            if (i < 1 || j < 1)
            {
                MessageBox.Show("indices must be greater that zero");
                return string.Empty;
            }
          
            if (ws.Cells[i, j].value2 != null)
            {
                
                var cellValue= ws.Cells[i, j].value2;

                //for test only
                //MessageBox.Show(cellValue.ToString());

                return cellValue.ToString();
            }
            return string.Empty;
        }


        public void Save()
        {
            wb.Save();

        }
        public void SaveAs(string path)
        {
            wb.SaveAs(path);
        }
        /// <summary>
        /// write sring in excel file
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="valueShouldToWrite"></param>
        public void WriteToCell(int i ,int j ,string valueShouldToWrite)
        {
            ws.Cells[i, j].value2 = valueShouldToWrite;

        }

        public List<string> ReadToken()
        {
            List<string> tokens = new List<string>();
            try
            {
                for (int i = 1; i < ws.Rows.Count; i++)
                {
                    string currentToken = ReadCell(i, 2);

                    if (currentToken ==String.Empty)
                    {
                        break;
                    }
                    tokens.Add(currentToken);
                }
                return tokens;

            }
            catch (Exception)
            {

                return tokens;
            }
        }
        public void Close()
        {
            wb.Close();
        }
    }
}
