export class Users {
    id:number;
    user_name:string;
    password:string;
    email:string;
    user_type:number;
    status:number;
}

export class AddUsers{
    user_name:string;
    password:string;
    email:string;
    user_type:number;
    status:number;
}
export class UserLogin{
    email:string;
    password:string;
}

export class UpdatePassword{
    email:string;
    password:string;
}