using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;
using Shape = Microsoft.Office.Interop.Word.Shape;
using Word = Microsoft.Office.Interop.Word;


using Document = HuntingRegistry.Models.Document;


namespace HuntingRegistry
{
    public class ReportHandler
    {
        public ReportHandler()
        {

        }


        public ReportHandler(string _reportName )
        {
            ReportTemplateName = _reportName;
        }

        public void PrepareDocument()
        {
            Word.Application oWord = new Word.Application();

            if (ReportTemplateName == null) return;

            Object oMissing = System.Reflection.Missing.Value;
            Object oTemplatePath = Environment.CurrentDirectory + "\\WordTemplates\\"+ReportTemplateName+".docx";

            Word._Document oDoc = oWord.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oMissing);

            foreach (Shape shape in oDoc.Shapes)
            {
                if (shape.Title == "Deleted")
                {
                    shape.Delete();
                    continue;
                }

                var resultingText = shape.TextFrame.TextRange.Text;

                resultingText = resultingText.Replace("<HunterAddress>", HunterAddress);
                resultingText = resultingText.Replace("<HunterLicenceNumber>", HunterLicenceNumber);
                resultingText = resultingText.Replace("<HunterLicenceSerial>", HunterLicenceSerial);
                resultingText = resultingText.Replace("<HunterName>", HunterName);
                resultingText = resultingText.Replace("<HunterPassport>", HunterPassport);
                resultingText = resultingText.Replace("<HunterPhone>", HunterPhone);
                resultingText = resultingText.Replace("<HunterTIN>", HunterTIN);

                if (HunterBirth != null)
                {
                    resultingText = resultingText.Replace("<HunterBirth.DtDay>", HunterBirth.DtDay);
                    resultingText = resultingText.Replace("<HunterBirth.DtMonthInt>", HunterBirth.DtMonthInt);
                    resultingText = resultingText.Replace("<HunterBirth.DtMonthWordGen>", HunterBirth.DtMonthWordGen);
                    resultingText = resultingText.Replace("<HunterBirth.DtMonthWordNom>", HunterBirth.DtMonthWordNom);
                    resultingText = resultingText.Replace("<HunterBirth.DtYear2>", HunterBirth.DtYear2);
                    resultingText = resultingText.Replace("<HunterBirth.DtYear4>", HunterBirth.DtYear4);
                }

                if (HunterLicenceIssue != null)
                {
                    resultingText = resultingText.Replace("<HunterLicenceIssue.DtDay>", HunterLicenceIssue.DtDay);
                    resultingText = resultingText.Replace("<HunterLicenceIssue.DtMonthInt>",
                        HunterLicenceIssue.DtMonthInt);
                    resultingText = resultingText.Replace("<HunterLicenceIssue.DtMonthWordGen>",
                        HunterLicenceIssue.DtMonthWordGen);
                    resultingText = resultingText.Replace("<HunterLicenceIssue.DtMonthWordNom>",
                        HunterLicenceIssue.DtMonthWordNom);
                    resultingText = resultingText.Replace("<HunterLicenceIssue.DtYear2>", HunterLicenceIssue.DtYear2);
                    resultingText = resultingText.Replace("<HunterLicenceIssue.DtYear4>", HunterLicenceIssue.DtYear4);
                }
                /* doc fields */

                resultingText = resultingText.Replace("<DocumentAreaName>", DocumentAreaName);
                resultingText = resultingText.Replace("<DocumentHunterFarmName>", DocumentHunterFarmName);
                resultingText = resultingText.Replace("<DocumentNumber>", DocumentNumber);
                resultingText = resultingText.Replace("<DocumentRegNumber>", DocumentRegNumber);

                resultingText = resultingText.Replace("<DocumentResult>", DocumentResult);
                resultingText = resultingText.Replace("<DocumentSummInt>", DocumentSummInt);
                resultingText = resultingText.Replace("<DocumentSummString>", DocumentSummString);
                resultingText = resultingText.Replace("<DocumentEmployeeName>", DocumentEmployeeName);


                if (DocumentAcitivityDateStart != null)
                {
                    resultingText = resultingText.Replace("<DocumentAcitivityDateStart.DtDay>",
                        DocumentAcitivityDateStart.DtDay);
                    resultingText = resultingText.Replace("<DocumentAcitivityDateStart.DtMonthInt>",
                        DocumentAcitivityDateStart.DtMonthInt);
                    resultingText = resultingText.Replace("<DocumentAcitivityDateStart.DtMonthWordGen>",
                        DocumentAcitivityDateStart.DtMonthWordGen);
                    resultingText = resultingText.Replace("<DocumentAcitivityDateStart.DtMonthWordNom>",
                        DocumentAcitivityDateStart.DtMonthWordNom);
                    resultingText = resultingText.Replace("<DocumentAcitivityDateStart.DtYear2>",
                        DocumentAcitivityDateStart.DtYear2);
                    resultingText = resultingText.Replace("<DocumentAcitivityDateStart.DtYear4>",
                        DocumentAcitivityDateStart.DtYear4);
                }

                if (DocumentAcitivityDateEnd != null)
                {
                    resultingText = resultingText.Replace("<DocumentAcitivityDateEnd.DtDay>",
                        DocumentAcitivityDateEnd.DtDay);
                    resultingText = resultingText.Replace("<DocumentAcitivityDateEnd.DtMonthInt>",
                        DocumentAcitivityDateEnd.DtMonthInt);
                    resultingText = resultingText.Replace("<DocumentAcitivityDateEnd.DtMonthWordGen>",
                        DocumentAcitivityDateEnd.DtMonthWordGen);
                    resultingText = resultingText.Replace("<DocumentAcitivityDateEnd.DtMonthWordNom>",
                        DocumentAcitivityDateEnd.DtMonthWordNom);
                    resultingText = resultingText.Replace("<DocumentAcitivityDateEnd.DtYear2>",
                        DocumentAcitivityDateEnd.DtYear2);
                    resultingText = resultingText.Replace("<DocumentAcitivityDateEnd.DtYear4>",
                        DocumentAcitivityDateEnd.DtYear4);
                }


                if (DocumentIssueDate != null)
                {
                    resultingText = resultingText.Replace("<DocumentIssueDate.DtDay>", DocumentIssueDate.DtDay);
                    resultingText = resultingText.Replace("<DocumentIssueDate.DtMonthInt>", DocumentIssueDate.DtMonthInt);
                    resultingText = resultingText.Replace("<DocumentIssueDate.DtMonthWordGen>",
                        DocumentIssueDate.DtMonthWordGen);
                    resultingText = resultingText.Replace("<DocumentIssueDate.DtMonthWordNom>",
                        DocumentIssueDate.DtMonthWordNom);
                    resultingText = resultingText.Replace("<DocumentIssueDate.DtYear2>", DocumentIssueDate.DtYear2);
                    resultingText = resultingText.Replace("<DocumentIssueDate.DtYear4>", DocumentIssueDate.DtYear4);
                }

                if (DocumentPaymentDate != null)
                {
                    resultingText = resultingText.Replace("<DocumentPaymentDate.DtDay>", DocumentPaymentDate.DtDay);
                    resultingText = resultingText.Replace("<DocumentPaymentDate.DtMonthInt>",
                        DocumentPaymentDate.DtMonthInt);
                    resultingText = resultingText.Replace("<DocumentPaymentDate.DtMonthWordGen>",
                        DocumentPaymentDate.DtMonthWordGen);
                    resultingText = resultingText.Replace("<DocumentPaymentDate.DtMonthWordNom>",
                        DocumentPaymentDate.DtMonthWordNom);
                    resultingText = resultingText.Replace("<DocumentPaymentDate.DtYear2>", DocumentPaymentDate.DtYear2);
                    resultingText = resultingText.Replace("<DocumentPaymentDate.DtYear4>", DocumentPaymentDate.DtYear4);
                }

                if (DocumentRegDate != null)
                {
                    resultingText = resultingText.Replace("<DocumentRegDate.DtDay>", DocumentRegDate.DtDay);
                    resultingText = resultingText.Replace("<DocumentRegDate.DtMonthInt>", DocumentRegDate.DtMonthInt);
                    resultingText = resultingText.Replace("<DocumentRegDate.DtMonthWordGen>",
                        DocumentRegDate.DtMonthWordGen);
                    resultingText = resultingText.Replace("<DocumentRegDate.DtMonthWordNom>",
                        DocumentRegDate.DtMonthWordNom);
                    resultingText = resultingText.Replace("<DocumentRegDate.DtYear2>", DocumentRegDate.DtYear2);
                    resultingText = resultingText.Replace("<DocumentRegDate.DtYear4>", DocumentRegDate.DtYear4);
                }

                if (DocumentReturnDate != null)
                {
                    resultingText = resultingText.Replace("<DocumentReturnDate.DtDay>", DocumentReturnDate.DtDay);
                    resultingText = resultingText.Replace("<DocumentReturnDate.DtMonthInt>",
                        DocumentReturnDate.DtMonthInt);
                    resultingText = resultingText.Replace("<DocumentReturnDate.DtMonthWordGen>",
                        DocumentReturnDate.DtMonthWordGen);
                    resultingText = resultingText.Replace("<DocumentReturnDate.DtMonthWordNom>",
                        DocumentReturnDate.DtMonthWordNom);
                    resultingText = resultingText.Replace("<DocumentReturnDate.DtYear2>", DocumentReturnDate.DtYear2);
                    resultingText = resultingText.Replace("<DocumentReturnDate.DtYear4>", DocumentReturnDate.DtYear4);
                }

                shape.TextFrame.TextRange.Text = resultingText;

            }

