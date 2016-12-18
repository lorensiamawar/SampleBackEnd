using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class JenisMotorDAL
    {
        private string GetConnStr()
        {
            return ConfigurationManager.ConnectionStrings["StokDbConnectionString"].ConnectionString;
        }

        public IEnumerable<JenisMotor> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from JenisMotor order by NamaJenisMotor asc";
                var results = conn.Query<JenisMotor>(strSql);
                return results;
            }
        }
        public JenisMotor GetById(int IdJenisMotor)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from JenisMotor 
                                  where IdJenisMotor=@IdJenisMotor";

                var par = new
                {
                    IdJenisMotor = IdJenisMotor
                };
                return conn.Query<JenisMotor>(strSql, par).SingleOrDefault();
            }
        }

        public void Create(JenisMotor jenis)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"insert into JenisMotor(NamaMerk,NamaJenisMotor) 
                                  values(@NamaMerk,@NamaJenisMotor)";

                var par = new
                {
                    NamaMerk = jenis.NamaMerk,
                    NamaJenisMotor = jenis.NamaJenisMotor
                };
                try
                {
                    conn.Execute(strSql, par);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Number + "-" + sqlEx.Message);
                }
            }
        }

        public void Update(JenisMotor jenis)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {

                string strSql = @"update JenisMotor set NamaMerk=@NamaMerk,NamaJenisMotor=@NamaJenisMotor 
                                  where IdJenisMotor=@IdJenisMotor";
                var par = new
                {
                    NamaMerk = jenis.NamaMerk,
                    NamaJenisMotor = jenis.NamaJenisMotor,
                    IdJenisMotor = jenis.IdJenisMotor
                };

                try
                {
                    conn.Execute(strSql, par);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Number + " - " + sqlEx.Message);
                }
            }
        }

        public void Delete(int IdJenisMotor)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {

                string strSql = @"delete from JenisMotor 
                                  where IdJenisMotor=@IdJenisMotor";
                var par = new
                {
                  IdJenisMotor = IdJenisMotor
                };

                try
                {
                    conn.Execute(strSql, par);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Number + " - " + sqlEx.Message);
                }
            }
        }

        public IEnumerable<JenisMotor> SearchByName(string NamaJenisMotor)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = "@select * from JenisMotor where NamaJenisMotor like @NamaJenisMotor order by NamaJenisMotor asc";
                var par = new { NamaJenisMotor = "%" + NamaJenisMotor + "%" };
                var result = conn.Query<JenisMotor>(strSql, par);
                return result;
            }
        }
    }
}
