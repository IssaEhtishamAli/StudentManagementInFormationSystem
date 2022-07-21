import { Component, OnInit, Output,EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
@Output() togglesidebarForMe:EventEmitter<any>=new EventEmitter();

constructor(
  private router:Router,
  private toastr:ToastrService,
  ) { }
  ngOnInit(): void {
  }
  togglesidebar(){
  this.togglesidebarForMe.emit()
  }
  signout(){
  this.toastr.success("logout sucessfully");  
  this.router.navigate(['/login']);
  }
}
