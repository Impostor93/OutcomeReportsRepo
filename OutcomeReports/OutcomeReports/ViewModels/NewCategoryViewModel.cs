using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OutcomeReports.ViewModels
{
    public class NewCategoryViewModel : BaseViewModel
    {
        public NewCategoryViewModel()
        {
            AddCategory = new Command(async () =>
            {
                MessagingCenter.Send(this, "AddCategory", Name);
                await Navigation.PopModalAsync();
            });
            Cancel = new Command(async () =>
            {
                await Navigation.PopModalAsync();
            });
            
        }

        public INavigation Navigation { get; set; }

        string name;
        public string Name {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        public ICommand AddCategory { get; set; }

        public ICommand Cancel { get; set; }
    }
}
