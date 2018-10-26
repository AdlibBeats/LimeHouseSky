using LimeHouseSky.Triggers.Base;

namespace LimeHouseSky.Triggers.Double.And
{
    public class DoubleBooleanTrigger : BaseTrigger
    {
        private bool _isFirstActive;
        public bool IsFirstActive
        {
            get => _isFirstActive;
            set => Set(ref _isFirstActive, value, value && IsSecondActive);
        }

        private bool _isSecondActive;
        public bool IsSecondActive
        {
            get => _isSecondActive;
            set => Set(ref _isSecondActive, value, value && IsFirstActive);
        }
    }
}