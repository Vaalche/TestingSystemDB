using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursovProektPS
{
    class ResultsVM : BaseVM
    {
        private BaseVM _viewModel;

        public BaseVM ViewModel
        {
            get
            {
                return _viewModel;
            }

            private set
            {
                this._viewModel = value;
                RaisePropertyChanged("ViewModel");
            }
        }
    }
}
