using lopushok2.Command;
using lopushok2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace lopushok2.ViewModels
{
    public class ProductsWindowViewModel : ViewModel
    {
        private string _title;
        private int _productTypeId;
        private string _articleNumber;
        private string _description;
        private string _image;
        private int _productionPersonCount;
        private int _productionWorkshopNumber;
        private decimal _minCostForAgent;

        private List<Product> _products;
        private object _selectedProduct;

        public ICommand AddProduct => new AddProductCommand(this);
        public ICommand DeletepProduct => new DeleteProductCommand(this);
        public ICommand UpdateProduct => new UpdateProductCommand(this);

        public ProductsWindowViewModel()
        {
            using (var DbContext = new DatabaseEntities())
            {
                _products = DbContext.Products
                    .Include(nameof(ProductType))
                    .ToList();
            }
        }

        public List<Product> Products
        {
            get => _products;
            set => Set(ref _products, value, nameof(Products));
        }

        public object SelectedProduct
        {
            get => _selectedProduct;
            set => Set(ref _selectedProduct, value, nameof(SelectedProduct));
        }

        public string Title
        {
            get => _title;
            set => Set(ref _title, value, nameof(Title));
        }

        public int ProductTypeId
        {
            get => _productTypeId;
            set => Set(ref _productTypeId, value, nameof(ProductTypeId));
        }

        public string ArticleNumber
        {
            get => _articleNumber;
            set => Set(ref _articleNumber, value, nameof(ArticleNumber));
        }

        public string Description
        {
            get => _description;
            set => Set(ref _description, value, nameof(Description));
        }

        public string Image
        {
            get => _image;
            set => Set(ref _image, value, nameof(Image));
        }

        public int ProductionPersonCount
        {
            get => _productionPersonCount;
            set => Set(ref _productionPersonCount, value, nameof(ProductionPersonCount));
        }

        public int ProductionWorkshopNumber
        {
            get => _productionWorkshopNumber;
            set => Set(ref _productionWorkshopNumber, value, nameof(ProductionWorkshopNumber));
        }

        public decimal MinCostForAgent
        {
            get => _minCostForAgent;
            set => Set(ref _minCostForAgent, value, nameof(MinCostForAgent));
        }
    }
}
