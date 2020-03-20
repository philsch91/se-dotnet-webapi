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
    public class CarDbController : ControllerBase {
        
        private readonly CarContext context;

        public CarDbController(CarContext context){
            this.context = context;
        }

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

    }
}