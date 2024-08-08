using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crypto.Core;

namespace Crypto.Services.Interfaces
{
    interface INavigationService
    {
        BaseViewModel CurrentViewModel { get ;}
        void Navigate<TViewModel>() where TViewModel : BaseViewModel;
    }
}