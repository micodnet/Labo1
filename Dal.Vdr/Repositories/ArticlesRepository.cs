using Dal.Vdr.Entities;
using Dal.Vdr.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using static Dapper.SqlMapper;

namespace Dal.Vdr.Repositories
{
    public class ArticlesRepository : IRepository<ArticlesEntity, int>
    {
        private readonly string _connectionString;
        public ArticlesRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("ApiVdr");
        }

        public ArticlesEntity Delete(int id)
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    string selectSql = "SELECT * FROM Articles WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.CommandText = selectSql;
                    cnx.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return null;
                        }

                        ArticlesEntity entity = new ArticlesEntity
                        {
                            Id = (int)reader["Id"],
                            Title = (string)reader["Title"],
                            Content = (string)reader["Content"],
                        };
                        string deleteSql = "DELETE FROM Articles WHERE Id = @Id";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.CommandText = deleteSql;
                        cnx.Execute(deleteSql, entity);
                        return entity;
                    }
                }
            }
        }

        private ArticlesEntity Mapper(IDataReader reader)
        {
            return new ArticlesEntity
            {
                Id = (int)reader["Id"],
                Title = (string)reader["Title"],
                Content = (string)reader["Content"]

            };
        }
        public IEnumerable<ArticlesEntity> GetAll()
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    string sql = "SELECT * FROM Articles";
                    cmd.CommandText = sql;
                    cnx.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return Mapper(reader);
                        }
                    }
                }
            }
        }

        public ArticlesEntity GetOne(int id)
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Articles WHERE Id = @id";
                var param = new { Id = id };
                return cnx.Query<ArticlesEntity>(sql, param).FirstOrDefault();
            }
        }

        public ArticlesEntity Add(ArticlesEntity entity)//, IDbConnection cnn)
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO Articles (Id, Title, Content) VALUES(@Id, @Title, @Content)";
                cnx.Execute(sql, entity);
                return entity;
            }
        }

        public ArticlesEntity Put(ArticlesEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
