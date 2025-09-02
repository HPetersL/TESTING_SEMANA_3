using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFichaMedica.Data;
using ProyectoFichaMedica.Models;

namespace ProyectoFichaMedica.Controllers
{
    public class FichaController : Controller
    {
        // INYECCION DE DEPENDENCIAS:
        // declaramos una variable privada para nuestro contexto de base de datos.
        // el constructor recibe el contextoy lo asigna a nuestra variable.
        // ahora se usa "_context" en todo el controlador para hablar con la BD.
        private readonly ApplicationDbContext _context;

        public FichaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ACCION INDEX (GET): Muestra el formulario y los resultados de bsuqueda
        // esta accion se ejecuta cuando el usuario navega a /Ficha o /Ficha/Index
        // tambien maneja la búsqueda por apellido.
        public async Task<IActionResult> Index(string apellidoBusqueda)
        {
            // pasar busqueda a la vista
            ViewData["ApellidoBusquedaActual"] = apellidoBusqueda;

            // creamos una consulta base para obtener todas las fichas.
            var fichasQuery = from f in _context.FichasMedicas select f;

            // filtro de texto para busqueda
            if (!String.IsNullOrEmpty(apellidoBusqueda))
            {
                fichasQuery = fichasQuery.Where(f => f.Apellidos.Contains(apellidoBusqueda));
            }

            // ejecutar la consulta a la BD y pasar resultados avista
            return View(await fichasQuery.ToListAsync());
        }

        // 3. ACCION GUARDAR (POST): Procesa los datos del formulario
        // esta accion se ejecuta cuando el usuario presione el botón "Guardar".
        [HttpPost]
        [ValidateAntiForgeryToken] // medida de seguridad por modificacion de datos
        public async Task<IActionResult> Guardar(FichaMedica ficha, string? sobrescribir)
        {
            try
            {
                // verificar si datos cumplen con regla creada en RutValidoAttribute
                if (ModelState.IsValid)
                {
                    // busca en la BD registro con el mismo rut
                    var registroExistente = await _context.FichasMedicas.FirstOrDefaultAsync(f => f.Rut == ficha.Rut);

                    if (registroExistente != null) // si existe el regsitro pide al usuario verificar si quiere sobreescribir
                    {
                        if (sobrescribir == "si")
                        {
                            // actualizar campos del registro con los nuevos datos
                            registroExistente.Nombres = ficha.Nombres;
                            registroExistente.Apellidos = ficha.Apellidos;
                            registroExistente.Direccion = ficha.Direccion;
                            registroExistente.Ciudad = ficha.Ciudad;
                            registroExistente.Telefono = ficha.Telefono;
                            registroExistente.Email = ficha.Email;
                            registroExistente.FechaNacimiento = ficha.FechaNacimiento;
                            registroExistente.Sexo = ficha.Sexo;
                            registroExistente.EstadoCivil = ficha.EstadoCivil;
                            registroExistente.Comentarios = ficha.Comentarios;

                            _context.Update(registroExistente);
                            TempData["MensajeExito"] = "¡Registro actualizado correctamente!";
                        }
                        else
                        {
                            // si el usuario no cambia nada se le enviara una alerta y se guardaran los datos
                            TempData["MensajeAlerta"] = $"El RUT '{ficha.Rut}' ya existe. ¿Desea sobrescribir los datos?";
                            TempData["FichaExistente"] = System.Text.Json.JsonSerializer.Serialize(ficha);
                            return RedirectToAction(nameof(Index));
                        }
                    }
                    else // opcion de rut no existe, se crea un nuevo registro
                    {
                        _context.Add(ficha);
                        TempData["MensajeExito"] = "¡Registro guardado correctamente!";
                    }

                    await _context.SaveChangesAsync(); // guardar cambios
                    return RedirectToAction(nameof(Index)); // redirigir al usuario a pagina principal
                }
            }
            catch (DbUpdateException ex)
            {
                // manejo de excepciones (por guardado erroneo)
                ModelState.AddModelError("", "No se pudo guardar los cambios. " +
                    "Por favor, revise los datos e intente de nuevo. Error: " + ex.InnerException?.Message);
            }
            catch (Exception ex)
            {
                // manejo de excepeciones (otro tipo de errores)
                ModelState.AddModelError("", "Ha ocurrido un error inesperado. " + ex.Message);
            }

            // excepcion fatal, vuelta a pagina principal y vista de errores ocurridos.
            var fichasQuery = from f in _context.FichasMedicas select f;
            return View("Index", await fichasQuery.ToListAsync());
        }
    }
}