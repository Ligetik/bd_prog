using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using DGVPrinterHelper;
using System.Globalization;
using System.Xml.Serialization;
using System.IO;

namespace bd
{
    public partial class MainForm : Form
    {
        int RowIndex = 0;
        int ColIndex = 0;
        public MainForm()
        {
            InitializeComponent();
        }

        DateTimePicker DateTimePicker1;
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sqlDataSet._3_НДФЛ". При необходимости она может быть перемещена или удалена.
            this._3_НДФЛTableAdapter.Fill(this.sqlDataSet._3_НДФЛ);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sqlDataSet.Декларация". При необходимости она может быть перемещена или удалена.
            this.декларацияTableAdapter.Fill(this.sqlDataSet.Декларация);
            try
            {
                // TODO: данная строка кода позволяет загрузить данные в таблицу "sqlDataSet2.Декларация". При необходимости она может быть перемещена или удалена.
                //this.декларацияTableAdapter.Fill(this.sqlDataSet2.Декларация);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "sqlDataSet1._3_НДФЛ". При необходимости она может быть перемещена или удалена.
                //this._3_НДФЛTableAdapter.Fill(this.sqlDataSet1._3_НДФЛ);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "sqlDataSet.Организация". При необходимости она может быть перемещена или удалена.
                this.организацияTableAdapter.Fill(this.sqlDataSet.Организация);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "sqlDataSet.Table". При необходимости она может быть перемещена или удалена.
                //this.tableTableAdapter.Fill(this.sqlDataSet.Table);

                totalLabelDGV1.Text = $"Количество записей: {dataGridView1.RowCount}";
                totalLabelDGV2.Text = $"Количество записей: {dataGridView2.RowCount}";

                DateTimePicker1 = new DateTimePicker();
                DateTimePicker1.Format = DateTimePickerFormat.Short;
                DateTimePicker1.Visible = false;
                DateTimePicker1.Width = 150;
                dataGridView2.Controls.Add(DateTimePicker1);

                DateTimePicker1.ValueChanged += this.DTP_ValueChanged;
                dataGridView2.CellBeginEdit += this.dataGridView2_CellBeginEdit;
                dataGridView2.CellEndEdit += this.dataGridView2_CellEndEdit;



            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Сохранить данные в таблице перед закрытием?", "Выход", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            try
            {
                switch (result)
                {
                    case DialogResult.Yes:
                        организацияBindingSource.EndEdit();
                        организацияTableAdapter.Update(this.sqlDataSet.Организация);
                        Application.Exit();
                        break;

                    case DialogResult.No:
                        Application.Exit();
                        break;

                    default:
                        break;
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
            
        }

        private void сохраниттToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                организацияBindingSource.EndEdit();
                организацияTableAdapter.Update(this.sqlDataSet.Организация);
                MessageBox.Show("Данные успешно сохранены!", "Сохранение", MessageBoxButtons.OK);
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void нужноСдатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dataGridView1.Rows[RowIndex].Cells[ColIndex].Style.BackColor = Color.Red;
            dataGridView1.Rows[RowIndex].Cells[ColIndex].Value = "Нужно сдать";
            dataGridView1.Rows[RowIndex].Cells[ColIndex].Style.ForeColor = Color.Red;
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                организацияBindingSource.EndEdit();
                организацияTableAdapter.Update(this.sqlDataSet.Организация);
                MessageBox.Show("Данные успешно сохранены!","Сохранение", MessageBoxButtons.OK);
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
            Cursor.Current = Cursors.Default;

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.организацияTableAdapter.FillBy(this.sqlDataSet.Организация);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }    

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ExcelExMethod();
        }

        private string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }

