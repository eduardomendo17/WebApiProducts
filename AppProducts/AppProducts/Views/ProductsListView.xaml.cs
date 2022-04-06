using AppProducts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppProducts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsListView : ContentPage
    {
        public ProductsListView()
        {
            InitializeComponent();

            BindingContext = new ProductsListViewModel();
        }
    }
}