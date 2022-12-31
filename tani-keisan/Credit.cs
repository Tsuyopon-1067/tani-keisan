using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tani_keisan
{
    public class Credit
    {
        public string subjectName { get; set; }
        public SuubjectCategoryType category { get; set; }
        public int credit { get; set; }
        public Credit(string subjectName, SuubjectCategoryType category, int credit) 
        {
            this.subjectName= subjectName;
            this.category= category;
            this.credit = credit;
        }
        public Credit() : this("", 0, 0)
        {
        }
        public override string ToString()
        {
            return subjectName + ", " + category.ToString() + ", " + credit.ToString();
        }
    }
    public enum SuubjectCategoryType
    {
        kyouyouA,
        kyouyouB,
        gakusaiA,
        kyouyouOther,
        senmonA,
        senmonB,
        senmonC,
        free
    }
}
