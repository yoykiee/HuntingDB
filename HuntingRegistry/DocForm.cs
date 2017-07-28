using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuntingRegistry
{
    public partial class DocForm : Form
    {
        public DocForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  DateTime dt;
            //  
            //  dt = dateTimePicker1.Value;
            //  
            //   
            //  
            //  var rus = CultureInfo.GetCultureInfo("ru-RU");
            //  var today = dateTimePicker1.Value;
            //  var month = rus.DateTimeFormat.MonthGenitiveNames[today.Month-1];
            //  textBox1.Text = month.ToString();

            decimal a = Decimal.Parse(textBox1.Text);

            var nfi = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
            nfi.NumberGroupSeparator = " ";
            nfi.NumberDecimalSeparator = ",";
            textBox2.Text = a.ToString("#,0.00", nfi);

            textBox3.Text = NumByWords.RurPhrase(a);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime dt;

            dt = dateTimePicker1.Value;

            textBox1.Text = dt.ToString("dd-MM-yyyy hh-mm-ss");





        }

        private void button3_Click(object sender, EventArgs e)
        {

        }



        //  rh.HunterLicenceIssueDay;
        //  rh.HunterLicenceIssueMonthWord;
        //  rh.HunterLicenceIssueMonthInt;
        //  rh.HunterLicenceIssueYear2;
        //  rh.HunterLicenceIssueYear4;
    }
}
