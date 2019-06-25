using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestingSystemDB;

namespace KursovProektPS
{
    public class ResultsVM : BaseVM
    {
        private IPrintingService printingService;
        public ResultsModel TestResults { get; set; }

        public ResultsVM()
        {
            resourceName = "results";
            printingService = new PrintingService("test.txt");
        }

        public ResultsVM(ResultsModel testResults)
            :this()
        {
            TestResults = testResults;
        }

        public ICommand PrintTestCommand
        {
            get
            {
                return new RelayCommand(param => printingService.PrintTest((int)param));
            }
        }
    }
}
