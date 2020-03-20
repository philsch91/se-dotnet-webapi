using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Net.Mime;
using se_dotnet_webapi.Models;

namespace se_dotnet_webapi.Controllers {

    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("/api/[controller]")]
    public class CarController : ControllerBase {

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Car>> GetCars(){
            List<Car> carList = DatabaseDummy.Instance.GetCars();
            return carList;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Car> GetCar(int id){
            Car car = DatabaseDummy.Instance.FindCarById(id);
            
            if(car == null){
                return NotFound();
            }

            return car;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Car> CreateCar(Car car){
            if(car.Id == 0 || car.Type == null || car.Color == null){
                return BadRequest();
            }

            DatabaseDummy.Instance.AddCar(car);
            
            return CreatedAtAction(nameof(GetCar), new { id = car.Id}, car);
        }

        [HttpPut("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Car> PutCar(int id, Car car){
            if(id != car.Id){
                return new BadRequestResult();
                //return BadRequest();
            }

            Car savedCar = DatabaseDummy.Instance.FindCarById(id);

            if(savedCar == null){
                //return new NotFoundResult();
                //return NotFound();
            }

            DatabaseDummy.Actions action = DatabaseDummy.Instance.UpdateCar(car);

            if(action == DatabaseDummy.Actions.Update){
                return new NoContentResult();
                //return NoContent();
            }

            return CreatedAtAction(nameof(GetCar), new { id = car.Id}, car);
            //return Created();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Car> DeleteCar(int id){
            Car car = DatabaseDummy.Instance.FindCarById(id);
            if(car == null){
                return new NotFoundResult();
                //return NotFound();
            }

            DatabaseDummy.Instance.DeleteCar(car);

            return car;
        }
    }
}