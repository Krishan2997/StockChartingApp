export class User {
    UserName: string = ''
    Password: string = ''
    UserType: string = 'user'
    Email: string = ''
    Phone: number = 0
    Confirmed: boolean = true
}

export class Response{
    code?: Number 
    token: string = ''
}