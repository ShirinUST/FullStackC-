using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_1_CSharp_Assessment
{
    internal class ProductManagement
    {
        List<Product_ICare> productList=new List<Product_ICare>();
        public bool IsProductExists(Product_ICare product)
        {
          var productExist=productList.Find(
              products=>
              (products.ProductName.ToLower()==product.ProductName.ToLower())&&(products.ManufacturedYear==product.ManufacturedYear)
              );
          if (productExist!=null)
            {
                return false;
            }
          return true;
        }
        public void AddProduct(Product_ICare product)
        {
            product.ProductID = productList.Count() == 0 ? 5000 : productList.Max(products => products.ProductID) + 1;
            productList.Add(new Product_ICare 
            { ProductID = product.ProductID ,
              ProductName=product.ProductName,
              ProductDescription=product.ProductDescription,
              ManufacturedYear=product.ManufacturedYear,
              ProductPrice=product.ProductPrice
            });
        }
        public List<Product_ICare> GetProductList()
        {  
            return productList;
        }
        public List<Product_ICare> GetProductListAboveInputPrice(double price)
        {
            var newList=productList.FindAll(products=>products.ProductPrice>price);
            return newList;
        }
        public bool RemoveProductById(int id)
        {
            var removingProduct=productList.Find(products=>products.ProductID==id);
            if (removingProduct!=null)
            {
                productList.Remove(removingProduct);
                return true;
            }
            return false;
        }
    }
}
