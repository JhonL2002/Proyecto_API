using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Proyecto_API.Data;
using Proyecto_API.Models;
using Proyecto_API.Models.Dto;

namespace Proyecto_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        //Inyección de dependencias
        private readonly ILogger<VillaController> _logger;
        private readonly ApplicationDbContext _db;
        public VillaController(ILogger<VillaController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }


        //Primer EndPoint, se llama la lista del DTO
        //Endpoint que trae las villas
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<VillaDto>> GetVillas()
        {
            _logger.LogInformation("Obtener las villas ");
            //Invoca los datos de la clase VillaStore
            return Ok(_db.Villas.ToList());
        }


        //Endpoint que trae una villa
        [HttpGet("id:int", Name ="GetVilla")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<VillaDto> GetVilla(int id)
        {
            if (id==0)
            {
                _logger.LogError("Error al traer villa con id "+id);
                return BadRequest();
            }
            //var villa = VillaStore.villaList.FirstOrDefault(v => v.Id == id);
            var villa = _db.Villas.FirstOrDefault(v => v.Id == id);
            if(villa == null)
            {
                return NotFound();
            }
            return Ok();
        }

        //Endpoint que inserta una villa
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult <VillaDto> CrearVilla([FromBody] VillaDto villaDto)
        {
            //Validar si los datos obligatorios son llenados
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //Validación personalizada (si existe un nombre con la misma villa)
            if (_db.Villas.FirstOrDefault(v => v.Name.ToLower() == villaDto.Name.ToLower()) !=null)
            {
                ModelState.AddModelError("NombreExiste", "La villa con ese nombre ya existe");
                return BadRequest(ModelState);
            }
            //Validar si los datos son nulos
            if(villaDto == null)
            {
                return BadRequest();
            }
            if (villaDto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            Villa modelo = new()
            {
                Name = villaDto.Name,
                Detail = villaDto.Detail,
                UrlImage = villaDto.UrlImage,
                Occupants = villaDto.Occupants,
                Fee = villaDto.Fee,
                SquareMeter = villaDto.SquareMeter,
                Amenity = villaDto.Amenity,

            };

            _db.Villas.Add(modelo);
            _db.SaveChanges();

            return CreatedAtRoute("GetVilla", new {id=villaDto.Id}, villaDto);
        }

        //Endpoint que elimina una villa
        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = _db.Villas.FirstOrDefault(v=>v.Id== id);
            if (villa == null)
            {
                return NotFound();
            }
            //VillaStore.villaList.Remove(villa);
            _db.Villas.Remove(villa);
            _db.SaveChanges();

            return NoContent();
        }

        //Endpoint que actualiza una villa (HttpPut)
        [HttpPut("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateVilla(int id, [FromBody] VillaDto villaDto) 
        { 
            if (villaDto == null || id!=villaDto.Id) 
            {
                return BadRequest();
            }
            //var villa = VillaStore.villaList.FirstOrDefault(v => v.Id == id);
            //villa.Name = villaDto.Name;
            //villa.Occupants = villaDto.Occupants;
            //villa.SquareMeter = villaDto.SquareMeter;

            Villa model = new()
            {
                Id = villaDto.Id,
                Name = villaDto.Name,
                Detail = villaDto.Detail,
                UrlImage = villaDto.UrlImage,
                Occupants = villaDto.Occupants,
                Fee = villaDto.Fee,
                SquareMeter = villaDto.SquareMeter,
                Amenity = villaDto.Amenity,
            };
            _db.Villas.Update(model);
            _db.SaveChanges();
            return NoContent();
        }

        //Endpoint que actualiza una villa (HttpPatch)
        [HttpPatch("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDto> patchDto)
        {
            if (patchDto == null || id ==0)
            {
                return BadRequest();
            }
            //var villa = VillaStore.villaList.FirstOrDefault(v => v.Id == id);
            var villa = _db.Villas.FirstOrDefault(v => v.Id == id);

            VillaDto villaDto = new()
            {
                Id = villa.Id,
                Name = villa.Name,
                Detail = villa.Detail,
                UrlImage = villa.UrlImage,
                Occupants = villa.Occupants,
                Fee = villa.Fee,
                SquareMeter = villa.SquareMeter,
                Amenity = villa.Amenity,
            };

            if(villa == null) return BadRequest();

            patchDto.ApplyTo(villaDto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Villa model = new()
            {
                Id = villaDto.Id,
                Name = villaDto.Name,
                Detail = villaDto.Detail,
                UrlImage = villaDto.UrlImage,
                Occupants = villaDto.Occupants,
                Fee = villaDto.Fee,
                SquareMeter = villaDto.SquareMeter,
                Amenity = villaDto.Amenity,
            };
            _db.Villas.Update(model);
            _db.SaveChanges();
            return NoContent();
        }

    }
}
