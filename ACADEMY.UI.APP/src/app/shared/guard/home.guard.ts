import { Injectable } from '@angular/core';
import { Route, UrlSegment, CanMatch } from '@angular/router';
// import { MatSnackBar } from '@angular/material/snack-bar';
import { Usuario } from '../../core/interfaces/usuarios';
// import { Usuario } from '@models/usuarios';
import { AppService } from '../../app.service';
import { HomeService } from '../../pages/home/home.service';

@Injectable({
  providedIn: 'root'
})
export class HomeGuard implements CanMatch {

  constructor(
    private appService: AppService,
    private service: HomeService,
    // private snackBar: MatSnackBar
  ) {}

  async canMatch(route: Route, segments: UrlSegment[]): Promise<boolean> {
    return await this.checkPermisos(route.path ?? "");
  }

  async checkPermisos(permiso: string): Promise<boolean> {
    permiso = permiso.split('/')[0];
    const usuario = await this.service.getUsuarioSesion()?.toPromise() as Usuario;
    if (usuario.estado == false) {
      // this.appService.logout(() => this.snackBar.open('La sesión del usuario ha expirado inicie sesión nuevamente', 'Error', { duration: 5000 }));
    } else {
      const tienePermiso = usuario.rol.permisos.some(p => p.estado == true && p.id == permiso);
      if (usuario.rol.estado == false || !tienePermiso) {
        // this.snackBar.open('El usuario no tiene permisos suficientes para acceder a esta sección', 'Error', { duration: 5000 });
      } else {
        return true;
      }
    }
    return false;
  }
}
