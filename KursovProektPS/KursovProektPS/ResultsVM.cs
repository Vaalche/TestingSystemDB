using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursovProektPS
{
    public class ResultsVM : BaseVM
    {
        public static int TestScore { get; set; }


        public ResultsVM()
        {

        }

        public ResultsVM(int testScore)
        {
            TestScore = testScore;
        }


    }
}
