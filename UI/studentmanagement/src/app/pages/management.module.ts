import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
//------forms and grid module --------------//
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AgGridModule } from 'ag-grid-angular';
//------ applications module --------------//
import { ManagementRoutingModule } from './management-routing.module';
import { AllmaterialModule } from '../shared/allmaterial.module';
//------- date time module -----------------------//
import { OwlDateTimeModule, OwlNativeDateTimeModule } from 'ng-pick-datetime';
//------application components -----------//
import { StudentsComponent } from './students/students.component';
import { TeachersComponent } from './teachers/teachers.component';
import { CoursesComponent } from './courses/courses.component';
import { SubjectsComponent } from './subjects/subjects.component';
import { UserComponent } from './usermanagement/user/user.component';
import { UsertypeComponent } from './usermanagement/usertype/usertype.component';
import { UserprofileComponent } from './userprofile/userprofile.component';
import { TimetableComponent } from './timetable/timetable.component';
import { ScheduleModule, AgendaService, DayService, WeekService, WorkWeekService, MonthService } from '@syncfusion/ej2-angular-schedule';
@NgModule({
  declarations: [
    StudentsComponent,
    TeachersComponent,
    CoursesComponent,
    SubjectsComponent,
    UserComponent,
    UsertypeComponent,
    UserprofileComponent,
    TimetableComponent,
  ],
  imports: [
    FormsModule,
    CommonModule,
    AgGridModule.withComponents([]),
    ReactiveFormsModule,
    ManagementRoutingModule,
    AllmaterialModule,
    OwlDateTimeModule,
    OwlNativeDateTimeModule,
    ScheduleModule
  ],
  exports:[  
  ],
  providers:[
    AgendaService, DayService, WeekService, WorkWeekService, MonthService
  ]
})
export class ManagementModule { }
