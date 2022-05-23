using lopushok2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.VisualBasic;
using lopushok2.Models;
using System.Windows.Controls;

namespace lopushok2.Command
{
    public class AddProductCommand : Command
    {
        private ProductsWindowViewModel _viewModel;

        public AddProductCommand(ProductsWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            string title = Interaction.InputBox("Input title", "Filling product row");
            int productTypeid = Convert.ToInt32(Interaction.InputBox("Input productTypeId", "Filling product row"));
            string articleNumber = Interaction.InputBox("Input article number", "Filling product row");
            string description = Interaction.InputBox("Input description", "Filling product row");
            string image = Interaction.InputBox("Input image", "Filling product row");
            int personCount = Convert.ToInt32(Interaction.InputBox("Input person count", "Filling product row"));
            int workshowNumber = Convert.ToInt32(Interaction.InputBox("Input workshop number", "Filling product row"));
            decimal minCostForAgent = Convert.ToDecimal(Interaction.InputBox("Input productTypeId", "Filling product row"));

            Product product = new Product()
            {
                Title = title,
                ProductTypeID = productTypeid,
                ArticleNumber = articleNumber,
                Description = description,
                Image = image,
                ProductionPersonCount = personCount,
                ProductionWorkshopNumber = workshowNumber,
                MinCostForAgent = minCostForAgent
            };

            using(var DbContext = new DatabaseEntities())
            {
                var ProductType = DbContext.ProductTypes
                    .Where(t => t.ID == productTypeid)
                    .FirstOrDefault();

                if(ProductType == default)
                {
                    MessageBox.Show("this type of productType doesn't exists, please try again");
                    return;
                }

                product.ProductType = ProductType;

                DbContext.Products.Add(product);
                DbContext.SaveChanges();

                _viewModel.Products.Add(product);
                (parameter as ItemCollection).Refresh();
            }
        }
    }
}
