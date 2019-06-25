using System.ComponentModel;

namespace KursovProektPS
{
    public class StatisticsModel : INotifyPropertyChanged
    {
        private int testsCount;
        private string mostTestedDiscipline;

        public int TestsCount
        {
            get
            {
                return testsCount;
            }

            set
            {
                testsCount = value;
                RaisePropertyChanged("TestsCount");
            }
        }

        public string MostTestedDiscipline
        {
            get
            {
                return mostTestedDiscipline;
            }

            set
            {
                mostTestedDiscipline = value;
                RaisePropertyChanged("MostTestedDiscipline");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
