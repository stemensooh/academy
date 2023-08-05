import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import * as feather from 'feather-icons';
import { LayoutService } from '../../../services/layout.service';
import { NavService } from '../../../services/nav.service';
import { fadeInAnimation } from '../../../data/router-animation/router-animation';
import { AppService } from 'src/app/app.service';
import { HomeService } from 'src/app/pages/home/home.service';
import { Opcion } from 'src/app/core/interfaces/roles';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.scss'],
  // animations: [fadeInAnimation],
})
export class ContentComponent implements OnInit, AfterViewInit {
  opciones$: Observable<Opcion[]> | null = null;

  constructor(
    private route: ActivatedRoute,
    public navServices: NavService,
    public layout: LayoutService,
    private appService: AppService,
    private service: HomeService
  ) // private sharedService: SharedService
  {
    this.route.queryParams.subscribe((params) => {
      this.layout.config.settings.layout = params.layout
        ? params.layout
        : this.layout.config.settings.layout;
    });
  }

  ngAfterViewInit() {
    setTimeout(() => {
      feather.replace();
    });
  }

  public getRouterOutletState(outlet) {
    return outlet.isActivated ? outlet.activatedRoute : '';
  }

  get layoutClass() {
    return 'compact-wrapper';
  }

  ngOnInit() {
    console.log('Content - ngOnInit');
    // this.service.getUsuarioMenu().subscribe(opciones => {
    //   console.log('getUsuarioMenu', opciones);
    // })
    this.opciones$ = this.service.getUsuarioMenu().pipe(
      map((opciones) => {
        console.log('getUsuarioMenu', opciones);
        let opcionesPadre: Opcion[] = [];
        let dictionary: { [key: string]: Opcion } = {};
        opciones.forEach((opcion) => {
          if (opcion.idPadre == null) {
            opcion.opciones = [];
            opcionesPadre.push(opcion);
          }
          dictionary[opcion.id] = opcion;
        });
        opciones.forEach((opcion) => {
          if (opcion.idPadre != null) {
            dictionary[opcion.idPadre].opciones.push(dictionary[opcion.id]);
          }
        });
        return opcionesPadre;
      })
    );

    // this.opciones$.subscribe(data => {
    //   console.log(data);
    // })
  }
}
