import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ColDef, ColumnApi, GridApi } from 'ag-grid-community';
import { ToastrService } from 'ngx-toastr';
import { Teachers } from 'src/app/core/classes/teachers/teachers';
import { TeachersService } from 'src/app/core/services/teachers/teachers.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-teachers',
  templateUrl: './teachers.component.html',
  styleUrls: ['./teachers.component.scss']
})
export class TeachersComponent implements OnInit {
  @ViewChild('Dialog',{static:true}) secondDialog:TemplateRef<any>;
  errors = "errorMessages";
  reGisterTeacherForm:FormGroup;
  public teacher: Teachers[];  
  public columnDefs: ColDef[];  
  private api: GridApi;  
  private columnApi: ColumnApi;
  public rowSelection;  
  public paginationPageSize;
  //---------------- Edit teacher form fields variables ------------//
  id:number=0;
  teacher_name:string="";
  cnic_no:string="";
  address:string="";
  description:string="";
  contact_no:string="";
  userType:string='';
  user_id:number;
  //-------------------//
  private createColumnDefs() {  
    return [{  
        headerName: 'Id',  
        field: 'id',  
        filter: true,  
        enableSorting: true,  
        editable: true,  
        sortable: true,
        checkboxSelection: true
    }, {  
        headerName: 'Teacher Name',  
        field: 'teacher_name',  
        filter: true,  
        editable: true,  
        sortable: true  
    },{  
      headerName: 'Cnic No',  
      field: 'cnic_no',  
      filter: true,  
      editable: true,  
      sortable: true 
     },
     {  
        headerName: 'Address',  
        field: 'address',  
        filter: true,  
        sortable: true,  
        editable: true,  
    }, {  
        headerName: 'Teacher Description',  
        field: 'description',  
        filter: true,  
        editable: true,  
        sortable: true  
    }, 
    {  
      headerName: 'Contact No',  
      field: 'contact_no',  
      filter: true,  
      editable: true  
  },
  ]}  
  constructor(
    private teacherService: TeachersService, 
    private router: Router, 
    private toastr: ToastrService,
    public dialog:MatDialog,
    public addDialog:MatDialog
    ) { 
      this.columnDefs = this.createColumnDefs();
      this.paginationPageSize = 10;
      }  
  ngOnInit(): void {
    this.addTeacherForm();
    const data=JSON.parse(localStorage.getItem('userData'));
    this.userType = data.user_type;
    this.user_id = data.id;
    if(this.userType=='Teacher'){
      this.teacherService.getTeacherByID(this.user_id).subscribe((res:any)=>{
        console.log("----------Student data get by id ---------------------")
        console.log(res.result)
       this.teacher=res.result;
      })
     }
     else{
      this.getAllTeachers();
    }
  }
  onGridReady(params): void {  
    this.api = params.api;  
    this.columnApi = params.columnApi;  
    this.api.sizeColumnsToFit();  
}  
getAllTeachers(): void{
  this.teacherService.getTeachers().subscribe((data:any)=>{
    if(data.statusCode===200){
      this.teacher=data.result;
    }
    else if(data.statusCode=500){
     this.toastr.error("Internal server error")
    }
  },
  (error:any)=>{
    this.toastr.error("Internal Server Error", "Please check Web Api is running?");
  }
  )
}
deleteTeacher(): void{  
  var selectedRows = this.api.getSelectedRows();  
  if (selectedRows.length == 0) {  
      this.toastr.error("Error", "Please select a teacher for deletion");  
      return;  
  }
  const swalWithBootstrapButtons = Swal.mixin({
    confirmButtonColor: '#16A085',
    cancelButtonColor: '#d33',
    timer: 8000,
    timerProgressBar: true,
    showCloseButton: true,
    });
    swalWithBootstrapButtons.fire({
      title: 'Are you sure?',
      text: "You won't be able to revert this!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, delete it!',
      cancelButtonText: 'No, cancel!',
      reverseButtons: true
    }).then((result) => {
      if (result.isConfirmed) {
    this.teacherService.deleteTeacher(selectedRows[0].id).subscribe((data:any) => {
      if(data.statusCode===200){
        this.toastr.success(data.message);
        this.getAllTeachers();  
      }
      else if(data.statusCode=500){
        this.toastr.error("Internal Server Error");
    }  
  },
  (error:any)=>{
    this.toastr.error("Internal Server Error", "Please check Web Api is running?");
  }
  )
  swalWithBootstrapButtons.fire(
    'Deleted!',
    'Your file has been deleted.',
    'success'
  )
} else if (
  /* Read more about handling dismissals below */
  result.dismiss === Swal.DismissReason.cancel
) {
  swalWithBootstrapButtons.fire(
    'Cancelled',
    'Your imaginary file is safe :)',
    'error'
  )
}
})
}
//------------------- Add teacher dialog ---------------//
panelOpenState = false;
step = 0;
setStep(index: number) {
  this.step = index;
}
agGridHide=true;
teacherForm=false;
addTeacherDialog(){
  this.agGridHide=false;
  this.teacherForm=true;
}
addTeacherForm(): void{
  this.reGisterTeacherForm= new FormGroup({
    teacher_name:new FormControl('',[Validators.required,Validators.minLength(6)]),
    cnic_no:new FormControl('',[Validators.required,Validators.minLength(6)]),
    address:new FormControl('',[Validators.required,Validators.minLength(6)]),
    description:new FormControl('',[Validators.required,Validators.minLength(6)]),
    contact_no:new FormControl('',[Validators.required,Validators.minLength(6)]),
  })
}
reGisterTeacher(){
  this.teacherService.addTeacher(this.reGisterTeacherForm.value).subscribe((data:any)=>{
    if(data.statusCode===200){
      this.toastr.success('Record updated sucessfully');
      this.agGridHide=true;
      this.teacherForm=false;
      this.addDialog.closeAll();
      this.getAllTeachers();  
    }
    else if(data.statusCode=500){
      this.toastr.error("Internal server error")
    }
  },
  (error:any)=>{
    this.toastr.error("Internal Server Error", "Please check Web Api is running?");
  }
  );
}
//---------------------Edit teacher dialog -----------------//
editTeacherRegister(form:any){
  let upDateFormFields={
    id:this.id,
    teacher_name:form.teacher_name,
    cnic_no:form.cnic_no,
    address:form.address,
    description:form.description,
    contact_no:form.contact_no,
  };
  var selectedRows = this.api.getSelectedRows(); 
  this.teacherService.upDateTeacher(selectedRows[0].id,upDateFormFields).subscribe((data:any)=>{
    if(data.statusCode===200){
      this.toastr.success(data.message);
      this.dialog.closeAll();
      this.getAllTeachers();  
    }
    else if(data.statusCode=500){
      this.toastr.error("Internal server error")
    }
  },
  (error:any)=>{
    this.toastr.error("Internal Server Error", "Please check Web Api is running?");
  });
}
editTeacherDialog(templateRef: TemplateRef<any>): void{
  var selectedRows = this.api.getSelectedRows();
  if (selectedRows.length == 0) {  
    this.toastr.error("Error", "Please select a teacher from record");  
};
this.id= selectedRows[0].id;
  this.teacher_name = selectedRows[0].teacher_name;
  this.cnic_no = selectedRows[0].cnic_no;
  this.address = selectedRows[0].address;
  this.description = selectedRows[0].description;
  this.contact_no = selectedRows[0].contact_no;
  this.dialog.open(templateRef,{
    width:'45%',
    height:'58%'
  });
}
}
