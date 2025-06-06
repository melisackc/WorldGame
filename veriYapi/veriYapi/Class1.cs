using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace veriYapi
{
    public class WordModel
    {
        public int WordID { get; set; }
        public string English { get; set; }
        public string Turkish { get; set; }
        public string Sentence { get; set; }
        public string ImagePath { get; set; }
        public int Step { get; set; }
        public DateTime? LastAnsweredDate { get; set; }

    }

}
