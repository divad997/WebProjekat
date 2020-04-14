export class Rentacar {
   
    name: string;
    address: string;
    rating: number;
    cars: Array<string>;
    description: string;

    constructor(name: string, address: string, rating: number, cars: Array<string>){
        this.name = name;
        this.address = address;
        this.rating = rating;
        this.cars = cars;
        this.description = 'asd'
    }
}
