using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursovProektPS
{
    public class BaseVM : INotifyPropertyChanged
    {
        protected string resourceName;
        protected void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string ResourceName
        {
            get
            {
                return resourceName;
            }
            set
            {
                this.resourceName = value;
                RaisePropertyChanged("ResourceName");
            }
        }
    }
}

