import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CoursesComponent } from './courses/courses.component';
import { StudentsComponent } from './students/students.component';
import { SubjectsComponent } from './subjects/subjects.component';
import { TeachersComponent } from './teachers/teachers.component';
import { TimetableComponent } from './timetable/timetable.component';
import { UserComponent } from './usermanagement/user/user.component';
import { UsertypeComponent } from './usermanagement/usertype/usertype.component';
import { UserprofileComponent } from './userprofile/userprofile.component';
const routes: Routes = [
  {
    path:'students',
    component:StudentsComponent
  },
  {
    path:'teachers',
    component:TeachersComponent
  },
  {
    path:'timetable',
    component:TimetableComponent
  },
  {
    path:'courses',
    component:CoursesComponent
  },
  {
    path:'subjects',
    component:SubjectsComponent
  },
  {
    path:'user',
    component:UserComponent
  },
  {
    path:'usertype',
    component:UsertypeComponent
  },
  {
  path:'userprofile',
  component:UserprofileComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ManagementRoutingModule { }