        private void ExcelExMethod()
        {
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook workbook = exApp.Workbooks.Add();
            Excel.Worksheet worksheet = null;


            worksheet = workbook.Sheets["Лист1"];
            worksheet = workbook.ActiveSheet;

            int rowstartindex = 1;

            try
            {
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                }

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();

                        Excel.Range CellDataRange = worksheet.get_Range(GetExcelColumnName(j + 1) + (i + rowstartindex + 1).ToString());
                        CellDataRange.Value = dataGridView1[j, i].Value;

                        if (!dataGridView1.Rows[i].Cells[j].Style.BackColor.IsEmpty)
                            CellDataRange.Interior.Color = dataGridView1.Rows[i].Cells[j].Style.BackColor;
                    }
                }
                worksheet.Columns.AutoFit();

                var saveFile = new SaveFileDialog();
                saveFile.FileName = "Клиенты";
                saveFile.DefaultExt = ".xlsx";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFile.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }

                exApp.Visible = true;


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void экспортToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelExMethod();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.SubTitle = string.Format("Клиенты", printer.SubTitleColor = System.Drawing.Color.Black, printer);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.Porportional;

            printer.ColumnWidths.Add(dataGridView1.Columns[0].Name, 80);
            printer.ColumnWidths.Add(dataGridView1.Columns[1].Name, 120);
            printer.ColumnWidths.Add(dataGridView1.Columns[2].Name, 70);
            printer.ColumnWidths.Add(dataGridView1.Columns[3].Name, 70);
            printer.ColumnWidths.Add(dataGridView1.Columns[4].Name, 70);
            printer.ColumnWidths.Add(dataGridView1.Columns[5].Name, 70);
            printer.ColumnWidths.Add(dataGridView1.Columns[6].Name, 70);
            printer.ColumnWidths.Add(dataGridView1.Columns[7].Name, 70);
            printer.ColumnWidths.Add(dataGridView1.Columns[8].Name, 70);
            printer.ColumnWidths.Add(dataGridView1.Columns[9].Name, 70);
            printer.ColumnWidths.Add(dataGridView1.Columns[10].Name, 90);

            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.Footer = "\r\n" + "\r\n";
            printer.FooterSpacing = 15;
            printer.PrintPreviewDataGridView(dataGridView1);

            //------------------------------
            //dgvprinter.HideColumns.Add(mygrid.Columns[1].Name);
        }

        private void toolStripButtonSaveDGV2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                нДФЛBindingSource.EndEdit();
                _3_НДФЛTableAdapter.Update(this.sqlDataSet._3_НДФЛ);
                MessageBox.Show("Данные успешно сохранены!", "Сохранение", MessageBoxButtons.OK);
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
            Cursor.Current = Cursors.Default;
        }

        private void toolStripButton2_Click_2(object sender, EventArgs e)
        {
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook workbook = exApp.Workbooks.Add();
            Excel.Worksheet worksheet = null;


            worksheet = workbook.Sheets["Лист1"];
            worksheet = workbook.ActiveSheet;

            int rowstartindex = 1;

            try
            {
                for (int i = 0; i < dataGridView2.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dataGridView2.Columns[i].HeaderText;
                }

                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView2.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView2.Rows[i].Cells[j].Value.ToString();

                        Excel.Range CellDataRange = worksheet.get_Range(GetExcelColumnName(j + 1) + (i + rowstartindex + 1).ToString());
                        CellDataRange.Value = dataGridView2[j, i].Value;

                        if (!dataGridView2.Rows[i].Cells[j].Style.BackColor.IsEmpty)
                            CellDataRange.Interior.Color = dataGridView2.Rows[i].Cells[j].Style.BackColor;
                    }
                }
                worksheet.Columns.AutoFit();

                var saveFile = new SaveFileDialog();
                saveFile.FileName = "Клиенты";
                saveFile.DefaultExt = ".xlsx";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFile.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }

                exApp.Visible = true;


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.SubTitle = string.Format("3-НДФЛ", printer.SubTitleColor = System.Drawing.Color.Black, printer);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.Porportional;

            printer.ColumnWidths.Add(dataGridView2.Columns[0].Name, 90);
            printer.ColumnWidths.Add(dataGridView2.Columns[1].Name, 120);
            printer.ColumnWidths.Add(dataGridView2.Columns[2].Name, 120);
            printer.ColumnWidths.Add(dataGridView2.Columns[3].Name, 120);
            printer.ColumnWidths.Add(dataGridView2.Columns[4].Name, 120);
            printer.ColumnWidths.Add(dataGridView2.Columns[5].Name, 120);
            printer.ColumnWidths.Add(dataGridView2.Columns[6].Name, 120);

            printer.ColumnWidths.Add("Column Name", 250);
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "\r\n" + "\r\n";
            printer.FooterSpacing = 15;
            printer.PrintPreviewDataGridView(dataGridView2);
        }

        private void сданоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dataGridView1.Rows[RowIndex].Cells[ColIndex].Style.BackColor = Color.Green;
            dataGridView1.Rows[RowIndex].Cells[ColIndex].Value = "Сдано";
            dataGridView1.Rows[RowIndex].Cells[ColIndex].Style.ForeColor = Color.Green;
        }


        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    this.RowIndex = e.RowIndex;
                    this.ColIndex = e.ColumnIndex;
                    this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    if (e.ColumnIndex == 2 | e.ColumnIndex == 3 | e.ColumnIndex == 4 | e.ColumnIndex == 5 | e.ColumnIndex == 6 |
                        e.ColumnIndex == 7 | e.ColumnIndex == 8 | e.ColumnIndex == 9)
                    {
                        this.contextMenuStrip1.Show(this.dataGridView1, e.Location);
                        contextMenuStrip1.Show(Cursor.Position);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("В данной ячейке цвет недоступен");
            }
            
        }

        private void пОДГОТОВЛЕНОToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dataGridView1.Rows[RowIndex].Cells[ColIndex].Style.BackColor = Color.Yellow;
            dataGridView1.Rows[RowIndex].Cells[ColIndex].Value = "Подготовлено";
            
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows[RowIndex].Cells[ColIndex].Style.BackColor = Color.Empty;
            dataGridView1.Rows[RowIndex].Cells[ColIndex].Value = "";
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //dataGridView1.Rows[RowIndex].Cells[ColIndex].Style.BackColor = Color.DeepSkyBlue;
            dataGridView1.Rows[RowIndex].Cells[ColIndex].Value = "Синий";
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //dataGridView1.Rows[RowIndex].Cells[ColIndex].Style.BackColor = Color.MediumPurple;
            dataGridView1.Rows[RowIndex].Cells[ColIndex].Value = "Фиолетовый";
        }

        private void dataGridView2_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (dataGridView2.Focused && dataGridView2.CurrentCell.ColumnIndex == 5)
                {
                    //DateTimePicker1.Location = dataGridView2.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                    var rect = dataGridView2.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    DateTimePicker1.Size = new Size(rect.Width, rect.Height);
                    DateTimePicker1.Location = new System.Drawing.Point(rect.X, rect.Y);
                    DateTimePicker1.Visible = true;

                    if (dataGridView2.CurrentCell.Value != DBNull.Value)
                    {
                        DateTimePicker1.Value = (DateTime)dataGridView2.CurrentCell.Value;
                    }
                    else
                    {
                        DateTimePicker1.Value = DateTime.Today;
                    }
                }
                else
                {
                    DateTimePicker1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView2.Focused && dataGridView2.CurrentCell.ColumnIndex == 5)
                {
                    dataGridView2.CurrentCell.Value = DateTimePicker1.Value.Date;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DTP_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.CurrentCell.Value = DateTimePicker1.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            if (e.ColumnIndex == 2 | e.ColumnIndex == 3 | e.ColumnIndex == 4 | e.ColumnIndex == 5 | e.ColumnIndex == 6 |
                e.ColumnIndex == 7 | e.ColumnIndex == 8 | e.ColumnIndex == 9 & e.Value != null)
            {
                string Cell_color = Convert.ToString(e.Value);
                //int Cell_color = Convert.ToInt32(e.Value);
              
                switch (Cell_color)
                {
                    case "Подготовлено":
                        e.CellStyle.BackColor = Color.Yellow;
                        e.CellStyle.ForeColor = Color.Yellow;
                        break;
                    case "Нужно сдать":
                        e.CellStyle.BackColor = Color.Red;
                        e.CellStyle.ForeColor = Color.Red;
                        break;
                    case "Сдано":
                        e.CellStyle.BackColor = Color.Green;
                        e.CellStyle.ForeColor = Color.Green;
                        break;
                    case "Синий":
                        e.CellStyle.BackColor = Color.DeepSkyBlue;
                        e.CellStyle.ForeColor = Color.DeepSkyBlue;
                        break;
                    case "Фиолетовый":
                        e.CellStyle.BackColor = Color.MediumPurple;
                        e.CellStyle.ForeColor = Color.MediumPurple;
                        break;
                    default:
                        break;
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void contextMenuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            //if (dataGridView2.Rows[0].Cells[1].Value != null)
            //{
            //    contextMenuStrip1.Visible = false;
            //}
            //else
            //{
            //    contextMenuStrip1.Visible = true;
            //}

        }

        private void dataGridView1_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            
        }

        private void bindingNavigatorAddNewItem1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
