using System;
using Models;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Data
{


    public class ProductOptionRepository : IRepository<ProductOption>
    {

        public bool Save(ProductOption product)
        {
            try
            {
                using (var conn = Database.Instance.Connection)
                {
                    using (var cmd = new SqlCommand($"insert into productoption (id, productid, name, description) values ('{product.Id}', '{product.ProductId}', '{product.Name}', '{product.Description}')", conn))
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

        public bool Update(ProductOption product)
        {
            try
            {
                using (var conn = Database.Instance.Connection)
                {
                    using (var cmd = new SqlCommand($"update productoption set name = '{product.Name}', description = '{product.Description}' where id = '{product.Id}'", conn))
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
                var cmd = new SqlCommand($"delete from productoption where id = '{id}'", conn);
                cmd.ExecuteReader();

                return true;
            }
            catch
            {
                // TODO : log an exception
                return false;
            }
        }

        public ProductOption GetItem(Guid id)
        {
            try
            {
                var conn = Database.Instance.Connection;
                var cmd = new SqlCommand($"select * from productoption where id = '{id}'", conn);
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

        public List<ProductOption> GetAllItems()
        {
            try
            {
                var items = new List<ProductOption>();
                var conn = Database.Instance.Connection;
                var cmd = new SqlCommand($"select * from productoptions", conn);
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

        public List<ProductOption> GetItemsByName(string name)
        {
            try
            {
                var items = new List<ProductOption>();
                var conn = Database.Instance.Connection;
                var cmd = new SqlCommand($"select * from productoptions where lower(name) like '%{name.ToLower()}%'", conn);
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

        private ProductOption ReadProduct(SqlDataReader rdr)
        {
            return new ProductOption()
            {
                Id = Guid.Parse(rdr["Id"].ToString()),
                ProductId = Guid.Parse(rdr["ProductId"].ToString()),
                Name = rdr["Name"].ToString(),
                Description = (DBNull.Value == rdr["Description"]) ? null : rdr["Description"].ToString()
            };
        }

    }
}
