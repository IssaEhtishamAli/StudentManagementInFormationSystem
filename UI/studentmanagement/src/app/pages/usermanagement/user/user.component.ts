import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ColDef, GridApi, ColumnApi } from 'ag-grid-community';
import { ToastrService } from 'ngx-toastr';
import { Teachers } from 'src/app/core/classes/teachers/teachers';
import { Users } from 'src/app/core/classes/user/user';
import { Usertype } from 'src/app/core/classes/usertype/usertype';
import { UserService } from 'src/app/core/services/user/user.service';
import { UsertypeService } from 'src/app/core/services/usertype/usertype.service';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {
  @ViewChild('Dialog',{static:true}) secondDialog:TemplateRef<any>;
  errors = "errorMessages";
  reGisterUserForm:FormGroup;
  public users: Users[];  
  public usertype: Usertype[];  
  public columnDefs: ColDef[];  
  private api: GridApi;  
  private columnApi: ColumnApi;
  public rowSelection;  
  public paginationPageSize;
  //---------------- Edit user form fields variables ------------//
  id:number=0;
  user_name:string="";
  password:string="";
  email:string="";
  user_type:any;
  status:any="";
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
        headerName: 'User Name',  
        field: 'user_name',  
        filter: true,  
        editable: true,  
        sortable: true  
    },
    {  
      headerName: 'Password',  
      field: 'password',  
      filter: true,  
      editable: true,  
      sortable: true  },
    {  
      headerName: 'Email',  
      field: 'email',  
      filter: true,  
      editable: true,  
      sortable: true  },
     {  
        headerName: 'User Type',  
        field: 'user_type',  
        filter: true,  
        sortable: true,  
        editable: true,  
    },
  ]}  
  constructor(
    private userServcie:UserService,
    private usertypeService: UsertypeService, 
      private toastr: ToastrService,
      public dialog:MatDialog,
      public addDialog:MatDialog
    ) { 
      this.columnDefs = this.createColumnDefs();
      this.paginationPageSize = 10;
      }
  ngOnInit(): void {
    this.addUsersForm();
    this.getAllUsers();
    this.getAllUserType();
  }
  onGridReady(params): void {  
    this.api = params.api;  
    this.columnApi = params.columnApi;  
    this.api.sizeColumnsToFit();  
}  
  getAllUsers(): void{
    this.userServcie.getUser().subscribe((data:any)=>{
      if(data.statusCode===200){
        this.users=data.result;
      }
      else if(data.statusCode=500){
       this.toastr.error("Internal server error")
      }
    },
    // (error:any)=>{
    //   this.toastr.error("Internal Server Error", "Please check Web Api is running?");
    // }
    )
  }
  getAllUserType(): void{
    this.usertypeService.getUserType().subscribe((data:any)=>{
      if(data.statusCode===200){
        this.usertype=data.result;
      }
      else if(data.statusCode=500){
       this.toastr.error("Internal server error")
      }
    }
    )
  }
  addUsersDialog(templateRef: TemplateRef<any>): void{
    this.addDialog.open(templateRef,{
      width:'45%',
      height:'58%'
    });
  }
  addUsersForm(): void{
    this.reGisterUserForm= new FormGroup({
      user_name:new FormControl('',[Validators.required,Validators.minLength(6)]),
      password:new FormControl('',[Validators.required,Validators.minLength(6)]),
      email:new FormControl('',[Validators.required,Validators.minLength(6)]),
      user_type:new FormControl('',[Validators.required]),
    });
  }
  reGisterUsers(){
    this.userServcie.addUser(this.reGisterUserForm.value).subscribe((data:any)=>{
      if(data.statusCode===200){
        this.toastr.success('Record updated sucessfully');
        this.addDialog.closeAll();
        this.getAllUsers();  
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
  /*---------------------------------Edit user---------------------------------*/
  editUserRegister(form:any){  
    let upDateFormFields={
      id:this.id,
      user_name:form.user_name,
      password:form.password,
      email:form.email,
      user_type:form.user_type,
      status:this.status
    };
    var selectedRows = this.api.getSelectedRows(); 
    this.userServcie.upDateUser(selectedRows[0].id,upDateFormFields).subscribe((data:any)=>{
      console.log(data);
      if(data.statusCode==200){
        this.toastr.success(data.message);
        this.dialog.closeAll();
        this.getAllUsers();  
      }
      else if(data.statusCode=500){
        this.toastr.error("Internal server error")
      }
    },
    (error:any)=>{
      this.toastr.error("Internal Server Error", "Please check Web Api is running?");
    });
  }
  editUserDialog(templateRef: TemplateRef<any>): void{
    var selectedRows = this.api.getSelectedRows();
    if (selectedRows.length == 0) {  
      this.toastr.error("Error", "Please select a user from record");  
  };
  this.id= selectedRows[0].id;
    this.user_name = selectedRows[0].user_name;
    this.password = selectedRows[0].password;
    this.email = selectedRows[0].email;
    this.user_type = selectedRows[0].user_type;
    this.status=selectedRows[0].status;
    this.dialog.open(templateRef,{
      width:'45%',
      height:'58%'
    });
  }
/*---------------------------------Delete user---------------------------------*/
deleteUsers():void{
  debugger;
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
      this.userServcie.deleteUser(selectedRows[0].id).subscribe((data:any) => {   
        debugger;     
        if(data.statusCode===200){
          this.toastr.success(data.message);  
          this.getAllUsers();  
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
}
