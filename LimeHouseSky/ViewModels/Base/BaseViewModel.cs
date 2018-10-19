using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LimeHouseSky.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool Set<T>(ref T oldValue, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (Equals(oldValue, newValue)) return false;
            oldValue = newValue;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
