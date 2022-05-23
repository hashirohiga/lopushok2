using lopushok2.Models;
using lopushok2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace lopushok2.Command
{
    public class DeleteProductCommand : Command
    {
        private ProductsWindowViewModel _viewModel;

        public DeleteProductCommand(ProductsWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if(_viewModel.SelectedProduct == null)
            {
                MessageBox.Show("Please select row to delete them.");
                return;
            }

            int productId = (_viewModel.SelectedProduct as Product).ID;

            using(var DbContext = new DatabaseEntities())
            {
                var product = DbContext.Products
                    .Where(p => p.ID == productId)
                    .Single();

                DbContext.Products.Remove(product);
                DbContext.SaveChanges();

                _viewModel.Products.Remove(product);
                (parameter as ItemCollection).Refresh();
            }

            UpdateProducts();
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
