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

namespace DoctorProject.Controllers
{
    public class TB_SPECIALITYController : Controller
    {
        private DOCTOREntities db = new DOCTOREntities();

        // GET: TB_SPECIALITY
        public async Task<ActionResult> Index()
        {
            return View(await db.TB_SPECIALITY.ToListAsync());
        }

        // GET: TB_SPECIALITY/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_SPECIALITY tB_SPECIALITY = await db.TB_SPECIALITY.FindAsync(id);
            if (tB_SPECIALITY == null)
            {
                return HttpNotFound();
            }
            return View(tB_SPECIALITY);
        }

        // GET: TB_SPECIALITY/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TB_SPECIALITY/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_SPECIALITY,DESCR_SPECIALITY")] TB_SPECIALITY tB_SPECIALITY)
        {
            if (ModelState.IsValid)
            {
                db.TB_SPECIALITY.Add(tB_SPECIALITY);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tB_SPECIALITY);
        }

        // GET: TB_SPECIALITY/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_SPECIALITY tB_SPECIALITY = await db.TB_SPECIALITY.FindAsync(id);
            if (tB_SPECIALITY == null)
            {
                return HttpNotFound();
            }
            return View(tB_SPECIALITY);
        }

        // POST: TB_SPECIALITY/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_SPECIALITY,DESCR_SPECIALITY")] TB_SPECIALITY tB_SPECIALITY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_SPECIALITY).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tB_SPECIALITY);
        }

        // GET: TB_SPECIALITY/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_SPECIALITY tB_SPECIALITY = await db.TB_SPECIALITY.FindAsync(id);
            if (tB_SPECIALITY == null)
            {
                return HttpNotFound();
            }
            return View(tB_SPECIALITY);
        }

        // POST: TB_SPECIALITY/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TB_SPECIALITY tB_SPECIALITY = await db.TB_SPECIALITY.FindAsync(id);
            db.TB_SPECIALITY.Remove(tB_SPECIALITY);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

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
