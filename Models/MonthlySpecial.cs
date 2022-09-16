using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace ExploreCalifornia.Models
{
    public class MonthlySpecial
    {
        public long Id { get; set; }
        private string _key;
        public string Key
        {
            get
            {
                if (_key == null)
                {
                    _key = Regex.Replace(Name.ToLower(), "[^a-z0-9]", "-");
                }
                return _key;
            }
            set { _key = value; }
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
    }
}