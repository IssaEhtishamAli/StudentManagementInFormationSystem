import { Component, OnInit } from '@angular/core';
import { EventSettingsModel, GroupModel, View, WorkHoursModel } from '@syncfusion/ej2-angular-schedule';
import { extend } from '@syncfusion/ej2-base';

@Component({
  selector: 'app-timetable',
  templateUrl: './timetable.component.html',
  styleUrls: ['./timetable.component.scss']
})
export class TimetableComponent implements OnInit {

  ngOnInit(): void {
  }
  public data: Object[] = <Object[]>extend([],  null, true);
  public selectedDate: Date = new Date(2018, 5, 5);
  public currentView: View = 'WorkWeek';
  public workHours: WorkHoursModel = { start: '09:00', end: '19:00' };
  public projectResourceDataSource: Object[] = [
    { text: 'PROJECT SARHAD UNIVERSITY OF SCIENCES', id: 1, color: '#1aaa55' }
  ];
  public categoryResourceDataSource: Object[] = [
    { text: 'Development', id: 1, color: '#1aaa55' },
    { text: 'Testing', id: 2, color: '#7fa900' }
  ];
  public group: GroupModel = { byGroupID: false, resources: ['Projects', 'Categories'] };
  public allowMultiple: Boolean = true;
  public eventSettings: EventSettingsModel = {
    dataSource: this.data,
    fields: {
      subject: { title: 'Summary', name: 'Subject' },
      description: { title: 'Comments', name: 'Description' }
    }
  };
}
