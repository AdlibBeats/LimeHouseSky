using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

using static LimeHouseSky.UI.Controls.Base.BaseSkyStates;

namespace LimeHouseSky.UI.Controls.Base
{
    public class BaseSkyButton : ContentControl
    {
        protected Grid LocalSkyMainGrid { get; private set; }

        protected bool IsPressed { get; private set; }
        protected bool IsPointerOver { get; private set; }

        public BaseSkyButton()
        {
            DefaultStyleKey = typeof(BaseSkyButton);

            SizeChanged += OnSizeChanged;
            IsEnabledChanged += OnEnabledChanged;
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e) =>
            UpdateCornerRadius();

        private void OnEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            VisualStateManager.GoToState(this, IsEnabled ?
                (IsPressed || IsPointerOver ?
                $"{PointerOver}" : $"{Normal}") :
                $"{Disabled}", true);
        }

        private void RemoveEvents()
        {
            if (LocalSkyMainGrid != null)
            {
                LocalSkyMainGrid.PointerEntered -= OnPointerEntered;
                LocalSkyMainGrid.PointerExited -= OnPointerExited;
                LocalSkyMainGrid.PointerPressed -= OnPointerPressed;
                LocalSkyMainGrid.PointerReleased -= OnPointerReleased;
            }
        }

        private void SetEvents()
        {
            if (LocalSkyMainGrid != null)
            {
                LocalSkyMainGrid.PointerEntered += OnPointerEntered;
                LocalSkyMainGrid.PointerExited += OnPointerExited;
                LocalSkyMainGrid.PointerPressed += OnPointerPressed;
                LocalSkyMainGrid.PointerReleased += OnPointerReleased;
            }
        }

        protected override void OnApplyTemplate()
        {
            RemoveEvents();

            base.OnApplyTemplate();

            LocalSkyMainGrid = GetTemplateChild<Grid>(nameof(LocalSkyMainGrid));
            
            SetEvents();
        }

        protected T GetTemplateChild<T>(string childName) where T : DependencyObject =>
            GetTemplateChild(childName) as T;

        private void OnPointerEntered(object sender, PointerRoutedEventArgs e)
        {
            IsPointerOver = true;
            VisualStateManager.GoToState(this, IsPressed ? $"{Pressed}" : $"{PointerOver}", true);
        }

        private void OnPointerExited(object sender, PointerRoutedEventArgs e)
        {
            IsPointerOver = false;
            IsPressed = false;
            VisualStateManager.GoToState(this, $"{Normal}", true);
        }

        private void OnPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            IsPressed = true;
            VisualStateManager.GoToState(this, IsPointerOver ? $"{Pressed}" : $"{PointerOver}", true);
        }

        private void OnPointerReleased(object sender, PointerRoutedEventArgs e)
        {
            IsPressed = false;
            VisualStateManager.GoToState(this, IsPointerOver ? $"{PointerOver}" : $"{Normal}", true);
        }

        protected void UpdateCornerRadius()
        {
            if (LocalSkyMainGrid == null) return;
            if (IsCornerRadiusVisible)
                LocalSkyMainGrid.CornerRadius =
                    CornerRadius.Equals(default) ? new CornerRadius(ActualHeight / 2) : CornerRadius;
            else
                LocalSkyMainGrid.CornerRadius = default;
        }

        public bool IsCornerRadiusVisible
        {
            get => (bool)GetValue(IsCornerRadiusVisibleProperty);
            set => SetValue(IsCornerRadiusVisibleProperty, value);
        }

        public static readonly DependencyProperty IsCornerRadiusVisibleProperty =
            DependencyProperty.Register(nameof(IsCornerRadiusVisible), typeof(bool), typeof(BaseSkyButton),
                new PropertyMetadata(false, (d, e) => ((BaseSkyButton)d).UpdateCornerRadius()));

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(BaseSkyButton),
                new PropertyMetadata(default, (d, e) => ((BaseSkyButton)d).UpdateCornerRadius()));
    }
}