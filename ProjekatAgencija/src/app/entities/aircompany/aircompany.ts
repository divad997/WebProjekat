
export class AirCompany {
    Id: number;
    Name: string;
    Address: string;
    About: string;
    Prices: string;
    Destinations: Array<Destination>;
    Flights: Array<Flight>;
    Ratings: Array<Rating>;  

    public constructor(init?: Partial<AirCompany>) {
        Object.assign(this, init);
    }
}

export class Destination{
    Id: number;
    Destination1: string;
    AirCompanyId: number;

    AirCompany: AirCompany;

    public constructor(init?: Partial<Destination>) {
        Object.assign(this, init);
    }
}

export class Flight{
    Id: number;
    TakeoffDate: Date;
    LandingDate: Date;
    TakeoffTime: Date;
    FlightLength: number;
    TicketPrice: number;
    AirCompanyId: number;
    AirCompany: AirCompany;
    Ratings: Array<Rating>;  

    public constructor(init?: Partial<Flight>) {
        Object.assign(this, init);
    }
}

export class Rating{
    Id: number;
    Rating1: number;
    AirCompanyId: number;
    FlightId: number;
    AirCompany: AirCompany;
    Flight: Flight;

    public constructor(init?: Partial<Rating>) {
        Object.assign(this, init);
    }
}
