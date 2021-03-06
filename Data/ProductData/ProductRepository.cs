﻿using System;
using Models;
using System.Collections.Generic;
using Data.Extensions;
using Data.Exceptions;
using System.Linq;

namespace Data.ProductData
{
    public class ProductRepository : IProductRepository
    {

        public bool Save(Product product)
        {
            try
            {
                var conn = Database.Instance.Connection;
                var rowsUpdated = conn.ExecuteNonQuery("insert into product (id, name, description, price, deliveryprice) values (@Id, @Name, @Description, @Price, @DeliveryPrice)",
                    new
                    {
                        Id = product.Id.ToString(),
                        product.Name,
                        product.Description,
                        product.Price,
                        product.DeliveryPrice
                    });
                return rowsUpdated > 0;
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ProductDatabaseException($"Exception trying to save Product Name '{product.Name}'", ex);
            }
        }

        public bool Update(Product product)
        {
            try
            {
                var conn = Database.Instance.Connection;
                var rowsUpdated = conn.ExecuteNonQuery("update product set name = @Name, description = @Description, price = @Price, deliveryprice = @DeliveryPrice where id = @Id",
                    new
                    {
                        Id = product.Id.ToString(),
                        product.Name,
                        product.Description,
                        product.Price,
                        product.DeliveryPrice
                    });
                return rowsUpdated > 0;
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ProductDatabaseException($"Exception trying to update Product with Product ID '{product.Id}' and Name '{product.Name}'", ex);
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                var conn = Database.Instance.Connection;
                var rowsUpdated = conn.ExecuteNonQuery("delete from product where id = @Id",
                    new { Id = id.ToString() });
                return rowsUpdated > 0;
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ProductDatabaseException($"Exception trying to delete Product with Product Option ID '{id}'", ex);
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                var conn = Database.Instance.Connection;
                return conn.ExecuteQuery<Product>("select * from product");
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ProductDatabaseException($"Exception trying to get all Products", ex);
            }
        }

        public Product GetProduct(Guid id)
        {
            try
            {
                var conn = Database.Instance.Connection;

                var items = conn.ExecuteQuery<Product>("select * from product where id = @Id",
                    new { Id = id.ToString() });

                return items.FirstOrDefault();

            }
            catch (Exception ex)
            {
                // Log exception
                throw new ProductDatabaseException($"Exception trying to get Product with Product ID '{id}'", ex);
            }
        }
      
        public IEnumerable<Product> GetProductsByName(string name)
        {

            try
            {
                var conn = Database.Instance.Connection;
                var encodeLike = "%" + name.ToLower() + "%";

                return conn.ExecuteQuery<Product>("select * from product where lower(name) like @Name",
                    new { Name = name });
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ProductDatabaseException($"Exception trying to get all Products by name '{name}'", ex);
            }
        }
    }
}
