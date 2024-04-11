using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class Helper
    {
        public static bool NameAndSurnameCheck(this string name)
        {
            return !string.IsNullOrWhiteSpace(name) && name.Length >= 3 && name.Split(' ').Length == 1 && char.IsUpper(name[0]);
        }
       
        public static bool ClassNameCheck(this string className)
        {
            return className.Length == 5 && char.IsUpper(className[0]) && char.IsUpper(className[1]) &&
                   char.IsDigit(className[2]) && char.IsDigit(className[3]) && char.IsDigit(className[4]);
        }
    }
}
