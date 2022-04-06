using AppProducts.Models;
using AppProducts.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppProducts.ViewModels
{
    public class ProductsDetailViewModel : BaseViewModel
    {
        // Variables locales
        public readonly ProductsListViewModel ListViewModel;

        // Comandos
        private Command _SaveCommand;
        public Command SaveCommand => _SaveCommand ?? (_SaveCommand = new Command(SaveAction));

        // Propiedades
        private int _ProductID;
        public int ProductID 
        {
            get => _ProductID;
            set => SetProperty(ref _ProductID, value);
        }

        private string _ProductCategory;
        public string ProductCategory
        {
            get => _ProductCategory;
            set => SetProperty(ref _ProductCategory, value);
        }

        private string _ProductModel;
        public string ProductModel
        {
            get => _ProductModel;
            set => SetProperty(ref _ProductModel, value);
        }

        private string _ProductDesigner;
        public string ProductDesigner
        {
            get => _ProductDesigner;
            set => SetProperty(ref _ProductDesigner, value);
        }

        private string _ProductDescription;
        public string ProductDescription
        {
            get => _ProductDescription;
            set => SetProperty(ref _ProductDescription, value);
        }

        private float _ProductPrice;
        public float ProductPrice
        {
            get => _ProductPrice;
            set => SetProperty(ref _ProductPrice, value);
        }

        private string _ProductPicture;
        public string ProductPicture
        {
            get => _ProductPicture;
            set => SetProperty(ref _ProductPicture, value);
        }

        // Constructores
        public ProductsDetailViewModel()
        {
        }

        public ProductsDetailViewModel(ProductsListViewModel listViewModel)
        {
            ListViewModel = listViewModel;
        }

        // Métodos
        private async void SaveAction()
        {
            ApiResponse response;
            try
            {
                // Iniciamos el spinner
                IsBusy = true;

                // Creamos el modelo con los datos de los controles
                ProductModel model = new ProductModel
                {
                    ID = ProductID,
                    Model = ProductModel,
                    Category = ProductCategory,
                    Price = ProductPrice,
                    Picture = ProductPicture,
                    Description = ProductDescription,
                    Designer = ProductDesigner
                };

                if (model.ID == 0)
                {
                    // Crear un nuevo producto
                    response = await new ApiService().PostDataAsync("Product", model);
                }
                else
                {
                    // Actualizar un producto existente
                    response = await new ApiService().PutDataAsync("Product", model);
                }

                // Si no fue satisfactorio enviamos un mensaje y terminamos el método
                if (response == null || !response.IsSuccess)
                {
                    IsBusy = false;
                    await Application.Current.MainPage.DisplayAlert("AppProducts", response.Message, "Ok");
                    return;
                }

                // Actualizamos el listado de productos
                ListViewModel.RefreshProducts();

                // Cerramos la vista actual
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("AppProducts", $"Se generó un error al guardar el producto: {ex.Message}", "Ok");
            }
        }
    }
}
