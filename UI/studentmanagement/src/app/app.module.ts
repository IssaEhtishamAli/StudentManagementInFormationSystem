import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
//-------------------http client module -----------------------//
import { HttpClientModule } from '@angular/common/http';
//-------------------- others module ----------------------------//
import { ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
//---------------- applications modules ---------------------------//
import { AllmaterialModule } from './shared/allmaterial.module';
import { HomeModule } from './layouts/home/home.module';
//------------------------ services ---------------------------//
import { StudentsService } from './core/services/students/students.service';
import { TeachersService } from './core/services/teachers/teachers.service';
import { AuthService } from './authentication/auth/auth.service';
import { CoursesService } from './core/services/courses/courses.service';
import { SubjectsService } from './core/services/subjects/subjects.service';
import { UserService } from './core/services/user/user.service';
//------------------ authentications components-----------//
import { AppComponent } from './app.component';
import { LoginComponent } from './authentication/login/login.component';
import { OwlDateTimeModule, OwlNativeDateTimeModule } from 'ng-pick-datetime';
import { UserregisterService } from './core/services/useregister/userregister.service';
import { UserprofileService } from './core/services/userprofile/userprofile.service';
import { GenderService } from './core/services/gender/gender.service';
import { CountryService } from './core/services/country/country.service';
import { CitiesService } from './core/services/cities/cities.service';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent
    ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    AppRoutingModule,
    AllmaterialModule,
    HomeModule,
    OwlDateTimeModule,
    OwlNativeDateTimeModule
  ],
  providers: [
    AuthService,
    StudentsService,
    TeachersService,
    CoursesService,
    SubjectsService,
    UserService,
    UserregisterService,
    UserprofileService,
    GenderService,
    CountryService,
    CitiesService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
