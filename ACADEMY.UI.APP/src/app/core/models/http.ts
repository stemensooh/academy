import { HttpHeaders } from '@angular/common/http'

export const httpOptions = {
    headers: new HttpHeaders({
        'Content-type': 'application/json',
        'Access-Control-Allow-Origin': '*'
    }),
    observe: 'response' as const
}

export interface HttpResult {
    data: string;
    mensaje: string;
}