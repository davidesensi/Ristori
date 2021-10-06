using Ristori.Models;
using Ristori.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Ristori.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        private Category _SelectedCategory;
        public Category SelectedCategory
        {
            set
            {
                _SelectedCategory = value;
                OnPropertyChanged();
            }
            get
            {
                return _SelectedCategory;
            }
           

        }

        public ObservableCollection<Product> ProductsByCategory { get; set; }

        private int _TotalProducts;
        public int TotalProducts
        {
            set
            {
                _TotalProducts = value;
                OnPropertyChanged();
            }
            get
            {
                return _TotalProducts;
            }
        }

        public CategoryViewModel(Category category)
        {
            SelectedCategory = category;
            ProductsByCategory = new ObservableCollection<Product>();
            GetProductsAsync(category.CategoryID);

        }

        private async Task GetProductsAsync(int categoryID)
        {
            var data = await new ProductService().GetProductsByCategoryAsync(categoryID);
            ProductsByCategory.Clear();
            foreach(var product in data)
            {
                ProductsByCategory.Add(product);
            }
            TotalProducts = ProductsByCategory.Count;
        }
    }
}
