import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { MatDialog } from '@angular/material/dialog';
import { ColDef, GridApi, ColumnApi } from 'ag-grid-community';
import { Students } from 'src/app/core/classes/students/students';
import { StudentsService } from 'src/app/core/services/students/students.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import Swal from 'sweetalert2';
import { Degrees } from 'src/app/core/classes/degrees/degrees';
import { Sections } from 'src/app/core/classes/sections/sections';
import { Cities } from 'src/app/core/classes/cities/cities';
import { CitiesService } from 'src/app/core/services/cities/cities.service';
import { SectionsService } from 'src/app/core/services/sections/sections.service';
import { DegreesService } from 'src/app/core/services/degrees/degrees.service';
import { UserService } from 'src/app/core/services/user/user.service';
import { Users } from 'src/app/core/classes/user/user';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.scss']
})
export class StudentsComponent implements OnInit {
  @ViewChild('Dialog',{static:true}) secondDialog:TemplateRef<any>;
  errors = "errorMessages";
  agGridHide=true;
  studentForm=false;
  panelOpenState = false;
  step = 0;
  studentRegisterForm:FormGroup;
  public students:Students[];  
  public degrees:Degrees[];
  public sections:Sections[];
  public users:Users[];
  public cities:Cities[];
  public columnDefs: ColDef[];  
  private api: GridApi;  
  private columnApi: ColumnApi;
  public rowSelection;    
  public paginationPageSize;
  //------------Edit form fields ------------//
  id:number=0;  
  roll_no:number=0;
  full_name:string="";
  father_name:string="";
  address:string="";
  cnic_no:string="";
  contact_no:string="";
  degree_id:number;
  city_id:number=0;
  section_id:number;
  user_id:number;
  entry_date_time:string;
  email:string="";
  userType:string='';
  //---------------------------------------//
  private createColumnDefs() {  
    return [
    {  
        headerName: 'Roll No',  
        field: 'roll_no',  
        filter: true,  
        editable: true,  
        sortable: true,
        checkboxSelection: true
    },{  
      headerName: 'Full Name',  
      field: 'full_name',  
      filter: true,  
      editable: true,  
      sortable: true  },
     {  
        headerName: 'Father Name',  
        field: 'father_name',  
        filter: true,  
        sortable: true,  
        editable: true,  
    }, {  
        headerName: 'Address',  
        field: 'address',  
        filter: true,  
        editable: true,  
        sortable: true  
    }, 
    {
      headerName: 'Studen Email',  
      field: 'email',  
      filter: true,  
      editable: true  
    },
    {  
        headerName: 'CNIC No',  
        field: 'cnic_no',  
        filter: true,  
        editable: true  
    },
    {  
      headerName: 'Contact No',  
      field: 'contact_no',  
      filter: true,  
      editable: true  
  },
  {
    headerName: 'Degree Title',  
    field: 'degree_title',  
    filter: true,  
    editable: true  
  },
  {
    headerName: 'Section Name',  
    field: 'section_name',  
    filter: true,  
    editable: true  
  },
  {
    headerName: 'City Name',  
    field: 'city',  
    filter: true,  
    editable: true  
  },
  {  
    headerName: 'Date Time',  
    field: 'entry_date_time',  
    filter: true,  
    editable: true 
  }
  ]}  
  constructor(
    private degreesService:DegreesService,
    private sectionsService:SectionsService,
    private citiesService:CitiesService,
    private userService:UserService,
    private studentService: StudentsService, 
    private toastr: ToastrService,
    public dialog:MatDialog,
    public addDialog:MatDialog,
    ) { 
      this.columnDefs = this.createColumnDefs();  
      this.paginationPageSize = 10;
      }
  ngOnInit(): void{
    this.formRegister();
    this.getAllCities();
    this.getAllDegrees();
    this.getAllSections();
    this.getAllUsers();
    const data=JSON.parse(localStorage.getItem('userData'));
    this.userType = data.user_type;
    this.user_id = data.id
    if(this.userType=='Student'){
     this.studentService.getStudentById(this.user_id).subscribe((res:any)=>{
      this.students=res.result;
     })
    }
    else{
      this.getAllStudents();
    }
  }
  onGridReady(params): void{  
    this.api = params.api;  
    this.columnApi = params.columnApi;  
    this.api.sizeColumnsToFit();  
}  
getAllUsers():void{
this.userService.getUser().subscribe((data=>{
  this.users=data.result;
}))
}
getAllStudents(): void{
  this.studentService.getStudents().subscribe((data:any)=>{
    if(data.statusCode===200){
      this.students=data.result;
    }
    else if(data.statusCode=500){
      this.toastr.error("Internal Server Error");
      }
  },
  );
}
getAllCities():void{
this.citiesService.getCities().subscribe((data:any)=>{
if(data.statusCode===200){
this.cities=data.result;
}
else if(data.statusCode=500){
  this.toastr.error("Internal Server Error");
}
})
}
getAllSections():void{
  this.sectionsService.getSections().subscribe((data:any)=>{
    if(data.statusCode===200){
      this.sections=data.result;
    }
    else if(data.statusCode=500){
      this.toastr.error("Internal Server Error");
    }
  })
}
getAllDegrees():void{
this.degreesService.getDegrees().subscribe((data:any)=>{
  if(data.statusCode===200){
    this.degrees=data.result;
  }
  else if(data.statusCode=500){
    this.toastr.error("Internal Server Error");
  }
})
}
delete():void{
  var selectedRows = this.api.getSelectedRows();  
  if (selectedRows.length == 0) {  
      this.toastr.error("Error", "Please select a student for deletion");   
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
      this.studentService.deleteStudent(selectedRows[0].id).subscribe((data:any)=>{
        if(data.statusCode===200){
          this.toastr.success(data.message);  
          this.getAllStudents();  
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
//--------------------------Add students dialog ---------------------------//

setStep(index: number) {
  this.step = index;
}
addStudentDialog(){
this.agGridHide=false;
this.studentForm=true;
}
formRegister(): void{
  this.studentRegisterForm= new FormGroup({
    roll_no:new FormControl('',[Validators.required,Validators.minLength(6)]),
    full_name:new FormControl('',[Validators.required,Validators.minLength(6)]),
    father_name:new FormControl('',[Validators.required,Validators.minLength(6)]),
    address:new FormControl('',[Validators.required,Validators.minLength(6)]),
    cnic_no:new FormControl('',[Validators.required,Validators.minLength(6)]),
    contact_no:new FormControl('',[Validators.required,Validators.minLength(6)]),
    degree_id:new FormControl('',[Validators.required]),
    section_id:new FormControl('',[Validators.required]),
    city_id:new FormControl('',[Validators.required]),
    user_id:new FormControl('',[Validators.required]),
    entry_date_time:new FormControl('',[Validators.required,Validators.minLength(6)]),
  })
}
reGisterStudent(){
  this.studentService.addStudent(this.studentRegisterForm.value).subscribe((data:any)=>{
    debugger;
    if(data.statusCode===200){
      this.toastr.success(data.message);
      this.agGridHide=true;
      this.studentForm=false;
      this.getAllStudents();  
    }
    else if(data.statusCode=409){
        this.toastr.error(data.message)
     }
    else if(data.statusCode==500){
        this.toastr.error("Internal Server Error");
      }
  },
  (error:any)=>{
        this.toastr.error("Internal Server Error", "Please check Web Api is running?");
      }
  );
}
//--------------------------- Edit students dialog --------------------------//
editStudentRegister(form:any): void{
  debugger;
  let upDateFormFields={
    id:this.id,
    roll_no:form.roll_no,
    full_name:form.full_name,
    father_name:form.father_name,
    address:form.address,
    cnic_no:form.cnic_no,
    contact_no:form.contact_no,
    degree_id:form.degree_id,
    section_id:form.section_id,
    city_id:form.city_id,
    user_id:form.user_id,
    entry_date_time:form.entry_date_time,
  };
  this.studentService.upDateStudent(upDateFormFields).subscribe((data:any)=>{
    if(data.statusCode===200){
      this.toastr.success('Record updated sucessfully');
      this.dialog.closeAll();
      this.getAllStudents();
    }
    else if(data.statusCode=500){
      this.toastr.error("Internal server error")
    }
  },
  (error:any)=>{
    this.toastr.error("Internal Server Error");
  },
  );
}
editDialog(templateRef: TemplateRef<any>): void{  
  var selectedRows = this.api.getSelectedRows();
  if (selectedRows.length == 0) {  
    this.toastr.error("Error","Please select a student from record");  
    return;  
};
this.id= selectedRows[0].id;
  this.roll_no = selectedRows[0].roll_no;
  this.full_name = selectedRows[0].full_name;
  this.father_name = selectedRows[0].father_name;
  this.address = selectedRows[0].address;
  this.cnic_no = selectedRows[0].cnic_no;
  this.contact_no = selectedRows[0].contact_no;
  this.degree_id=selectedRows[0].degree_id;
  this.section_id=selectedRows[0].section_id,
  this.city_id=selectedRows[0].city_id;
  this.user_id=selectedRows[0].user_id;
  this.entry_date_time = selectedRows[0].entry_date_time;
  this.dialog.open(templateRef,{
    width:'45%',
    height:'71'
  });
}
}
