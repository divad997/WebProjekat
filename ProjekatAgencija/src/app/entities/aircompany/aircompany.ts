
export class AirCompany {
    Id: number;
    Name: string;
    Address: string;
    About: string;
    Destinations: string;
    Flights: string;
    Prices: string;

    public constructor(init?: Partial<AirCompany>) {
        Object.assign(this, init);
    }
}
