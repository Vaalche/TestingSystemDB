
using System;
using System.ComponentModel;

namespace KursovProektPS
{
    public class ResultsModel : INotifyPropertyChanged
    {

        private int testScore;
        private DateTime testTime;
        private int testID;


        public ResultsModel()
        {
            this.testScore = 0;
            this.testTime = DateTime.MinValue;
        }

        public int TestScore
        {
            get
            {
                return testScore;
            }

            set
            {
                testScore = value;
                RaisePropertyChanged("TestScore");
            }
        }

        public DateTime TestTime
        {
            get
            {
                return testTime;
            }

            set
            {
                testTime = value;
                RaisePropertyChanged("TestTime");
            }
        }

        public int TestID
        {
            get
            {
                return testID;
            }

            set
            {
                testID = value;
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
