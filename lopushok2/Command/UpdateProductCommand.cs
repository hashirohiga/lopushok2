using lopushok2.Models;
using lopushok2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace lopushok2.Command
{
    public class UpdateProductCommand : Command
    {
        private ProductsWindowViewModel _viewModel;

        public UpdateProductCommand(ProductsWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            UpdateProducts();
            (parameter as ItemCollection).Refresh();
        }

        private void UpdateProducts()
        {
            using (var DbContext = new DatabaseEntities())
            {
                _viewModel.Products = DbContext.Products
                    .Include(nameof(ProductType))
                    .ToList();
            }
        }
    }
}
