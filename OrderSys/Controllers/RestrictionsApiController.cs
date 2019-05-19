using OrderSys.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace OrderSys.Controllers
{
    public class RestrictionsApiController : ApiController
    {
        private AllContext db = new AllContext();

        // GET: api/Restrictions1
        public IQueryable<Restriction> GetOc()
        {
            return db.Oc;
        }


        // GET: api/Restrictions1/5
        [ResponseType(typeof(Restriction))]
        public IHttpActionResult GetRestriction(string oc)
        {
            Restriction restriction = db.Oc.Find(1);
            if (restriction == null)
            {
                return NotFound();
            }
            if (oc.Equals("open"))
            {
                restriction.Oc = "open";
            }
            else
            {
                restriction.Oc = "close";
            }

            db.Entry(restriction).State = EntityState.Modified;

            db.SaveChanges();

            return Ok(restriction);
        }

        // PUT: api/Restrictions1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRestriction(int id, Restriction restriction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restriction.Id)
            {
                return BadRequest();
            }

            db.Entry(restriction).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestrictionExists(id))
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

        // POST: api/Restrictions1
        [ResponseType(typeof(Restriction))]
        public IHttpActionResult PostRestriction(Restriction restriction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Oc.Add(restriction);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = restriction.Id }, restriction);
        }

        // DELETE: api/Restrictions1/5
        [ResponseType(typeof(Restriction))]
        public IHttpActionResult DeleteRestriction(int id)
        {
            Restriction restriction = db.Oc.Find(id);
            if (restriction == null)
            {
                return NotFound();
            }

            db.Oc.Remove(restriction);
            db.SaveChanges();

            return Ok(restriction);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestrictionExists(int id)
        {
            return db.Oc.Count(e => e.Id == id) > 0;
        }
    }
}