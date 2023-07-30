using Dal.Vdr.Entities;
using Dal.Vdr.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Vdr.Repositories
{
    public class MediasRepository : IRepository<MediasEntity, int>
    {
        private readonly string _connectionString;
        public MediasRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("ApiVdr");
        }

        public MediasEntity Delete(int id)
        {
            throw new NotImplementedException();
        }

        private MediasEntity Mapper(IDataReader reader)
        {
            return new MediasEntity
            {
                Id = (int)reader["Id"],
                Title = (string)reader["Title"],
                Content = (string)reader["Content"]

            };
        }
        public IEnumerable<MediasEntity> GetAll()
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    string sql = "SELECT * FROM Medias";
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

        public MediasEntity GetOne(int id)
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Medias WHERE Id = @id";
                var param = new { Id = id };
                return cnx.Query<MediasEntity>(sql, param).FirstOrDefault();
            }
        }

        public MediasEntity Add(MediasEntity entity)//, IDbConnection cnn)
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO Medias (Id, Title, Content) VALUES(@Id, @Title, @Content)";
                cnx.Execute(sql, entity);
                return entity;
            }
        }

        public MediasEntity Put(MediasEntity entity)
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE Title, Content FROM Medias VALUES(@Title,@Content)";
                cnx.Execute(sql, entity);
                return entity;
            }
        }
    }
}
