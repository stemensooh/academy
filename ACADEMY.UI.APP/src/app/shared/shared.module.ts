import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MdModule } from './md/md.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MdModule
  ],
  exports: [
    MdModule
  ]
})
export class SharedModule { }
