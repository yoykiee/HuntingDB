using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Globalization;
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

using HuntingRegistry.Models;
using Document = HuntingRegistry.Models.Document;

namespace HuntingRegistry
{
    public partial class MainForm : Form
    {
        public HuntingDBContext dbContext;

        public MainForm()
        {
            InitializeComponent();
            dbContext = new HuntingDBContext();
            hunterBindingSource.DataSource = dbContext.Hunters.OrderBy(hunter => hunter.Name).ToList();
               
            DisableControls();

            areaBindingSource.DataSource = dbContext.Areas.OrderBy(b => b.Name).ToList();
            animalBindingSource.DataSource = dbContext.Animals.OrderBy(b => b.Name).ToList();
            hunterFarmBindingSource.DataSource = dbContext.HunterFarms.OrderBy(b => b.Name).ToList();

            huntTypeBindingSource.DataSource = dbContext.HuntTypes.OrderBy(b => b.Name).ToList();
            employeeBindingSource.DataSource = dbContext.Employees.OrderBy(b => b.Name).ToList();

            //hunterDataGridView.Sort(dataGridViewTextBoxColumn2, 0);

            //hunterDataGridView.Sort = "[ColumnName] ASC, [ColumnName] DESC";
            //_sql = new SqlCeConnection("Data Source=.\\HuntingRegistryDB.sdf");

        }

        private void DisableControls()
        {
            foreach (Control c in panel1.Controls)
            {
                c.Enabled = false;
            }
        }

        private void EnableControls()
        {
            foreach (Control c in panel1.Controls)
            {
                c.Enabled = true;
            }
        }


        bool isAddNew = false;
        bool isEdit = false;

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (isAddNew || isEdit)
            {
                MessageBox.Show("Сохраните изменения перед добавлением нового");
                return;
            }

            isAddNew = true;
            hunterBindingSource.AddNew();

            EnableControls();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dbContext.Hunters.Add((Hunter)hunterBindingSource.Current);

            if (isEdit || isAddNew)
            {
                dbContext.SaveChanges();

                DisableControls();
            }

            isEdit = false;
            isAddNew = false;


        }

        private void hunterBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var hunter = (Hunter) hunterBindingSource.Current;

            DisableControls();

            if (hunter != null)
            {
                documentBindingSource.DataSource =
                    dbContext.Documents.Where(b => b.Hunter.Id == ((Hunter) hunterBindingSource.Current).Id).ToList();
            }
            else
            {
                documentBindingSource.DataSource = null;

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filterText = textBox1.Text;

            if (filterText.Length > 2)
            {
                hunterBindingSource.DataSource = dbContext.Hunters.Where(b => b.Name.Contains(filterText)).ToList();
            }
            else
            {
                hunterBindingSource.DataSource = dbContext.Hunters.OrderBy(hunter => hunter.Name).ToList();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EnableControls();
        }

        private void btnOpenDoc_Click(object sender, EventArgs e)
        {
            var docForm = new DocForm();
            docForm.Show();
        }

        private void documentBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var document = (Document)documentBindingSource.Current;

            DisableControls();
                
            if (document != null)
            {
                animalsDocumentBindingSource.DataSource =
                    dbContext.AnimalsDocuments.Where(b => b.Document.Id == ((Document)documentBindingSource.Current).Id).ToList();

                int row = 0;

                foreach (AnimalsDocument ad in animalsDocumentBindingSource)
                {

                    if (ad.Animal != null)
                    {
                        animalsDocumentDataGridView.Rows[row].Cells[0].Value = ad.Animal.Name;
                        

                    }
                    row++;
                }

            }   
            else
            {
                documentBindingSource.DataSource = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //add method
            AnimalsDocument ad = new AnimalsDocument();
            ad.Document = (Document) documentBindingSource.Current;

            Form1 form = new Form1(ad, dbContext);


            DialogResult dialog = form.ShowDialog();


            if (dialog == DialogResult.OK)
            {
                dbContext.AnimalsDocuments.Add(ad);
                dbContext.SaveChanges();
                animalsDocumentBindingSource.DataSource = dbContext.AnimalsDocuments.Where(b => b.Document.Id == ((Document)documentBindingSource.Current).Id).ToList();
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //edit method
            AnimalsDocument ad =
                dbContext.AnimalsDocuments.SingleOrDefault(
                    b => b.Id == ((AnimalsDocument) animalsDocumentBindingSource.Current).Id);

            Form1 form = new Form1(ad, dbContext);

            DialogResult dialog = form.ShowDialog();


            if (dialog == DialogResult.OK)
            {

                dbContext.SaveChanges();
                animalsDocumentBindingSource.DataSource = dbContext.AnimalsDocuments.Where(b => b.Document.Id == ((Document)documentBindingSource.Current).Id).ToList();
            }

            form.Close();
            form.Dispose();
        }







       

        public void FillReportHandler(ReportHandler rh)
        {
            
            Hunter hunter = (Hunter)hunterBindingSource.Current;
            Document doc = (Document) documentBindingSource.Current;

            rh.HunterAddress = hunter.Address;

            if (hunter.BirthDay != null) rh.HunterBirth = new DateTimeRecordHandler(hunter.BirthDay.Value);
            if (hunter.LicenceIssueDate != null) rh.HunterLicenceIssue = new DateTimeRecordHandler(hunter.LicenceIssueDate.Value);

            rh.HunterLicenceNumber = hunter.LicenceNumber;
            rh.HunterLicenceSerial = hunter.LicenceSerial;

            rh.HunterName = hunter.Name;
            rh.HunterPassport = hunter.Passport;
            rh.HunterPhone = hunter.Phone;
            rh.HunterTIN = hunter.TIN;


            //Document fill

            if (doc.ActivityDateStart != null) rh.DocumentAcitivityDateStart = new DateTimeRecordHandler(doc.ActivityDateStart.Value);
            if (doc.ActivityDateEnd != null) rh.DocumentAcitivityDateEnd = new DateTimeRecordHandler(doc.ActivityDateEnd.Value);
            if (doc.IssueDate != null) rh.DocumentIssueDate = new DateTimeRecordHandler(doc.IssueDate.Value);
            if (doc.PaymentDate != null) rh.DocumentPaymentDate = new DateTimeRecordHandler(doc.PaymentDate.Value);
            if (doc.RegDate != null) rh.DocumentRegDate = new DateTimeRecordHandler(doc.RegDate.Value);
            if (doc.ReturnDate != null) rh.DocumentReturnDate = new DateTimeRecordHandler(doc.ReturnDate.Value);


            if (doc.Area != null) rh.DocumentAreaName = doc.Area.Name;
            if (doc.HunterFarm != null) rh.DocumentHunterFarmName = doc.HunterFarm.Name;
            if (doc.HunterFarm == null) rh.DocumentHunterFarmName = doc.HunterFarmName;


            rh.DocumentNumber = doc.Number;
            rh.DocumentRegNumber = doc.RegNumber;
            rh.DocumentResult = doc.Result;

            
            if (doc.Employee != null) rh.DocumentEmployeeName = doc.Employee.Name;

            
            var nfi = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
            nfi.NumberGroupSeparator = " ";
            nfi.NumberDecimalSeparator = ",";

            decimal summ;
            if (doc.Summ != null)
            {
                summ = doc.Summ.Value;
                rh.DocumentSummInt = summ.ToString("#,0.00", nfi);
                rh.DocumentSummString = NumByWords.RurPhrase(summ);
            }
         
        }


        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var rh = new ReportHandler("test");
            FillReportHandler(rh);
            rh.PrepareDocument();
        }
    }
}
