using LimeHouseSky.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimeHouseSky.Pages
{
    interface IPage
    {
        object DataContext { get; set; }
    }
}
