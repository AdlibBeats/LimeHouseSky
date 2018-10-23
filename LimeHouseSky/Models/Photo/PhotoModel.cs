using LimeHouseSky.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimeHouseSky.Models.Photo
{
    public class PhotoModel : BaseModel
    {
        private PhotoItemModel _mainPhoto;
        public PhotoItemModel MainPhoto
        {
            get => _mainPhoto;
            set => Set(ref _mainPhoto, value);
        }

        private ObservableCollection<PhotoItemModel> _photos;
        public ObservableCollection<PhotoItemModel> Photos
        {
            get => _photos;
            set => Set(ref _photos, value);
        }
    }
}
