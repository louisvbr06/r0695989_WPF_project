using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.ViewModel
{
    class TypeViewModel
    {
        public TypeViewModel typeViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TypeViewModel>();
            }
        }
    }


}
