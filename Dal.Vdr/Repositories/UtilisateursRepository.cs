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
    public class UtilisateursRepository : IRepository<UtilisateursEntity, int>
    {
        //repo comunique avec la base de donnees,transformant les donnees en c# et inversement
        private readonly string _connectionString;
        public UtilisateursRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("ApiVdr");
        }

        public UtilisateursEntity Delete(int id)
        {
            throw new NotImplementedException();
        }

        private UtilisateursEntity Mapper(IDataReader reader)
        {
            return new UtilisateursEntity
            {
                Id = (int)reader["Id"],
                LastName = (string)reader["LastName"],
                FirstName = (string)reader["FirstName"],
                Email = (string)reader["Email"]

            };
        }
        public IEnumerable<UtilisateursEntity> GetAll()
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    string sql = "SELECT * FROM Utilisateurs";
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

        public UtilisateursEntity GetOne(int id)
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Utilisateurs WHERE Id = @id";
                var param = new { Id = id };
                return cnx.Query<UtilisateursEntity>(sql, param).FirstOrDefault();
            }
        }

        public UtilisateursEntity Add(UtilisateursEntity entity)//, IDbConnection cnn)
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO Utilisateurs (Email, LastName, FirstName) VALUES(@Email, @LastName, @FirstName)"; 
                cnx.Execute(sql, entity);
                return entity;
            }
        }

        public UtilisateursEntity Put(UtilisateursEntity entity)
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE LastName, FirstName, Email FROM Utilisateurs VALUES(@LastName, @FirstName, @Email)";
                cnx.Execute(sql, entity);
                return entity;
            }
        }
    }
}
