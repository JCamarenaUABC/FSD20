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
    public class TB_PARAMETERSController : Controller
    {
        private DOCTOREntities db = new DOCTOREntities();

        // GET: TB_PARAMETERS
        public async Task<ActionResult> Index()
        {
            return View(await db.TB_PARAMETERS.ToListAsync());
        }

        // GET: TB_PARAMETERS/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_PARAMETERS tB_PARAMETERS = await db.TB_PARAMETERS.FindAsync(id);
            if (tB_PARAMETERS == null)
            {
                return HttpNotFound();
            }
            return View(tB_PARAMETERS);
        }

        // GET: TB_PARAMETERS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TB_PARAMETERS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_PARAM,DESCR_PARAM,VAL1,VAL2,VAL3")] TB_PARAMETERS tB_PARAMETERS)
        {
            if (ModelState.IsValid)
            {
                db.TB_PARAMETERS.Add(tB_PARAMETERS);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tB_PARAMETERS);
        }

        // GET: TB_PARAMETERS/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_PARAMETERS tB_PARAMETERS = await db.TB_PARAMETERS.FindAsync(id);
            if (tB_PARAMETERS == null)
            {
                return HttpNotFound();
            }
            return View(tB_PARAMETERS);
        }

        // POST: TB_PARAMETERS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_PARAM,DESCR_PARAM,VAL1,VAL2,VAL3")] TB_PARAMETERS tB_PARAMETERS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_PARAMETERS).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tB_PARAMETERS);
        }

        // GET: TB_PARAMETERS/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_PARAMETERS tB_PARAMETERS = await db.TB_PARAMETERS.FindAsync(id);
            if (tB_PARAMETERS == null)
            {
                return HttpNotFound();
            }
            return View(tB_PARAMETERS);
        }

        // POST: TB_PARAMETERS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TB_PARAMETERS tB_PARAMETERS = await db.TB_PARAMETERS.FindAsync(id);
            db.TB_PARAMETERS.Remove(tB_PARAMETERS);
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
