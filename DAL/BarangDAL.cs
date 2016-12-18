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
   public class BarangDAL
    {
        private string GetConnStr()
        {
            return ConfigurationManager.ConnectionStrings["StokDbConnectionString"].ConnectionString;
        }

        public IEnumerable<Barang> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Barang order by Nama asc";
                var results = conn.Query<Barang>(strSql);
                return results;
            }
        }

        public Barang GetById(string KodeBarang)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Barang 
                                  where KodeBarang=@KodeBarang";

                var par = new
                {
                    KodeBarang = KodeBarang
                };
                return conn.Query<Barang>(strSql, par).SingleOrDefault();
            }
        }

        public void Create(Barang barang)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"insert into Barang(KodeBarang,IdJenisMotor,KategoriId,Nama,Stok,HargaBeli,HargaJual,TanggalBeli) 
                                  values(@KodeBarang,@IdJenisMotor,@KategoriId,@Nama,@Stok,@HargaBeli,@HargaJual,@TanggalBeli)";

                var par = new
                {
                    KodeBarang = barang.KodeBarang,
                    IdJenisMotor = barang.IdJenisMotor,
                    KategoriId = barang.KategoriId,
                    Nama = barang.Nama,
                    Stok = barang.Stok,
                    HargaBeli = barang.HargaBeli,
                    HargaJual = barang.HargaJual,
                    TanggalBeli = barang.TanggalBeli
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

        public void Update(Barang barang)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {

                string strSql = @"update Barang set KodeBarang=@KodeBarang,IdJenisMotor=@IdJenisMotor,KategoriId=@KategoriId,Nama=@Nama,Stok=@Stok,HargaBeli=@HargaBeli,HargaJual=@HargaJual,TanggalBeli=@TanggalBeli 
                                  where KodeBarang=@KodeBarang";
                var par = new
                {
                    KodeBarang = barang.KodeBarang,
                    IdJenisMotor = barang.IdJenisMotor,
                    KategoriId = barang.KategoriId,
                    Nama = barang.Nama,
                    Stok = barang.Stok,
                    HargaBeli = barang.HargaBeli,
                    HargaJual = barang.HargaJual,
                    TanggalBeli = barang.TanggalBeli
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

        public void Delete(string KodeBarang)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {

                string strSql = @"delete from Barang 
                                  where KodeBarang=@KodeBarang";
                var par = new
                {
                    KodeBarang = KodeBarang
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
        public IEnumerable<BarangVM> SearchByKategori(string NamaKategori)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select barang.KodeBarang, barang.IdJenisMotor, barang.KategoriId, barang.Nama, barang.Stok, barang.HargaBeli, barang.HargaJual, barang.TanggalBeli from Barang, Kategori where barang.KategoriId = kategori.KategoriId and NamaKategori like @NamaKategori order by NamaKategori asc";
                var par = new { Nama = "%" + NamaKategori + "%" };
                var result = conn.Query<BarangVM>(strSql, par);
                return result;

            }
        }

        public IEnumerable<Barang> SearchByBarang(string namaBarang)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Barang where Nama like @Nama order by Nama asc";
                var par = new { Nama = "%" + namaBarang + "%" };
                var result = conn.Query<Barang>(strSql, par);
                return result;

            }
        }

       
    }
}
