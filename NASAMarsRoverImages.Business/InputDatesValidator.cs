using NASAMarsRoverImages.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace NASAMarsRoverImages.Business
{
    public class InputDatesValidator : IInputDatesValidator
    {
        public IEnumerable<DateTime> GetDatesFromSource(string txtFileSource)
        {            
            if (File.Exists(txtFileSource))
            {
                CultureInfo enUS = new CultureInfo("en-US");
                var validDateFormats = new string[] { "MM/dd/yy", "MMMM d, yyyy", "MMM-dd-yyyy" };

                List<DateTime> dates = new List<DateTime>();
                string line;
                var file = new StreamReader(txtFileSource);
                while ((line = file.ReadLine()) != null)
                {
                    if (DateTime.TryParseExact(line, validDateFormats, enUS, DateTimeStyles.None, out DateTime date))
                    {
                        dates.Add(date);
                    }
                }

                file.Close();
                return dates;
            }
            else
            {
                throw new ArgumentException("Cannot find the text file");
            }
        }
    }
}
