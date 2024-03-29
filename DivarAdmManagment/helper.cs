﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;
namespace DivarAdManagment
{

    public class TimeInterval
    {
        public string Name;
        public int Value;
        public TimeInterval(string name, int value)
        {
            Name = name; Value = value;
        }
        public override string ToString()
        {
            // Generates the text shown in the combo box
            return Name;
        }
    }


    public class PublishTime
    {
        public string Name;
        public int Value;
        public PublishTime(string name, int value)
        {
            Name = name; Value = value;
        }
        public override string ToString()
        {
            // Generates the text shown in the combo box
            return Name;
        }



        public static int TimeToCode(string raw_time)
        {
            string[] persianNumber = { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };
            string[] english = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            for (int i = 0; i < 10; i++)
            {
                raw_time = raw_time.ToString().Replace(persianNumber[i], english[i]);
            }

            string[] persianTime = { "لحضاتی پیش", "دقایقی", "ربع", "نیم","ساعت", "دیروز", "پریروز", "روز", "هفته" };
            int number = 0;
            try
            {
                var numberObject = Regex.Match(raw_time, @"\d+").Value;
                number = int.Parse(numberObject);
            }
            catch (Exception)
            {

                 
            }

            int result = 0;

            if (raw_time.Contains(persianTime[0])) result = 1;// lahze
            if (raw_time.Contains(persianTime[1])) result = 2;// daghighe
            if (raw_time.Contains(persianTime[2])) result = 3;//rob
            if (raw_time.Contains(persianTime[3])) result = 4;//nim
            if (raw_time.Contains(persianTime[4])) result = 10+ number;//saat
            if (raw_time.Contains(persianTime[5])) result = 100;//diroz
            if (raw_time.Contains(persianTime[6])) result = 110;//payroz
            if (raw_time.Contains(persianTime[7])) result = 100 +(10* number);//rozaye pish
            if (raw_time.Contains(persianTime[8])) result = 200 + (10 * number);//hafte pish

            return result;

        }

    }

    public class ControlDataGrid
    {
        public ControlDataGrid()
        {

        }

        public static DataGridViewRow GetCurrentDataGrid(DataGridView tokensDataGrid, string searchValue)
        {
            foreach (DataGridViewRow row in tokensDataGrid.Rows)
            {
                if (row.Cells[1].Value.ToString().Equals(searchValue))
                {
                    return row;
                    break;
                }

            }
            return tokensDataGrid.Rows[0];
        }
        public static void SetDataGridRowOnProcess(DataGridViewRow row)
        {
            row.DefaultCellStyle.BackColor = Color.Green;
            row.DefaultCellStyle.ForeColor = Color.Black;
        }

        public static void SetDataGridRowError(DataGridViewRow row)
        {
            row.DefaultCellStyle.BackColor = Color.Red;
            row.DefaultCellStyle.ForeColor = Color.Black;
        }
    }
}
