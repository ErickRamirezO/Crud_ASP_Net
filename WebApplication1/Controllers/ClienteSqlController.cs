using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
{
    public class ClienteSqlController : Controller
    {
        private readonly IClienteDataAccessLayer _dataAccessLayer;

        public ClienteSqlController(IClienteDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        // GET: ClienteSqlController
        public IActionResult Index()
        {
            List<ClienteSql> listaSql = _dataAccessLayer.GetAllClientes().ToList();
            return View(listaSql);
        }

        // GET: ClienteSqlController/Details/5
        public IActionResult Details(int id)
        {
            ClienteSql cliente = _dataAccessLayer.GetAllClientes().FirstOrDefault(c => c.Codigo == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // GET: ClienteSqlController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClienteSqlController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteSql cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _dataAccessLayer.AddCliente(cliente);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    // Log the error
                    ModelState.AddModelError("", "No se pudo guardar el cliente. Inténtelo de nuevo.");
                }
            }
            return View(cliente);
        }

        // GET: ClienteSqlController/Edit/5
        public IActionResult Edit(int id)
        {
            ClienteSql cliente = _dataAccessLayer.GetAllClientes().FirstOrDefault(c => c.Codigo == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: ClienteSqlController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ClienteSql cliente)
        {
            if (id != cliente.Codigo)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _dataAccessLayer.UpdateCliente(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: ClienteSqlController/Delete/5
        public ActionResult Delete(int id)
        {
            var cliente = _dataAccessLayer.GetClienteById(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: ClienteSqlController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Codigo)
        {
            try
            {
                _dataAccessLayer.DeleteCliente(Codigo);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Manejo de errores
                ModelState.AddModelError("", "No se pudo eliminar el cliente. " + ex.Message);
                return View();
            }
        }

    }
}