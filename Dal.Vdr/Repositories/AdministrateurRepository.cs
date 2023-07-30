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
namespace Dal.Vdr.Repositories
{
    public class AdministrateurRepository : IRepository<AdministrateurEntity, int>
    {
        //repo comunique avec la base de donnees,transformant les donnees en c# et inversement
        private readonly string _connectionString;
        public AdministrateurRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("ApiVdr");
        }

        public AdministrateurEntity Delete(int id)
        {
            throw new NotImplementedException();
        }

        private AdministrateurEntity Mapper(IDataReader reader)
        {
            return new AdministrateurEntity
            {
                Id = (int)reader["Id"],
                Login = (string)reader["Login"],
                Password = (string)reader["Password"]
                
            };
        }
        public IEnumerable<AdministrateurEntity> GetAll()
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    string sql = "SELECT * FROM Administrateur";
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

        public AdministrateurEntity GetOne(int id)
        {
            using(SqlConnection cnx = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Administrateur WHERE Id = @id";
                var param = new { Id = id };
                return cnx.Query<AdministrateurEntity>(sql, param).FirstOrDefault();
            }
        }

        public AdministrateurEntity Add(AdministrateurEntity entity)//, IDbConnection cnn)
        {
            using(SqlConnection cnx = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO Administrateur (Id, Password, Login) VALUES(@Id, @Password, @Login)";
                cnx.Execute(sql, entity);
                return entity;
            }
        }

        public AdministrateurEntity Put(AdministrateurEntity entity)
        {
            using(SqlConnection cnx = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE Login, Password FROM administrateur VALUES(@Login,@Password)";
                cnx.Execute(sql, entity);
                return entity;
            }
        }
    }
}
