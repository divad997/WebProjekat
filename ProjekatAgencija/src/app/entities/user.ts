export class User {
    Id : number;
    Username : string;
    Email : string;
    Password : string;
    ConfirmPassword : string;
    Name : string;
    LastName : string;
    City : string;
    PhoneNumber : string;
    PassportNumber : string;
    Role : string;

    public constructor(init?: Partial<User>) {
        Object.assign(this, init);
    }
}
