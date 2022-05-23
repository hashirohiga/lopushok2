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
    public class AddMaterialCommand :Command
    {
        private MaterialsWindowViewModel _viewModel;

        public AddMaterialCommand(MaterialsWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            string title = Interaction.InputBox("Input title", "Filling material row");
            int countInPack = Convert.ToInt32(Interaction.InputBox("input countInPack", "Filling material row"));
            string unit = Interaction.InputBox("Input unit", "Filling material row");
            float countInStock = Convert.ToSingle(Interaction.InputBox("Input countInStock", "Fillint material row"));
            float minCount = Convert.ToSingle(Interaction.InputBox("Input MinCount", "Filing material row"));
            decimal cost = Convert.ToDecimal(Interaction.InputBox("Input Cost", "Filling material row"));
            string description = Interaction.InputBox("Input description", "Filling material row");
            string image = Interaction.InputBox("Input image", "Filling material row");
            int materialTypeID = Convert.ToInt32(Interaction.InputBox("Input materialTypeID", "Filling material row"));
          

            Material material = new Material()
            {
                Title = title,
                MaterialTypeID = materialTypeID,
                CountInPack = countInPack,
                Unit = unit,
                CountInStock = countInStock,
                MinCount = minCount,
                Cost = cost,
                Description = description,
                Image = image,
               
            };
            using (var DbContext = new DatabaseEntities())
            {
                var MaterialType = DbContext.MaterialTypes
                    .Where(t => t.ID == materialTypeID)
                    .FirstOrDefault();

                if (MaterialType == default)
                {
                    MessageBox.Show("this type of productType doesn't exists, please try again");
                    return;
                }

                material.MaterialType = MaterialType;

                DbContext.Materials.Add(material);
                DbContext.SaveChanges();

                _viewModel.Material.Add(material);
                (parameter as ItemCollection).Refresh();
            }

        }
    }
}
