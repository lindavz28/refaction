using System;
using Models;
using System.Collections.Generic;
using Data.Extensions;
using System.Linq;
using Data.Exceptions;
using Dapper;

namespace Data.ProductOptionData
{
    public class ProductOptionRepository : IProductOptionRepository
    {
        public bool Save(Guid productId, ProductOption product)
        {
            try
            {
                var conn = Database.Instance.Connection;

                var rowsUpdated = conn.ExecuteNonQuery("insert into productoption (id, productid, name, description) values (@Id, @ProductId, @Name, @Description)",
                    new
                    {
                        Id = product.Id.ToString(),
                        ProductId = productId.ToString(),
                        product.Name,
                        product.Description
                    });
                return rowsUpdated > 0;
            }
            catch(Exception ex)
            {
                // Log exception
                throw new ProductDatabaseException($"Exception trying to save Product Option with Product ID '{productId}', Option ID '{product.Id}' and Name '{product.Name}'", ex);
            }
        }

        public bool Update(Guid productId, ProductOption product)
        {
            try
            {
                var conn = Database.Instance.Connection;
                var rowsUpdated = conn.ExecuteNonQuery("update productoption set name = @Name, description = @Description where id = @Id and productId = @ProductId",
                    new
                    {
                        product.Name,
                        product.Description,
                        Id = product.Id.ToString(),
                        ProductId = productId.ToString()
                    });
                return rowsUpdated > 0;
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ProductDatabaseException($"Exception trying to update Product Option with Product ID '{productId}', Option ID '{product.Id}' and Name '{product.Name}'", ex);
            }
        }

        public bool Delete(Guid productId, Guid id)
        {
            try
            {
                var conn = Database.Instance.Connection;
                var rowsUpdated = conn.ExecuteNonQuery("delete from productoption where id = @Id and productid = @ProductId",
                    new
                    {
                        Id = id.ToString(),
                        ProductId = productId.ToString()
                    });
                return rowsUpdated > 0;
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ProductDatabaseException($"Exception trying to delete Product Option with Product Option ID '{productId}', and Option ID '{id}'", ex);
            }
        }
            
        public IEnumerable<ProductOption> GetAllItemsForProduct(Guid productId)
        {
            try
            {
                var conn = Database.Instance.Connection;
                return conn.ExecuteQuery<ProductOption>("select * from productoption where productid = @ProductId",
                    new { ProductId = productId.ToString() });
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ProductDatabaseException($"Exception trying to get Product Options with Product ID '{productId}'", ex);
            }
        }

        public ProductOption GetItemForProduct(Guid productId, Guid optionId)
        {
            try
            {
                var conn = Database.Instance.Connection;

                var items = conn.ExecuteQuery<ProductOption>("select * from productoption where productid = @ProductId and Id = @id",
                    new
                    {
                        ProductId = productId.ToString(),
                        Id = optionId.ToString()
                    });

                return items.FirstOrDefault();
                
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ProductDatabaseException($"Exception trying to get Product Option with Product ID '{productId}' and Product Option ID '{optionId}'", ex);
            }
        }
       
    }
}