            string documentName = ReportTemplateName + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss") + ".docx";

            oDoc.SaveAs(FileName: Environment.CurrentDirectory +"\\Documents"+ "\\"+ documentName);


            DialogResult dialogResult = MessageBox.Show("Распечатать документ?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                oDoc.PrintOut();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }


            oDoc.Close();
            oWord.Application.Quit();

            DialogResult dialogResult2 = MessageBox.Show("Открыть документ?", "", MessageBoxButtons.YesNo);
            if (dialogResult2 == DialogResult.Yes)
            {
                 oWord.Documents.Open(Environment.CurrentDirectory + "\\Documents" + "\\" + documentName);
            }
            else if (dialogResult2 == DialogResult.No)
            {
                //do something else
            }

            

        }

        public string ReportTemplateName;
        public bool f_InstantPrint;

        // Hunter fields
        public string HunterAddress;
        public string HunterLicenceNumber;
        public string HunterLicenceSerial;

        public string HunterName;
        public string HunterPassport;
        public string HunterPhone;
        public string HunterTIN;

        public DateTimeRecordHandler HunterBirth;
        public DateTimeRecordHandler HunterLicenceIssue;

        // Document fields
        // #3
        public DateTimeRecordHandler DocumentAcitivityDateStart;
        public DateTimeRecordHandler DocumentAcitivityDateEnd;
        public DateTimeRecordHandler DocumentIssueDate;
        public DateTimeRecordHandler DocumentPaymentDate;
        public DateTimeRecordHandler DocumentRegDate;
        public DateTimeRecordHandler DocumentReturnDate;
 
        public string DocumentAreaName;
        public string DocumentHunterFarmName;

        public string DocumentNumber;
        public string DocumentRegNumber;
        public string DocumentResult;

        public string DocumentSummInt;
        public string DocumentSummString;

        public string DocumentEmployeeName;

        public void FillDates()
        {
            
        }

    }
}   
