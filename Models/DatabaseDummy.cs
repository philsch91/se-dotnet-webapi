using System;
using System.Collections.Generic;

namespace se_dotnet_webapi.Models {

    public class DatabaseDummy {

        private static DatabaseDummy instance = null;
        private static readonly object threadlock = new object();
        private List<Car> carList = new List<Car>();
        public enum Actions { Add, Retrieve, Update, Remove};

        private DatabaseDummy(){
            this.initData();
        }

        public static DatabaseDummy Instance {
            get {
                lock(threadlock){
                    if(instance == null){
                        instance = new DatabaseDummy();
                    }
                    return instance;
                }
            }
        }

        private void initData(){
            Car c1 = new Car(); c1.Id = 1; c1.Type = "Ferrari"; c1.Color = "Red";
            Car c2 = new Car(); c2.Id = 2; c2.Type = "Mercedes"; c2.Color = "Silver";
            Car c3 = new Car(); c3.Id = 3; c3.Type = "Lamborghini"; c3.Color = "Yellow";
            
            this.carList.Add(c1);
            this.carList.Add(c2);
            this.carList.Add(c3);
        }

        public List<Car> GetCars() {
            return this.carList;
        }

        public Car FindCarById(int id){
            foreach (var car in this.carList){
                if(car.Id == id){
                    return car;
                }
            }

            return null;
        }

        public bool AddCar(Car car){
            this.carList.Add(car);
            return true;
        }

        public DatabaseDummy.Actions UpdateCar(Car car){
            foreach(Car c in this.carList){
                if(c.Equals(car)){
                    c.Type = car.Type;
                    c.Color = car.Color;
                    return DatabaseDummy.Actions.Update;
                }
            }

            this.AddCar(car);
            return DatabaseDummy.Actions.Add;
        }

        public bool DeleteCar(Car car){
            this.carList.Remove(car);
            return true;
        }
    }
}