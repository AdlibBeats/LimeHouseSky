using LimeHouseSky.Extensions;
using LimeHouseSky.ViewModels;
using Microsoft.Graphics.Canvas.Effects;
using Microsoft.Toolkit.Uwp.UI.Animations.Expressions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace LimeHouseSky.Pages.Main
{
    public sealed partial class MainMenuPage : Page, IPage
    {
        private CompositionPropertySet _props;
        private CompositionPropertySet _scrollProperties;
        private Compositor _compositor;
        private SpriteVisual _blurredBackgroundImageVisual;

        private SpringVector3NaturalMotionAnimation _springAnimation;
        private bool _imageClickScaleMode;
        private ExpressionNode _translationDeltaExp;

        private ExpressionNode _parallaxExpression;

        public MainMenuViewModel ViewModel { get; }

        public MainMenuPage()
        {
            InitializeComponent();

            ViewModel = new MainMenuViewModel();
        }

        private void OnListBoxLoaded(object sender, RoutedEventArgs e)
        {
            if (!(sender is ListBox listBox)) return;
            if (!(listBox.ItemsPanelRoot is VirtualizingStackPanel itemsPanelRoot)) return;

            if (!(itemsPanelRoot.Children.FirstOrDefault() is FrameworkElement frameworkElement)) return;

            // Grab the existing Compositor for this page
            _compositor = ElementCompositionPreview.GetElementVisual(this).Compositor;

            // Define the Spring Animation that will be used to animate images
            // Create a SpringVector3Animation since we will be animating Scale
            _springAnimation = _compositor.CreateSpringVector3Animation();
            _springAnimation.DampingRatio = 0.5f;
            _springAnimation.Period = TimeSpan.FromSeconds(.05);

            // Track if an image has been clicked, initially set to false
            _imageClickScaleMode = false;

            // Setup the Expressions to manage list layout
            var visualPlaceHolder = ExpressionValues.Reference.CreateVisualReference("visual");
            var factor = ExpressionValues.Constant.CreateConstantScalar("factor");
            _translationDeltaExp =
                ((visualPlaceHolder.Scale.Y - 1) * (float)frameworkElement.ActualHeight) + ExpressionFunctions.Conditional(((visualPlaceHolder.Translation.Y / (120 * factor)) > 1),
                (ExpressionValues.Constant.CreateConstantScalar("largeScaleDiff")),
                visualPlaceHolder.Translation.Y % (120 * factor));

            int itemIndex = 0;
            foreach (var child in itemsPanelRoot.Children)
            {
                if (!(child is SelectorItem selectorItem)) continue;

                selectorItem.PointerEntered -= OnElementPointerEntered;
                selectorItem.PointerExited -= OnElementPointerExited;
                //selectorItem.PointerReleased -= OnElementPointerReleased;

                // Activate Translation property on the UIElement images
                ElementCompositionPreview.SetIsTranslationEnabled(selectorItem, true);
                var visual = ElementCompositionPreview.GetElementVisual(selectorItem);
                visual.Properties.InsertVector3("Translation", new Vector3(0));

                //SetParallaxAtSelectorItem(selectorItem, itemIndex);

                selectorItem.PointerEntered += OnElementPointerEntered;
                selectorItem.PointerExited += OnElementPointerExited;
                //selectorItem.PointerReleased += OnElementPointerReleased;

                itemIndex++;
            }

            if (itemsPanelRoot.Children.Count > 1)
            {
                for (int i = 1, j = 0; i < itemsPanelRoot.Children.Count - 1; i++, j++)
                {
                    // Retrieve references to the target Visual of the Expression along with the vertical neighbor we need to reference
                    var targetVisual = ElementCompositionPreview.GetElementVisual(itemsPanelRoot.Children[i]);
                    var referenceVisual = ElementCompositionPreview.GetElementVisual(itemsPanelRoot.Children[j]);

                    // Set the references to the Expression and Start it on the target Visual
                    _translationDeltaExp.SetReferenceParameter("visual", referenceVisual);
                    _translationDeltaExp.SetScalarParameter("factor", i);
                    _translationDeltaExp.SetScalarParameter("largeScaleDiff", 2 * (float)frameworkElement.ActualHeight);
                    targetVisual.StartAnimation("Translation.Y", _translationDeltaExp);
                }
            }

            void OnElementPointerEntered(object s, PointerRoutedEventArgs args)
            {
                // Animating the image only if not been previously clicked
                if (!_imageClickScaleMode)
                {
                    _springAnimation.FinalValue = new Vector3(1.025f);
                    var visual = ElementCompositionPreview.GetElementVisual((UIElement)s);
                    visual.StartAnimation("Scale", _springAnimation);
                }
            }

            void OnElementPointerExited(object s, PointerRoutedEventArgs args)
            {
                // Animating the image only if not been previously clicked
                if (!_imageClickScaleMode)
                {
                    _springAnimation.FinalValue = new Vector3(1f);
                    var visual = ElementCompositionPreview.GetElementVisual((UIElement)s);
                    visual.StartAnimation("Scale", _springAnimation);
                }
            }

            //SelectionMode = None
            //void OnElementPointerReleased(object s, PointerRoutedEventArgs args)
            //{
            //    // If not previously clicked, then scale to large size else scale to original size
            //    _springAnimation.FinalValue = new Vector3(!_imageClickScaleMode ? 2.05f : 1f);
            //    _imageClickScaleMode = !_imageClickScaleMode ? true : false;
            //    var visual = ElementCompositionPreview.GetElementVisual((UIElement)s);
            //    visual.StartAnimation("Scale", _springAnimation);
            //}
        }

        //private void SetParallaxAtSelectorItem<T>(T selectorItem, int itemIndex = 0) where T : SelectorItem
        //{
        //    if (selectorItem == null) return;

        //    Image image = selectorItem.ContentTemplateRoot.GetFirstDescendantOfType<Image>();

        //    Visual visual = ElementCompositionPreview.GetElementVisual(image);
        //    visual.Size = new Vector2(360f, 360f);

        //    if (_parallaxExpression != null)
        //    {
        //        _parallaxExpression.SetScalarParameter("StartOffset", (float)itemIndex * visual.Size.Y / 4.0f);
        //        visual.StartAnimation("Offset.Y", _parallaxExpression);
        //    }
        //}

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _scrollProperties = ElementCompositionPreview.GetScrollViewerManipulationPropertySet(RootScrollViewer);
            _compositor = _scrollProperties.Compositor;

            _props = _compositor.CreatePropertySet();
            _props.InsertScalar("progress", 0);
            _props.InsertScalar("clampSize", 120);

            var scrollProperties = _scrollProperties.GetSpecializedReference<ManipulationPropertySetReferenceNode>();
            var props = _props.GetReference();
            var progressNode = props.GetScalarProperty("progress");
            var clampSizeNode = props.GetScalarProperty("clampSize");

            var startOffset = ExpressionValues.Constant.CreateConstantScalar("startOffset", 0.0f);
            var parallaxValue = 0.5f;
            var parallax = (scrollProperties.Translation.Y + startOffset);
            _parallaxExpression = parallax * parallaxValue - parallax;

            // Create a blur effect to be animated based on scroll position
            var blurEffect = new GaussianBlurEffect()
            {
                Name = "blur",
                BlurAmount = 0.0f,
                BorderMode = EffectBorderMode.Hard,
                Optimization = EffectOptimization.Quality,
                Source = new CompositionEffectSourceParameter("source")
            };

            var blurBrush = _compositor.CreateEffectFactory(
                blurEffect,
                new[] { "blur.BlurAmount" })
                .CreateBrush();

            blurBrush.SetSourceParameter("source", _compositor.CreateBackdropBrush());

            // Create a Visual for applying the blur effect
            _blurredBackgroundImageVisual = _compositor.CreateSpriteVisual();
            _blurredBackgroundImageVisual.Brush = blurBrush;
            _blurredBackgroundImageVisual.Size = new Vector2((float)OverlayRectangle.ActualWidth, (float)OverlayRectangle.ActualHeight);

            // Insert the blur visual at the right point in the Visual Tree
            ElementCompositionPreview.SetElementChildVisual(OverlayRectangle, _blurredBackgroundImageVisual);

            ExpressionNode progressAnimation = ExpressionFunctions.Clamp(-scrollProperties.Translation.Y / clampSizeNode, 0, 1);
            _props.StartAnimation("progress", progressAnimation);

            ExpressionNode blurAnimation = ExpressionFunctions.Lerp(0, 10, progressNode);
            _blurredBackgroundImageVisual.Brush.Properties.StartAnimation("blur.BlurAmount", blurAnimation);

            Visual headerVisual = ElementCompositionPreview.GetElementVisual(Header);

            ExpressionNode headerTranslationAnimation = ExpressionFunctions.Conditional(progressNode < 1, 0, -scrollProperties.Translation.Y - clampSizeNode);
            headerVisual.StartAnimation("Offset.Y", headerTranslationAnimation);
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            if (_parallaxExpression != null)
            {
                // (TODO) Re-add this in after Dispose() implemented on ExpressionNode
                //_parallaxExpression.Dispose();
                _parallaxExpression = null;
            }

            if (_scrollProperties != null)
            {
                _scrollProperties.Dispose();
                _scrollProperties = null;
            }
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (_blurredBackgroundImageVisual != null)
            {
                _blurredBackgroundImageVisual.Size = new Vector2((float)OverlayRectangle.ActualWidth, (float)OverlayRectangle.ActualHeight);
            }
        }

        private void OnListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(sender is Selector selector)) return;

            if (selector.SelectedIndex != -1)
                selector.SelectedIndex = -1;
        }
    }
}
