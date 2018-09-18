using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursovProektPS
{
    class TestSetupVM : BaseVM
    {
        private TestSetupModel _tSInfo;
        public TestSetupModel TSInfo
        {
            get
            {
                return _tSInfo;
            }
            set
            {
                _tSInfo = value;
                RaisePropertyChanged("TSInfo");
            }
        }

        public TestSetupVM()
        {
            TSInfo = new TestSetupModel();
            TSInfo.Disciplines = PopulateComboBox();
        }

        private bool ConfirmSelect(TestSetupModel s)
        {
            return true;
        }

        private List<string> PopulateComboBox()
        {
            //tuka she pulnim ot bazata list s disciplini 
            return new List<string>() { "математика", "история", "биология", "литература" };
        }
    }
}
