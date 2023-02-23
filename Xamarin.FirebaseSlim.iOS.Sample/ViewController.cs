﻿using System;
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
            // Perform any additional setup after loading the view, typically from a nib.

            var image = new UIImageView
            {
                TranslatesAutoresizingMaskIntoConstraints = false
            };

            Add(image);

            UIButton button = AddButton("Rest 03");

            button.TouchUpInside += (s, e) =>
            {
                
            };

            UIButton button2 = AddButton("Test 02");

            button2.TouchUpInside += (s, e) =>
            {
                
            };

            AddConstraints(image, button, button2, skiaView);
        }

        private void AddConstraints(UIImageView image, UIButton button, UIButton button2, SKCanvasView skiaView)
        {
            image.WidthAnchor.ConstraintEqualTo(View.WidthAnchor).Active = true;
            image.HeightAnchor.ConstraintEqualTo(View.WidthAnchor).Active = true;
            image.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor).Active = true;
            image.TopAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.TopAnchor).Active = true;

            button.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor, 16).Active = true;
            button.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor, -16).Active = true;
            button.BottomAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.BottomAnchor, -20).Active = true;

            button2.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor, 16).Active = true;
            button2.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor, -16).Active = true;
            button2.BottomAnchor.ConstraintEqualTo(button.TopAnchor, -20).Active = true;

            skiaView.TopAnchor.ConstraintEqualTo(image.BottomAnchor, 10).Active = true;
            skiaView.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor, 16).Active = true;
            skiaView.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor, -16).Active = true;
            skiaView.BottomAnchor.ConstraintEqualTo(button2.TopAnchor, -16).Active = true;
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