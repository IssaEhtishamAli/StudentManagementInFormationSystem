import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeComponent } from './home.component';

//------ applications module ------------------//
import { RouterModule } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';
import { AllmaterialModule } from 'src/app/shared/allmaterial.module';



@NgModule({
  declarations: [
    HomeComponent,
    


  ],
  imports: [
    CommonModule,
    RouterModule,
    SharedModule,
    AllmaterialModule
  ]
})
export class HomeModule { }
