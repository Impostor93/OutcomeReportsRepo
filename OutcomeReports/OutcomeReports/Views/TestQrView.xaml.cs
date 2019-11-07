using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OutcomeReports.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestQrView : ContentPage
    {

        public string QrString { get; set; }

        public TestQrView(string qrString)
        {
            InitializeComponent();

            QrString = qrString;

            var splitedContent = QrString.Split('*');
            var number = splitedContent[0];
            var number1 = splitedContent[1];
            var date = splitedContent[2];
            var hour = splitedContent[3];
            var amount = splitedContent[4];

            BindingContext = this;
        }
    }
}