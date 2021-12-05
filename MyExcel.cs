using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MyExcel
{
    public partial class MyExcel : Form
    {
        Data data;
        string oldTextBoxExpression = String.Empty;
        string currentFileName;

        public MyExcel()
        {
            InitializeComponent();
            data = new Data(dataGridView1);
            openFileDialog1.Filter = "Text files(*.txt)|*.txt.|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt.|All files(*.*)|*.*";
            //this.Text = "MyExcel";
        }
        internal Data Data
        {
            get => default(Data);
            set { }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            data.FillData(Mode.Value);
        }
        private void dataGridView_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Value.ToString()))
            {
                data.ChangeData(e.Value.ToString(), e.RowIndex, e.ColumnIndex);
            }
        }
        //вийтиToolStripMenuItem_Click
        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void відкритиToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                data = new Data(dataGridView1);
                data.OpenFile(openFileDialog1.FileName);
                data.FillData(Mode.Value);
                currentFileName = openFileDialog1.FileName;
                this.Text = currentFileName + "_MyExcel";
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 1)
            {
                var selectedCell = dataGridView1.SelectedCells[0];
                textBox1.Text = Data.cells[selectedCell.RowIndex][selectedCell.ColumnIndex].Expression;
                oldTextBoxExpression = textBox1.Text;
            }
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (Data.cells[e.RowIndex][e.ColumnIndex].Expression != null)
                if (!String.IsNullOrEmpty(Data.cells[e.RowIndex][e.ColumnIndex].Error))
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Data.cells[e.RowIndex][e.ColumnIndex].Error;
                else
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Data.cells[e.RowIndex][e.ColumnIndex].Value.ToString();
        }
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellParsingEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Data.cells[e.RowIndex][e.ColumnIndex].Expression;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 1)
            {
                var selectedCell = dataGridView1.SelectedCells[0];
                if (textBox1.Text == String.Empty)
                {
                    Data.cells[selectedCell.RowIndex][selectedCell.ColumnIndex].Expression = null;
                    Data.cells[selectedCell.RowIndex][selectedCell.ColumnIndex].Value = 0;
                    dataGridView1.Rows[selectedCell.RowIndex].Cells[selectedCell.ColumnIndex].Value = "";
                }
                else
                {
                    data.ChangeData(textBox1.Text, selectedCell.RowIndex, selectedCell.ColumnIndex);
                    if (!String.IsNullOrEmpty(Data.cells[selectedCell.RowIndex][selectedCell.ColumnIndex].Error))
                        dataGridView1.Rows[selectedCell.RowIndex].Cells[selectedCell.ColumnIndex].Value = Data.cells[selectedCell.RowIndex][selectedCell.ColumnIndex].Error;
                    else
                        dataGridView1.Rows[selectedCell.RowIndex].Cells[selectedCell.ColumnIndex].Value = Data.cells[selectedCell.RowIndex][selectedCell.ColumnIndex].Value.ToString();
                }
            }
        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox textBox2 = (TextBox)e.Control;
            textBox2.TextChanged += TextBox_TextChanged;
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = ((TextBox)sender).Text;
            oldTextBoxExpression = textBox1.Text;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            data.AddRow();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            data.RemoveRow();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            data.AddColumn();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            data.RemoveColumn();
        }

        private void додатиРядокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            data.AddRow();
        }

        private void видалитиРядокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            data.RemoveRow();
        }

        private void додатиСтовпчикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            data.AddColumn();
        }

        private void видалитиСтовпчикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            data.RemoveColumn();
        }

        private void довідкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вітаємо у застосунку MyExcel!\n\nДана програма дозволяє працювати з клітинками таблиці, які приймають задане значення. " +
                "Доступні операції: +, -, *, /, mod, div, ^. Вирази вважаються логічними, тож можливі операції порівняння: <, >, =, <=, >=, <>. " +
                "\nЗасоби редагування таблиці доступні на панелі кнопок та на панелі інструментів -> Редагувати. " +
                "\nДля вводу значень потрібно виконати наступне: Активувати клітинку, в рядок вводу ввести потрібне значення, натиснути \"Ввести\"" +
                "\nЩоб зберегти файл або відкрити таблицю з файлу натисніть Файл на панелі інструментів.\n" +
                "\nПриємного користування!");
        }

        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                data.SaveToFile(openFileDialog1.FileName);
                currentFileName = saveFileDialog1.FileName;
                this.Text = currentFileName + " - MyExcel";
            }
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Data.cells[e.RowIndex][e.ColumnIndex].Expression != null)
                if (!String.IsNullOrEmpty(Data.cells[e.RowIndex][e.ColumnIndex].Error))
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Data.cells[e.RowIndex][e.ColumnIndex].Error;
                else
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Data.cells[e.RowIndex][e.ColumnIndex].Value.ToString();
        }
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Data.cells[e.RowIndex][e.ColumnIndex].Expression;
        }
    }
}
