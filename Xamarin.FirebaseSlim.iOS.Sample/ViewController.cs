using System;
using Foundation;
using ObjCRuntime;
using SkiaSharp;
using SkiaSharp.Views.iOS;
using UIKit;
using Xamarin.FirebaseSlim.iOS;

namespace Sample
{
    public partial class ViewController : UIViewController
    {
        private SKBitmap _bitmap;

        public ViewController(NativeHandle handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
            

            var image = new UIImageView
            {
                TranslatesAutoresizingMaskIntoConstraints = false
            };

            Add(image);

            AddButton("Rest 03");

            AddButton("Test 02");

        }


        private UIButton AddButton(string title)
        {
            var button = new UIButton
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                BackgroundColor = UIColor.Orange
            };
            button.SetTitleColor(UIColor.Black, UIControlState.Normal);
            button.SetTitle(title, UIControlState.Normal);

            Add(button);
            return button;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}