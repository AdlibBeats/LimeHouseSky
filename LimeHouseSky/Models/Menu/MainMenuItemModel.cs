using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LimeHouseSky.Models.Base;

namespace LimeHouseSky.Models.Menu
{
    public class MainMenuItemModel : BaseModel
    {
        private string _text;
        public string Text
        {
            get => _text;
            set => Set(ref _text, value);
        }
    }
}
