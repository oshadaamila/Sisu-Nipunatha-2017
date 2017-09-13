using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace Sisu_Nipunatha
{
    class editResultSheet
    {
        String first_id, second_id, third_id, fourth_id, fifth_id, competition_id;
        System.Data.DataTable dtforID = new System.Data.DataTable();
        int[] cells = { 0, 4, 11, 18, 25, 35, 42, 49, 56, 66, 73, 80, 87, 97, 104, 111, 118, 128, 135, 142, 149, 159, 166, 173, 180, 190, 197, 204, 211, 221, 228, 235, 242, 252, 259, 266, 273, 283, 290, 297, 304, 314 };
        public editResultSheet(String competitionID,String firstID,String secondID,String thirdID,String fourthID,String fifthID)
        {
            this.first_id = firstID;
            this.second_id = secondID;
            this.third_id = thirdID;
            this.fourth_id = fourthID;
            this.fifth_id = fifthID;
            this.competition_id = competitionID;
        }
        public void edit()
        {
            loadvalues();
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = true;
            string workbookPath = "C:\\Sisu_Nipunatha\\results.xlsx";
            Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(workbookPath,
                    0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "",
                    true, false, 0, true, false, false);
            Microsoft.Office.Interop.Excel.Sheets excelSheets = excelWorkbook.Worksheets;
            string currentSheet = "Sheet1";
            Microsoft.Office.Interop.Excel.Worksheet excelWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)excelSheets.get_Item(currentSheet);
            int first_cell = cells[Convert.ToInt32(competition_id)];
            excelWorksheet.Cells[first_cell,3] = dtforID.Rows[0][0].ToString();
            excelWorksheet.Cells[first_cell+1, 3] = dtforID.Rows[1][0].ToString();
            excelWorksheet.Cells[first_cell + 2, 3] = dtforID.Rows[2][0].ToString();
            excelWorksheet.Cells[first_cell + 3, 3] = dtforID.Rows[3][0].ToString();
            excelWorksheet.Cells[first_cell + 4, 3] = dtforID.Rows[4][0].ToString();
            excelWorksheet.Cells[first_cell, 4] = dtforID.Rows[0][1].ToString();
            excelWorksheet.Cells[first_cell + 1, 4] = dtforID.Rows[1][1].ToString();
            excelWorksheet.Cells[first_cell + 2, 4] = dtforID.Rows[2][1].ToString();
            excelWorksheet.Cells[first_cell + 3, 4] = dtforID.Rows[3][1].ToString();
            excelWorksheet.Cells[first_cell + 4, 4] = dtforID.Rows[4][1].ToString();
            excelWorksheet.Cells[first_cell, 5] = dtforID.Rows[0][2].ToString();
            excelWorksheet.Cells[first_cell + 1, 5] = dtforID.Rows[1][2].ToString();
            excelWorksheet.Cells[first_cell + 2, 5] = dtforID.Rows[2][2].ToString();
            excelWorksheet.Cells[first_cell + 3, 5] = dtforID.Rows[3][2].ToString();
            excelWorksheet.Cells[first_cell + 4, 5] = dtforID.Rows[4][2].ToString();
         }
        public void loadvalues()
        {
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT `StudentID`,`Name`,`dahampasala` FROM `studentstable` WHERE  `StudentID` in ('" + first_id + "','" + second_id + "','" + third_id + "','" + fourth_id + "','" + fifth_id + "') order by place asc;", SqlCon.con);
            sda.Fill(dtforID);
        }
    }
}
