using System;

public class Car {
    public int Id { get; set; }
    public string Type { get; set; }
    public string Color { get; set; }

    public override bool Equals(Object obj){
        if((obj == null) || !this.GetType().Equals(obj.GetType())){
            return false;
        }

        Car c = (Car) obj;
        return this.Id == c.Id;
    }

    public override int GetHashCode(){
        int hashcode = 1234;
        hashcode = hashcode * this.Type.GetHashCode();
        hashcode = hashcode * this.Color.GetHashCode();
        return hashcode;
    }
}