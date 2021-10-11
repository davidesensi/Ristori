using Ristori.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Ristori.Services
{
    public class CartProductService
    {
        public int GetOperatorCartCount()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            var count = cn.Table<CartItem>().Count();
            cn.Close();
            return count;
        }

        public void RemoveProductsFromCart()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            cn.DeleteAll<CartItem>();
            cn.Commit();
            cn.Close();
        }
    }
}
