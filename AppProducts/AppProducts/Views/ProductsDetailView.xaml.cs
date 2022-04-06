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
    public partial class ProductsDetailView : ContentPage
    {
        public ProductsDetailView()
        {
            InitializeComponent();

            BindingContext = new ProductsDetailViewModel();
        }

        public ProductsDetailView(ProductsListViewModel listViewModel)
        {
            InitializeComponent();

            BindingContext = new ProductsDetailViewModel(listViewModel);
        }
    }
}