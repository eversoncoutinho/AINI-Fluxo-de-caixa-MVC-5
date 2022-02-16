using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AINI_Fluxo_de_caixa.Models;
using Microsoft.AspNetCore.Mvc;

namespace AINI_Fluxo_de_caixa.Controllers
{
    public class OperationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IActionResult BadRequest { get; private set; }

        // GET: Operations
        public async Task<ActionResult> Index()
        {
            return View(await db.Operations.ToListAsync());
        }

        // GET: Operations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operation operation = await db.Operations.FindAsync(id);
            if (operation == null)
            {
                return HttpNotFound();
            }
            return View(operation);
        }

        // GET: Operations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Operations/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Data,Nome,Tipo,Valor")] Operation operation)
        {
            if (ModelState.IsValid)
            {
                db.Operations.Add(operation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(operation);
        }

        // GET: Operations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operation operation = await db.Operations.FindAsync(id);
            if (operation == null)
            {
                return HttpNotFound();
            }
            return View(operation);
        }

        // POST: Operations/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Data,Nome,Tipo,Valor")] Operation operation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(operation);
        }

        // GET: Operations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operation operation = await db.Operations.FindAsync(id);
            if (operation == null)
            {
                return HttpNotFound();
            }
            return View(operation);
        }

        // POST: Operations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Operation operation = await db.Operations.FindAsync(id);
            db.Operations.Remove(operation);
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
        //listar somente as entradas
        
        public async Task<ActionResult> Entradas() //filtro
        {
            var filtro = await db.Operations.Where(p => p.Tipo == "E").ToListAsync();
            return View(filtro);
            
            
        }
        public async Task<ActionResult> Saidas() //filtro
        {
            var filtro = await db.Operations.Where(p => p.Tipo == "S").ToListAsync();
            return View(filtro);


        }
    }
}
