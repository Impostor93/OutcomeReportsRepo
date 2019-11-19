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
	public partial class PeriodOutcomeReport : ContentPage
	{
		public PeriodOutcomeReport ()
		{
			InitializeComponent ();
		}

        private async void Button_Pressed(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}