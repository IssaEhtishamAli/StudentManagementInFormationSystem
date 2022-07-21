import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ColDef, ColumnApi, GridApi } from 'ag-grid-community';
import { ToastrService } from 'ngx-toastr';
import { Students } from 'src/app/core/classes/students/students';
import { Subjects } from 'src/app/core/classes/subjects/subjects';
import { Teachers } from 'src/app/core/classes/teachers/teachers';
import { CoursesService } from 'src/app/core/services/courses/courses.service';
import { StudentsService } from 'src/app/core/services/students/students.service';
import { SubjectsService } from 'src/app/core/services/subjects/subjects.service';
import { TeachersService } from 'src/app/core/services/teachers/teachers.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.scss']
})
export class CoursesComponent implements OnInit {
  @ViewChild('Dialog', { static: true }) secondDialog: TemplateRef<any>;
  agGridHide=true;
  courseForm=false;
  panelOpenState = false;
  step = 0;
  public columnDefs: ColDef[];  
  public api: GridApi;
  public defaultColDef;
  public autoGroupColumnDef;
  public rowSelection;  
  private columnApi: ColumnApi;  
  public paginationPageSize;
  //------ Edit course registration -------------//
  reGisterCourseForm:FormGroup;
  errors = "errorMessages";
  editCourseForm:FormGroup;
  public students:Students[];
  public teachers:Teachers[];
  public subjects:Subjects[];
  public courses: any [] = [];
  //-------------Edit course form fields  ----------//
   id:number=0;  
   teacher_id:number = 0;
   subject_id:number = 0;
   student_id:number = 0;
//-----------------------------------------------//
  private createColumnDefs() {  
    return [
      {  
        headerName:'Id',  
        field: 'id',  
        filter: true,  
        enableSorting: true,  
        editable: true,  
        sortable: true,
        minWidth: 120,
        checkboxSelection: true,
    }, {  
        headerName:'Teacher Name',  
        field: 'teacher_name',  
        filter: true,  
        editable: true,  
        sortable: true,  
    },{  
      headerName:'Subject Name',  
      field: 'subject_name',  
      filter: true,  
      editable: true,  
      sortable: true,
      },
     {  
        headerName:'Student Name',  
        field: 'student_name',  
        filter: true,  
        sortable: true,  
        editable: true, 
 
    }, 
  ]}  
  constructor(
    private courseService: CoursesService, 
    private toastr: ToastrService,
    public  dialog:MatDialog,
    public addDialog:MatDialog,
    private subjService:SubjectsService,
    private stdService: StudentsService, 
    private teacherService:TeachersService,
    ) { 
      this.columnDefs = this.createColumnDefs();  
      this.paginationPageSize = 10;
      }
  ngOnInit(): void {
    this.getAllCourse();
    this.getAllStudents();
    this.getAllTeachers();
    this.getAllSubjects();
    this.formRegister();
  }
  onGridReady(params): void {  
    this.api = params.api;  
    this.columnApi = params.columnApi;  
    this.api.sizeColumnsToFit();  
}  
getAllCourse(): void{
  this.courseService.getCourse().subscribe((data:any)=>{
    if(data.statusCode===200){
      this.courses=data.result;
    }
    else if(data.statusCode=500){
      this.toastr.error("Internal Server Error")
    }
  },
  (error:any)=>{
    this.toastr.error("Internal Server Error", "Please check Web Api is running?");
  }
  )
}
getAllSubjects():void{
  this.subjService.getSubject().subscribe(data=>{
    this.subjects=data.result;
  })
}
getAllStudents(): void{
  this.stdService.getStudents().subscribe(data=>{
    this.students=data.result;
  })
}
getAllTeachers(): void{
  this.teacherService.getTeachers().subscribe(data=>{
    this.teachers=data.result;
  })
}
delete(): void {  
  var selectedRows = this.api.getSelectedRows(); 
  if (selectedRows.length == 0) {  
      this.toastr.error("Error !", "Please select a course from record");  
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
        this.courseService.deleteCourse(selectedRows[0].id).subscribe((data:any) => {
      if(data.statusCode===200){
        this.toastr.success("Courses data deleted success fully"); 
        this.getAllCourse();  
      }
      else if(data.statusCode=500){
        this.toastr.error("Internal Server Error")
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
//--------------------------Add courses dialog ----------------//
setStep(index: number) {
  this.step = index;
}
addCoursesDialog(){
  this.agGridHide=false;
  this.courseForm=true;

}  
formRegister():void{
  this.reGisterCourseForm= new FormGroup({
    teacher_id:new FormControl('',[Validators.required]),
    subject_id:new FormControl('',[Validators.required]),
    student_id:new FormControl('',[Validators.required]),  
  })
}
reGisterCourse(){
  this.courseService.addCourse(this.reGisterCourseForm.value).subscribe((data:any)=>{
    if(data.statusCode===200){
      this.toastr.success('Record updated sucessfully');
      this.agGridHide=true;
      this.courseForm=false;
      this.getAllCourse();  
    }
    else if(data.statusCode=500){
    this.toastr.error("Internal Server Error")
    }
  },
  (error:any)=>{
    this.toastr.error("Internal Server Error", "Please check Web Api is running?");
  }
  );
}
//----------------------Courses edit form ---------------------------//
  editCourseRegister(form:any): void{
    let upDateFormFields={
      id:this.id,
      teacher_id:form.teacher_id,
      subject_id:form.subject_id,
      student_id:form.student_id
    };
    var selectedRows = this.api.getSelectedRows();
    this.courseService.upDateCourse(selectedRows[0].id,upDateFormFields).subscribe((data:any)=>{
      if(data.statusCode===200){
        this.toastr.success(data.message);
        this.dialog.closeAll();
        this.getAllCourse();  
      }
      else if(data.statusCode=500){
        this.toastr.error("Internal Server Error")
        }    
    },
    (error:any)=>{
      this.toastr.error("Internal Server Error", "Please check Web Api is running?..."+ error);
    });
  }
  editDialog(templateRef: TemplateRef<any>): void{
    
    var selectedRows = this.api.getSelectedRows();
    if (selectedRows.length == 0) {  
      this.toastr.error("Error", "Please select a User from record");  
  }
  this.id= selectedRows[0].id;
    this.teacher_id = selectedRows[0].teacher_id;
    this.subject_id = selectedRows[0].subject_id;
    this.student_id = selectedRows[0].student_id;
    this.dialog.open(templateRef,{
      width:'45%',
      height:'50%'
    });
  }
  onTeacherOptionSelected(value){
    // alert(value);
  } 
}
