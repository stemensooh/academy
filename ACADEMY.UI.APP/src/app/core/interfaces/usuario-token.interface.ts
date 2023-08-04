export interface UsuarioToken {
  sub: string;
  user: User;
  wedding: Wedding;
  iat: number;
  exp: number;
}

export interface User {
  name: string;
  lastName: string;
  email: string;
}

export interface Wedding {
  id: string;
  tituloPagina: string;
}
