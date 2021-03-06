﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using TestingSystemDB;

namespace KursovProektPS
{
    public class TestSetupModel : INotifyPropertyChanged
    {
        private List<Discipline> _disciplines;
        public List<Discipline> Disciplines
        {
            get
            {
                return _disciplines;
            }
            set
            {
                _disciplines = value;
                RaisePropertyChanged("Disciplines");
            }
        }
        private Discipline _selection;
        public Discipline Selection
        {
            get
            {
                return _selection;
            }
            set
            {
                _selection = value;
                RaisePropertyChanged("Selection");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
