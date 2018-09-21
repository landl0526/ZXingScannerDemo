using Foundation;
using System;
using System.Diagnostics;
using UIKit;
using ZXing.Mobile;

namespace ZXingScannerDemo
{
    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void BtnClick(UIKit.UIButton sender)
        {
            MobileBarcodeScanner scanner = new MobileBarcodeScanner();
            ZXingScannerViewController scannerViewController = new ZXingScannerViewController(MobileBarcodeScanningOptions.Default, scanner);
            NavigationController.PushViewController(scannerViewController, true);

            scannerViewController.OnScannedResult += (result) =>
            {
                InvokeOnMainThread(() =>
                {
                    NavigationController.PopViewController(true);
                    Debug.WriteLine("Scanned Barcode: " + result.Text);
                });
                
            };           
        }

        async partial void PresentBtnClick(UIKit.UIButton sender)
        {
            var scanner = new MobileBarcodeScanner();
            var result = await scanner.Scan();

            if (result != null)
                Console.WriteLine("Scanned Barcode: " + result.Text);
        }
    }
}