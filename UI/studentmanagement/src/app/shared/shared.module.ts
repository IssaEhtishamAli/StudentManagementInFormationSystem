import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';
import { SidenavComponent } from './components/sidenav/sidenav.component';
import { AllmaterialModule } from './allmaterial.module';
import { RouterModule } from '@angular/router';




@NgModule({
  declarations: [
    HeaderComponent,
    SidenavComponent,
    FooterComponent,
  ],
  imports: [
    CommonModule,
    AllmaterialModule,
    RouterModule
  ],
  exports:[
    HeaderComponent,
    SidenavComponent,
    FooterComponent,
    RouterModule

  ]
})
export class SharedModule { }
