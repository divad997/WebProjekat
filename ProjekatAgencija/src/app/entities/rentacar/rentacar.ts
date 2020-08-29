export class RentCompany {
   
    Id: number;
    Name: string;
    Address: string;
    Cars: Array<Car>;
    Prices: string;
    Description: string;
    Locations: Array<Location>;
    
    Ratings: Array<Rating>;  

    public constructor(init?: Partial<RentCompany>) {
        Object.assign(this, init);
    }

}


export class Car
{
    Id: number;
    Car1: string;
    Ratings: Array<Rating>;
    

    public constructor(init?: Partial<Car>) {
        Object.assign(this, init);
    }

}

export class Rating{
    Id: number;
    Rating1: number;

    public constructor(init?: Partial<Rating>) {
        Object.assign(this, init);
    }
}

export class Location
{
    Lid: number;
    Location1: string;
    RentCompanyId: number;
    RentCompany: RentCompany;

    public constructor(init?: Partial<Location>) {
        Object.assign(this, init);
    }
}