using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSek.Services
{
    public interface INavigationService
    {

        Task NavigateToLogin();
        Task NavigateToMain();

    }
}
