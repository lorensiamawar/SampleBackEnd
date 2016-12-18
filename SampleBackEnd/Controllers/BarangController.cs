using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;
using BO;

namespace SampleBackEnd.Controllers
{
    public class BarangController : ApiController
    {
        // GET: api/Barang
        public IEnumerable<Barang> Get()
        {
            BarangDAL barangDAL = new BarangDAL();
            return barangDAL.GetAll();
        }

        // GET: api/Barang/5
        public Barang Get(string id)
        {
            BarangDAL barangDAL = new BarangDAL();
            return barangDAL.GetById(id);
        }

        // POST: api/Kategori
        public IHttpActionResult Post(Barang barang)
        {
            BarangDAL barangDAL = new BarangDAL();
            try
            {
                barangDAL.Create(barang);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Kategori/5
        public IHttpActionResult Put(Barang barang)
        {
            BarangDAL barangDAL = new BarangDAL();
            try
            {
                barangDAL.Update(barang);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Kategori/5
        public IHttpActionResult Delete(string id)
        {
            BarangDAL barangDAL = new BarangDAL();
            try
            {
                barangDAL.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IEnumerable<BarangVM>GetKat(string NamaKategori)
        {
            BarangDAL barangDAL = new BarangDAL();
            return barangDAL.SearchByKategori(NamaKategori);
        }

        public IEnumerable<Barang> GetBar(string namaBarang)
        {
            BarangDAL barangDAL = new BarangDAL();
            return barangDAL.SearchByBarang(namaBarang);
        }
    }
}
