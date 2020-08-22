export class User {
    Id : number;
    Username : string;
    Email : string;
    Password : string;
    Name : string;
    LastName : string;
    City : string;
    PhoneNumber : string;
    Role : string;

    public constructor(init?: Partial<User>) {
        Object.assign(this, init);
    }
}
