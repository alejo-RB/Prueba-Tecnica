using Microsoft.AspNetCore.Mvc;

using CRUDCORE.Datos;
using CRUDCORE.Models;

namespace CRUDCORE.Controllers
{
    public class MantenedorController : Controller
    {
        VehiculoDatos _VehiculoDatos = new VehiculoDatos();
        public IActionResult Listar()
        {
            //LA VISTA MOSTRARÁ UNA LISTA DE VEHICULOS
            var oLista = _VehiculoDatos.Listar();

            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //METODO SOLO DEVUELVE LA VISTA HTML
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(VehiculoModel oVehiculo)
        {
            //METODO RECIBE UN OBJETO Y LO GUARDA EN LA BASE DE DATOS
            if(!ModelState.IsValid) {
                return View();
            }

            var respuesta = _VehiculoDatos.Guardar(oVehiculo);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        public IActionResult Editar(int id)
        {
            //METODO SOLO DEVUELVE LA VISTA HTML
            var ovehiculo = _VehiculoDatos.Obtener(id);
            return View(ovehiculo);
        }

        [HttpPost]
        public IActionResult Editar(VehiculoModel oVehiculo)
        {   
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _VehiculoDatos.Editar(oVehiculo);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
        public IActionResult Eliminar(int id)
        {
            //METODO SOLO DEVUELVE LA VISTA HTML
            var ovehiculo = _VehiculoDatos.Obtener(id);
            return View(ovehiculo);
        }

        [HttpPost]
        public IActionResult Eliminar(VehiculoModel oVehiculo)
        {
            var respuesta = _VehiculoDatos.Eliminar(oVehiculo.id);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
