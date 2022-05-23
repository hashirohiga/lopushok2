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
    public class MaterialsWindowViewModel : ViewModel
    {
        private string _title;
        private int _countInPack;
        private string _unit;
        private float _countInStock;
        private float _minCount;
        private string _description;
        private decimal _cost;
        private string _image;
        private int _materialTypeID;

        private List<Material> _material;
        private object _selectedMaterial;

        public ICommand AddProduct => new AddMaterialCommand(this);
        public ICommand DeletepProduct => new DeleteMaterialCommand(this);
        public ICommand UpdateProduct => new UpdateMaterialCommand(this);

        public MaterialsWindowViewModel()
        {
            using (var DbContext = new DatabaseEntities())
            {
                _material = DbContext.Materials
                    .Include(nameof(MaterialType))
                    .ToList();
            }
        }


        public List<Material> Material
        {
            get => _material;
            set => Set(ref _material, value, nameof(Material));
        }
        public object SelectedMaterial
        {
            get => _selectedMaterial;
            set => Set(ref _selectedMaterial, value, nameof(SelectedMaterial));
        }
        public string Title
        {
            get => _title;
            set => Set(ref _title, value, nameof(Title));
        }
        public int CountInPack
        {
            get => _countInPack;
            set => Set(ref _countInPack, value, nameof(CountInPack));
        }
        public float CountInStock
        {
            get => _countInStock;
            set => Set(ref _countInStock, value, nameof(CountInStock));
        }
        public decimal Cost
        {
            get => _cost;
            set => Set(ref _cost, value, nameof(Cost));
        }
        public string Image
        {
            get => _image;
            set => Set(ref _image, value, nameof(Image));
        }
        public string Unit
        {
            get => _unit;
            set => Set(ref _unit, value, nameof(Unit));
        }
        public string Description
        {
            get => _description;
            set => Set(ref _description, value, nameof(Description));
        }
        public float MinCount
        {
            get => _minCount;
            set => Set(ref _minCount, value, nameof(MinCount));
        }
        public int MaterialTypeID
        {
            get => _materialTypeID;
            set => Set(ref _materialTypeID, value, nameof(MaterialTypeID));
        }
    }
}
