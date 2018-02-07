using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class NguoiDungController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/NguoiDung
        public IQueryable<NguoiDung> GetNguoiDungs()
        {
            return db.NguoiDungs;
        }

        // GET: api/NguoiDung/5
        [ResponseType(typeof(NguoiDung))]
        public IHttpActionResult GetNguoiDung(int id)
        {
            NguoiDung nguoiDung = db.NguoiDungs.Find(id);
            if (nguoiDung == null)
            {
                return NotFound();
            }

            return Ok(nguoiDung);
        }

        // PUT: api/NguoiDung/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNguoiDung(int id, NguoiDung nguoiDung)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nguoiDung.IdNguoiDung)
            {
                return BadRequest();
            }

            db.Entry(nguoiDung).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NguoiDungExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/NguoiDung
        [ResponseType(typeof(NguoiDung))]
        public IHttpActionResult PostNguoiDung(NguoiDung nguoiDung)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NguoiDungs.Add(nguoiDung);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nguoiDung.IdNguoiDung }, nguoiDung);
        }

        // DELETE: api/NguoiDung/5
        [ResponseType(typeof(NguoiDung))]
        public IHttpActionResult DeleteNguoiDung(int id)
        {
            NguoiDung nguoiDung = db.NguoiDungs.Find(id);
            if (nguoiDung == null)
            {
                return NotFound();
            }

            db.NguoiDungs.Remove(nguoiDung);
            db.SaveChanges();

            return Ok(nguoiDung);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NguoiDungExists(int id)
        {
            return db.NguoiDungs.Count(e => e.IdNguoiDung == id) > 0;
        }
    }
}