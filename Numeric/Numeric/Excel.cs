﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace Numeric
{
    class Excel
    {
        string path = "";
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;
        public Excel(string path, int Sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[Sheet];
        }

        public string ReadCell(int i, int j)
        {
            i++;
            j++;
            if (ws.Cells[i, j].Value != null)
                return ws.Cells[i, j].Value;
            else
                return "";
            
        }
        public void WriteToCell(int i,int j, string s)
        {
            i++;
            j++;
            ws.Cells[i, j].Value2 = s;
        }
        public void Save()
        {
            wb.Save();
        }
        public void Close()
        {
            wb.Close();
        }
        public void Hide(int i)
        {
            ws.Rows.Cells[i, ws.Columns.Count].EntireRow.Hidden = true;
        }
        public void Unhide(int i)
        {
            ws.Rows.Cells[i, ws.Columns.Count].EntireRow.Hidden = false;
        }
        public void HideCol(int i)
        {
            ws.Columns.Cells[ws.Rows.Count, i].EntireColumn.Hidden = true;
        }
        public void UnhideCol(int i)
        {
            ws.Columns.Cells[ws.Rows.Count, i].EntireColumn.Hidden = true;
        }
    }
}
