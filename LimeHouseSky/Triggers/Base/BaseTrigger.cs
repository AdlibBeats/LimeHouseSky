using Windows.UI.Xaml;

namespace LimeHouseSky.Triggers.Base
{
    public class BaseTrigger : StateTriggerBase
    {
        public void Set<T>(ref T oldValue, T newValue, bool isActive)
        {
            oldValue = newValue;
            SetActive(isActive);
        }
    }
}
