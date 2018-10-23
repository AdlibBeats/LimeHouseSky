using LimeHouseSky.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimeHouseSky.Models.Photo
{
    public class PhotoItemModel : BaseModel
    {
        private string _photoUrl;
        public string PhotoUrl
        {
            get => _photoUrl;
            set => Set(ref _photoUrl, value);
        }
    }
}
