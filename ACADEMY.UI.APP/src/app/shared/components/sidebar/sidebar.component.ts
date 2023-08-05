import { Component, ViewEncapsulation, HostListener, Input, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { Menu, NavService } from '../../services/nav.service';
import { LayoutService } from '../../services/layout.service';
import { Observable, map } from 'rxjs';
import { Opcion } from 'src/app/core/interfaces/roles';
import { AppService } from 'src/app/app.service';
import { HomeService } from 'src/app/pages/home/home.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class SidebarComponent implements OnInit {
  opciones$: Observable<Menu[]> | null = null;

  public iconSidebar;
  public menuItems: Menu[];
  public url: any;
  public fileurl: any;

  // For Horizontal Menu
  public margin: any = 0;
  public width: any = window.innerWidth;
  public leftArrowNone: boolean = true;
  public rightArrowNone: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private appService: AppService,
    private service: HomeService,
    private router: Router, 
    public navServices: NavService,
    public layout: LayoutService) {
    // this.navServices.items.subscribe(menuItems => {
    //   this.menuItems = menuItems;
    //   this.router.events.subscribe((event) => {
    //     if (event instanceof NavigationEnd) {
    //       menuItems.filter(items => {
    //         if (items.path === event.url) {
    //           this.setNavActive(items);
    //         }
    //         if (!items.children) { return false; }
    //         items.children.filter(subItems => {
    //           if (subItems.path === event.url) {
    //             this.setNavActive(subItems);
    //           }
    //           if (!subItems.children) { return false; }
    //           subItems.children.filter(subSubItems => {
    //             if (subSubItems.path === event.url) {
    //               this.setNavActive(subSubItems);
    //             }
    //           });
    //         });
    //       });
    //     }
    //   });
    // });

  }

  ngOnInit(): void {
    console.log('Content - ngOnInit');
    this.service.getUsuarioMenu().subscribe(opciones => {
      console.log('getUsuarioMenu', opciones);
    })
    this.opciones$ = this.service.getUsuarioMenu().pipe(
      map((opciones: Menu[]) => {

        console.log('getUsuarioMenu', opciones);
        let opcionesPadre: Menu[] = [];
        let dictionary: { [key: string]: Menu } = {};
        opciones.forEach((opcion) => {
          if (opcion.idPadre == null) {
            opcion.children = [];
            opcionesPadre.push(opcion);
          }
          dictionary[opcion.id] = opcion;
        });
        opciones.forEach((opcion) => {
          if (opcion.idPadre != null) {
            dictionary[opcion.idPadre].children.push(dictionary[opcion.id]);
          }
        });
        return opcionesPadre;
      })
    );

    // this.opciones$.subscribe(data => {
    //   console.log(data);
    // })
  }

  @HostListener('window:resize', ['$event'])
  onResize(event) {
    this.width = event.target.innerWidth - 500;
  }

  sidebarToggle() {
    this.navServices.collapseSidebar = !this.navServices.collapseSidebar;
  }

  // Active Nave state
  setNavActive(item) {
    this.menuItems.filter(menuItem => {
      if (menuItem !== item) {
        menuItem.active = false;
      }
      if (menuItem.children && menuItem.children.includes(item)) {
        menuItem.active = true;
      }
      if (menuItem.children) {
        menuItem.children.filter(submenuItems => {
          if (submenuItems.children && submenuItems.children.includes(item)) {
            menuItem.active = true;
            submenuItems.active = true;
          }
        });
      }
    });
  }

  // Click Toggle menu
  toggletNavActive(item) {
    if (!item.active) {
      this.menuItems.forEach(a => {
        if (this.menuItems.includes(item)) {
          a.active = false;
        }
        if (!a.children) { return false; }
        a.children.forEach(b => {
          if (a.children.includes(item)) {
            b.active = false;
          }
        });
      });
    }
    item.active = !item.active;
  }


  // For Horizontal Menu
  scrollToLeft() {
    if (this.margin >= -this.width) {
      this.margin = 0;
      this.leftArrowNone = true;
      this.rightArrowNone = false;
    } else {
      this.margin += this.width;
      this.rightArrowNone = false;
    }
  }

  scrollToRight() {
    if (this.margin <= -3051) {
      this.margin = -3464;
      this.leftArrowNone = false;
      this.rightArrowNone = true;
    } else {
      this.margin += -this.width;
      this.leftArrowNone = false;
    }
  }


}
