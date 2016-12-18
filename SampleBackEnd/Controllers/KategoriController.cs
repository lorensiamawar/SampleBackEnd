using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BO;
using DAL;

namespace SampleBackEnd.Controllers
{
    public class KategoriController : ApiController
    {
        // GET: api/Kategori
        public IEnumerable<Kategori> Get()
        {
            KategoriDAL kategoriDAL = new KategoriDAL();
            return kategoriDAL.GetAll();
        }

        // GET: api/Kategori/5
        public Kategori Get(int id)
        {
            KategoriDAL kategoriDAL = new KategoriDAL();
            return kategoriDAL.GetById(id);
        }

        // POST: api/Kategori
        public IHttpActionResult Post(Kategori kategori)
        {
            KategoriDAL kategoriDAL = new KategoriDAL();
            try
            {
                kategoriDAL.Create(kategori);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Kategori/5
        public IHttpActionResult Put(Kategori kategori)
        {
            KategoriDAL kategoriDAL = new KategoriDAL();
            try
            {
                kategoriDAL.Update(kategori);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Kategori/5
        public IHttpActionResult Delete(int id)
        {
            KategoriDAL kategoriDAL = new KategoriDAL();
            try
            {
                kategoriDAL.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IEnumerable<Kategori> Get(string namaKategori)
        {
            KategoriDAL kategoriDAL = new KategoriDAL();
            return kategoriDAL.SearchByName(namaKategori);
        }
    }
}
