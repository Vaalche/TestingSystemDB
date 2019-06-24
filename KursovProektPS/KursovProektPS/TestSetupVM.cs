using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystemDB;

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
            resourceName = "setup";
            TSInfo = new TestSetupModel();
            TSInfo.Disciplines = PopulateComboBox();
        }

        private bool ConfirmSelect(TestSetupModel s)
        {
            return true;
        }

        private List<Discipline> PopulateComboBox()
        {
            IRepository<Discipline> disciplineRepository = RepositoryFactory.Get<Discipline>();

            using (var ctx = new TestingSystemModel())
            {
                return disciplineRepository.FindBy(discipline => true, ctx).ToList();
            }
        }
    }
}
