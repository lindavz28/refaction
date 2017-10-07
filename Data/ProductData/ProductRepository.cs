using System;
using Models;
using System.Data.SqlClient;
using System.Collections.Generic;
using Dapper;

namespace Data.ProductData
{
    /*public class ProductRepository : IRepository<Product>
    {
        public bool Save(Product product)
        {
            try
            {
                using (var conn = Database.Instance.Connection)
                {
                    // TODO these need to be using Dapper
                    using (var cmd = new SqlCommand($"insert into product (id, name, description, price, deliveryprice) values ('"+
                            "{product.Id}', '{product.Name}', '{product.Description}', {product.Price},"+
                            "{product.DeliveryPrice})", conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                // TODO : log an exception
                return false;
            }

            return true;
        }

        public bool Update(Product product)
        {
            try
            {
                using (var conn = Database.Instance.Connection)
                {
                    using (var cmd = new SqlCommand($"update product set name = '{product.Name}', description = '{product.Description}', price = {product.Price}, deliveryprice = {product.DeliveryPrice} where id = '{product.Id}'", conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch
            {
                // TODO : log an exception
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                var conn = Database.Instance.Connection;
                conn.Open();
                var cmd = new SqlCommand($"delete from product where id = '{id}'", conn);
                cmd.ExecuteReader();

                return true;
            }
            catch
            {
                // TODO : log an exception
                return false;
            }
        }

        public Product GetItem(Guid id)
        {
            try
            {
                var conn = Database.Instance.Connection;
                var cmd = new SqlCommand($"select * from product where id = '{id}'", conn);
                conn.Open();

                using (var rdr = cmd.ExecuteReader())
                {
                    if (!rdr.Read())
                        return null;

                    return ReadProduct(rdr);
                }
            }
            catch
            {
                // TODO : log an exception
                return null;
            }
        }

        public List<Product> GetAllItems()
        {
            try
            {
                var items = new List<Product>();
                var conn = Database.Instance.Connection;
                var cmd = new SqlCommand($"select * from product", conn);
                conn.Open();

                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        items.Add(ReadProduct(rdr));
                    }

                    return items;
                }
            }
            catch
            {
                // TODO : log an exception
                return null;
            }
        }

        public List<Product> GetItemsByName(string name)
        {
            try
            {
                var items = new List<Product>();
                var conn = Database.Instance.Connection;
                var cmd = new SqlCommand($"select * from product where lower(name) like '%{name.ToLower()}%'", conn);
                conn.Open();

                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        items.Add(ReadProduct(rdr));
                    }

                    return items;
                }
            }
            catch
            {
                // TODO : log an exception
                return null;
            }
        }

        private Product ReadProduct(SqlDataReader rdr)
        {
            return new Product()
            {
                Id = Guid.Parse(rdr["Id"].ToString()),
                Name = rdr["Name"].ToString(),
                Description = (DBNull.Value == rdr["Description"]) ? null : rdr["Description"].ToString(),
                Price = decimal.Parse(rdr["Price"].ToString()),
                DeliveryPrice = decimal.Parse(rdr["DeliveryPrice"].ToString())
            };
        }

    }*/
}
