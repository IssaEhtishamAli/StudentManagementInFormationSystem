import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ColDef, ColumnApi, GridApi } from 'ag-grid-community';
import { ToastrService } from 'ngx-toastr';
import { Subjects } from 'src/app/core/classes/subjects/subjects';
import { SubjectsService } from 'src/app/core/services/subjects/subjects.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-subjects',
  templateUrl: './subjects.component.html',
  styleUrls: ['./subjects.component.scss']
})
export class SubjectsComponent implements OnInit {
  @ViewChild('Dialog',{static:true}) secondDialog:TemplateRef<any>;
  errors = "errorMessages";
  reGisterSubjectForm:FormGroup;
  public subjects: Subjects[];  
  public columnDefs: ColDef[];  
  private api: GridApi;  
  private columnApi: ColumnApi;
  public rowSelection;    
  public paginationPageSize;
  //-------Edit form fields --------//
  id:number=0;
  subject_name:string="";

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
        headerName: 'Subjects Name',  
        field: 'subject_name',  
        filter: true,  
        editable: true,  
        sortable: true  
    }
  ]}  
  constructor(
    private subjectService: SubjectsService, 
    private toastr: ToastrService,
    public dialog:MatDialog,
    public addDialog:MatDialog
    ) { 
      this.columnDefs = this.createColumnDefs();  
      this.paginationPageSize = 10;
      }
     
  ngOnInit(): void {
    this.getAllSubjects();
    this.formRegister();
  }


  onGridReady(params): void {  
    this.api = params.api;  
    this.columnApi = params.columnApi;  
    this.api.sizeColumnsToFit();  
}  
getAllSubjects(): void{
  this.subjectService.getSubject().subscribe((data:any)=>{
    if(data.statusCode===200){
      this.subjects=data.result;
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
delete(): void{  
  var selectedRows = this.api.getSelectedRows();  
  if (selectedRows.length == 0) {  
      this.toastr.error("Error", "Please select a subject for deletion");  
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
    this.subjectService.deleteSubject(selectedRows[0].id).subscribe((data:any) => {  
      if(data.statusCode===200){
        this.toastr.success(data.message);
        this.getAllSubjects();  
      }
      else if(data.statusCode=500){
          this.toastr.error("Internal server error");
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
//-------------------- Add subjects dialog ------------------------//
addSubjectDialog(templateRef: TemplateRef<any>): void{
  this.addDialog.open(templateRef,{
    width:'45%',
    height:'58%'
  });
}
formRegister(): void{
  this.reGisterSubjectForm= new FormGroup({
    subject_name:new FormControl('',[Validators.required,Validators.minLength(6)]),
  })
}
reGisterSubject(){
  this.subjectService.addSubject(this.reGisterSubjectForm.value).subscribe((data:any)=>{
    if(data.statusCode===200){
      this.toastr.success(data.message);
      this.addDialog.closeAll();
      this.getAllSubjects();  
    }
    else if(data.statusCode=500){
    this.toastr.error("Internal server error")
    }
  },
  (error:any)=>{
    this.toastr.error("Internal Server Error", "Please check Web Api is running?");
  });
}
//-------------------- Edit  subjects dialog ----------------------//
upDateSubjectRegister(form:any){
  let upDateFormFields={
    id:this.id,
    subject_name:form.subject_name
  };
  // console.log(form)
  var selectedRows = this.api.getSelectedRows(); 
  this.subjectService.upDateSubject(selectedRows[0].id,upDateFormFields).subscribe((data:any)=>{
    if(data.statusCode===200){
      this.toastr.success(data.message);
      this.dialog.closeAll();
      this.getAllSubjects();  
    }
    else if(data.statusCode=500){
      this.toastr.error("Internal server error")
    }
  },
  (error:any)=>{
    this.toastr.error("Internal Server Error", "Please check Web Api is running?");
  });
}
editDialog(templateRef: TemplateRef<any>): void{
  var selectedRows = this.api.getSelectedRows();
  if (selectedRows.length == 0) {  
    this.toastr.error("Please select a subjects from record");  
}
this.id= selectedRows[0].id;
  this.subject_name = selectedRows[0].subject_name;
  this.dialog.open(templateRef,{
    width: '45%',
    height:'50%'
  });
}
}
