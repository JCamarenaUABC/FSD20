using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoctorProject;
using Newtonsoft.Json;
//using System.Web.Http;
//using System.Web.Http.Cors;
//using System.Web.Script.Serialization;
//using System.Web.Http.Results;
//using System.Web.Http;
//using System.Web.Http.Cors;


namespace DoctorProject.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [Microsoft.AspNetCore.Cors.EnableCors("AllowSpecific")]

    public class TB_DOCTORController : Controller
    {
        private DOCTOREntities db = new DOCTOREntities();

        // GET: TB_DOCTOR
        public async Task<ActionResult> Index()
        {
            return View(await db.TB_DOCTOR.ToListAsync());
        }

        // GET: TB_DOCTOR/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_DOCTOR tB_DOCTOR = await db.TB_DOCTOR.FindAsync(id);
            if (tB_DOCTOR == null)
            {
                return HttpNotFound();
            }
            return View(tB_DOCTOR);
        }

        // GET: TB_DOCTOR/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TB_DOCTOR/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_DOCTOR,DOCTORNAME,BORNDATE,LOCATIONDOCTOR,DESCRIPTION")] TB_DOCTOR tB_DOCTOR)
        {
            if (ModelState.IsValid)
            {
                db.TB_DOCTOR.Add(tB_DOCTOR);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tB_DOCTOR);
        }

        // GET: TB_DOCTOR/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_DOCTOR tB_DOCTOR = await db.TB_DOCTOR.FindAsync(id);
            if (tB_DOCTOR == null)
            {
                return HttpNotFound();
            }
            return View(tB_DOCTOR);
        }

        // POST: TB_DOCTOR/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_DOCTOR,DOCTORNAME,BORNDATE,LOCATIONDOCTOR,DESCRIPTION")] TB_DOCTOR tB_DOCTOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_DOCTOR).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tB_DOCTOR);
        }

        // GET: TB_DOCTOR/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_DOCTOR tB_DOCTOR = await db.TB_DOCTOR.FindAsync(id);
            if (tB_DOCTOR == null)
            {
                return HttpNotFound();
            }
            return View(tB_DOCTOR);
        }

        // POST: TB_DOCTOR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TB_DOCTOR tB_DOCTOR = await db.TB_DOCTOR.FindAsync(id);
            db.TB_DOCTOR.Remove(tB_DOCTOR);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        [HttpPost]
        public ActionResult SearchDoctor(RecibirDatos Datos)
        //public System.Web.Http.IHttpActionResult SearchDoctor(string Name, string Speciality)
        //public System.Web.Http.IHttpActionResult SearchDoctor(RecibirDatos Datos)
        {
            if (Datos.Name == null)
            {
                Datos.Name = "";
            }

            if (Datos.Speciality==null)
            {
                Datos.Speciality = "";
            }

            List<SP_GET_SEARCH_DOCTOR_Result> SearchResult = db.SP_GET_SEARCH_DOCTOR(Datos.Name, Datos.Speciality).ToList();
            //List<SP_GET_SEARCH_DOCTOR_Result> SearchResult = db.SP_GET_SEARCH_DOCTOR(Name, Speciality).ToList();
            //var json = JsonConvert.SerializeObject(SearchResult);

            //var jsonResult = JavaScriptSerializer().Serialize(SearchResult);
            return Json(new { SearchResult });
            //return Ok(json);            
            //return json;            
        }

        public class RecibirDatos
        {
            public string Name { get; set; }
            public string Speciality { get; set; }
        }

        /*private System.Web.Http.IHttpActionResult Ok(string json)
        {
            //return Json;
            throw new NotImplementedException();
        }*/

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
