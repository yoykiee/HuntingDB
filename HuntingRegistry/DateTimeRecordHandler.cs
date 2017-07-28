using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuntingRegistry
{
    public class DateTimeRecordHandler
    {
        public DateTimeRecordHandler(DateTime dt)
        {
            basicDt = dt;
            FillDts();
        }

        public DateTime basicDt;

        public string DtDay;
        public string DtMonthWordNom; // nominative case
        public string DtMonthWordGen; // generative case

        public string DtMonthInt;
        public string DtYear2;
        public string DtYear4;

        public void FillDts()
        {
            var rus = CultureInfo.GetCultureInfo("ru-RU");
            

            if (basicDt != null)
            {
                DtDay = basicDt.ToString("dd");
                DtMonthWordNom = basicDt.ToString("MMMM");
                DtMonthWordGen = rus.DateTimeFormat.MonthGenitiveNames[basicDt.Month - 1];
                DtMonthInt = basicDt.ToString("MM");

                DtYear2 = basicDt.ToString("yy");
                DtYear4 = basicDt.ToString("yyyy");

            };
            
        }

    }
}
