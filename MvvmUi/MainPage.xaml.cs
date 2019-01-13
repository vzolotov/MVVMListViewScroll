using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MvvmUi
{
    public partial class MainPage : ContentPage, IMoveToItem
    {
        private MainViewModel vm;
        public MainPage()
        {
            InitializeComponent();
            Appearing += MainPage_Appearing;
        }

        void MainPage_Appearing(object sender, EventArgs e)
        {
            Appearing -= MainPage_Appearing;
            vm = BindingContext as MainViewModel;
            vm.NavigatedTo(this);
        }


        public void MoveTo(int position)
        {
            var items = listView.ItemsSource.OfType<object>().ToArray();
            listView.ScrollTo(items[position], ScrollToPosition.MakeVisible, true);
        }
    }
}
