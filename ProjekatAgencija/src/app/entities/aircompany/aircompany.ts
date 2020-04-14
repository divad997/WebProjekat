
export class AirCompany {
    name: string;
    address: string;
    rating: number;
    destinations: Array<string>;
    description: string;

    constructor(name: string, address: string, rating: number, destinations: Array<string>){
        this.name = name;
        this.address = address;
        this.rating = rating;
        this.destinations = destinations;
        this.description = 'asd'
    }
}
