using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;

using DataTable = System.Data.DataTable;
using Shape = Microsoft.Office.Interop.Word.Shape;
using Word = Microsoft.Office.Interop.Word;


namespace HuntingRegistry
{
    public partial class MainFormCopy : Form
    {
        SqlCeConnection _sql;
        public MainFormCopy()
        {
            InitializeComponent();
            _sql = new SqlCeConnection("Data Source=.\\HuntingRegistryDB.sdf");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dataT;
            BindingSource bindS;

          
            dataT = new DataTable();
            bindS = new BindingSource();

            string query = "SELECT * FROM test";
            SqlCeDataAdapter dA = new SqlCeDataAdapter(query, _sql);
            SqlCeCommandBuilder cBuilder = new SqlCeCommandBuilder(dA);

            _sql.Open();

            dA.Fill(dataT);

            _sql.Close();
            bindS.DataSource = dataT;
            dataGridView1.DataSource = bindS;
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
           // using (var db = new Entities())
           // {
           //     var blog = new test { Name = "kekec" };
           //     db.test.Add(blog);
           //     db.SaveChanges();
           //     //db.
           //
           //     // Display all Blogs from the database 
           //     var query = from b in db.test
           //                 orderby b.Name
           //                 select b;
           //
           //     dataGridView1.DataSource = db.test.ToList();
           //     db.Dispose();
           // }

            
        }

        private void button3_Click(object sender, EventArgs e)
        {


            // Определение переменной oWord
            Word.Application oWord = new Word.Application();

            // Считывает шаблон и сохраняет измененный в новом
            
            //Document oDoc = oWord.Documents.Add(Environment.CurrentDirectory + "\\q11.dotx");

            //oDoc.Fields["test1"].Range.Text = "hellop from app";

            Object oMissing = System.Reflection.Missing.Value;
            Object oTemplatePath = Environment.CurrentDirectory + "\\q12.docx";

            _Document oDoc = oWord.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oMissing);


            

            foreach (Shape shape in oDoc.Shapes)
            {
                if (shape.Title == "Name")
                {
                    // var initialText = shape.TextFrame.TextRange.Text;
                    // var resultingText = initialText.Replace(findText, replaceText);
                    shape.TextFrame.TextRange.Text = textBox1.Text;
                }

                if (shape.Title == "Family")
                {
                    // var initialText = shape.TextFrame.TextRange.Text;
                    // var resultingText = initialText.Replace(findText, replaceText);
                    shape.TextFrame.TextRange.Text = textBox2.Text;
                }



            }





            oDoc.SaveAs(FileName: Environment.CurrentDirectory + "\\For_print.docx");
            //   oDoc.PrintOut();
            //   oDoc.Close();
            //   oWord.Application.Quit();


            oWord.Documents.Open(Environment.CurrentDirectory + "\\For_print.docx");
           
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
