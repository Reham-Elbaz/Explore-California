using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.Models
{
    public class FormattingServices
    {
        public string AaReadableDate(DateTime date) 
        {
            return date.ToString("d");
        }
    }
}
