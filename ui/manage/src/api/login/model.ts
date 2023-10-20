export interface CreateLogin {
    username: string;
    password: string;
    grant_type: string;
    client_id: string;
    client_secret: string;
    scope: string;
    code: string;
}