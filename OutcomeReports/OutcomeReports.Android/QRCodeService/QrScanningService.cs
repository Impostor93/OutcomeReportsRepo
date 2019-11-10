using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using OutcomeReport.QRService;
using ZXing.Mobile;
using Xamarin.Forms;
using System.Threading.Tasks;
using OutcomeReports.Domain.ViewModels;
using OutcomeReports.ViewModels;

[assembly: Dependency(typeof(OutcomeReports.Droid.QRCodeService.QrScanningService))]

namespace OutcomeReports.Droid.QRCodeService
{
    public class QrScanningService : IQrScanningService
    {
        public async Task<LineViewModel> ScanAsync()
        {
            try
            {
                var optionsDefault = new MobileBarcodeScanningOptions();
                var optionsCustom = new MobileBarcodeScanningOptions();

                var scanner = new MobileBarcodeScanner()
                {
                    TopText = "Scan the QR Code",
                    BottomText = "Please Wait",
                };

                var scanResult = await scanner.Scan(optionsCustom);
                return ParseText(scanResult?.Text);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return null;
            }
        }

        private LineViewModel ParseText(string text)
        {
            if (string.IsNullOrEmpty(text))
                return null;

            var splitedContent = text.Split('*');
            if (splitedContent.Length <= 0)
                return null;

            var vm = new LineViewModel();
            if (ReferenceEquals(vm, null))
                return null;

            var date = DateTime.MinValue;
            if (DateTime.TryParse($"{splitedContent[2]} {splitedContent[3]}", out date))
            {
                vm.Date = date;
            }
            var amount = 0d;
            if (double.TryParse(splitedContent[4], out amount))
            {
                vm.Amount = amount;
            }

            return vm;
        }
    }
}