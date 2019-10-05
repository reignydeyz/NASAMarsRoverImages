using System;
using System.Collections.Generic;
using System.Text;

namespace NASAMarsRoverImages.Business.Interfaces
{
    public interface IInputDatesValidator
    {
        /// <summary>
        /// Gets the date from the text file
        /// </summary>
        /// <param name="txtFileSource"></param>
        /// <returns></returns>
        IEnumerable<DateTime> GetDatesFromSource(string txtFileSource);
    }
}
