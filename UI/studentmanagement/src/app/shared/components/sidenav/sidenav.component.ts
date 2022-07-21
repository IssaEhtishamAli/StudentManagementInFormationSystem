import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent implements OnInit {
  isExpanded = true;
  showSubmenu: boolean = false;
  isShowing = false;
  showSubSubMenu: boolean = false;
  showSubmenu2:boolean=false;
  showSubSubMenu2:boolean=false;
  isShowing2 = false;
  isExpanded2 = true;
  usrManagement=true;
  userType:string='';
  user_id:number=0;
  //----------- router links -------------//
  students:string="/management/students";
  teachers:string="/management/teachers";
  courses:string="/management/courses";
  subjects:string="/management/subjects";
  timetable:string="/management/timetable";
  user:string="/management/user";
  usertype:string="/management/usertype";
  constructor() { }

  ngOnInit(): void {
    const data=JSON.parse(localStorage.getItem('userData'));
    // console.log("get data from local storage..............");
    // console.log(data);
    this.userType = data.user_type;
    this.user_id =data.user_id;
    console.log(this.userType);
  }
}
