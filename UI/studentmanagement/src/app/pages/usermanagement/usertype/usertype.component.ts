import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ColDef, GridApi, ColumnApi } from 'ag-grid-community';
import { ToastrService } from 'ngx-toastr';
import { Usertype } from 'src/app/core/classes/usertype/usertype';
import { UsertypeService } from 'src/app/core/services/usertype/usertype.service';

@Component({
  selector: 'app-usertype',
  templateUrl: './usertype.component.html',
  styleUrls: ['./usertype.component.scss']
})
export class UsertypeComponent implements OnInit {
  @ViewChild('Dialog',{static:true}) secondDialog:TemplateRef<any>;
  errors = "errorMessages";
  reGisterUserTypeForm:FormGroup;
  public usertype: Usertype[];  
  public columnDefs: ColDef[];  
  private api: GridApi;  
  private columnApi: ColumnApi;
  public rowSelection;  
  public paginationPageSize;
  //---------------- Edit teacher form fields variables ------------//
  id:number=0;
  type:string="";
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
        headerName: 'User Type',  
        field: 'type',  
        filter: true,  
        editable: true,  
        sortable: true  
    }
  ]}  
  constructor(
    private usertypeService: UsertypeService, 
    private toastr: ToastrService,
    public dialog:MatDialog,
    public addDialog:MatDialog
    ) { 
      this.columnDefs = this.createColumnDefs();
      this.paginationPageSize = 10;
      }
  ngOnInit(): void {
    this.getAllUserType();
    this.addUserTypeForm();
  }
  onGridReady(params): void {  
    this.api = params.api;  
    this.columnApi = params.columnApi;  
    this.api.sizeColumnsToFit();  
}  
getAllUserType(): void{
  this.usertypeService.getUserType().subscribe((data:any)=>{
    if(data.statusCode===200){
      this.usertype=data.result;
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




deleteUserType(): void{  
  var selectedRows = this.api.getSelectedRows();  
  if (selectedRows.length == 0) {  
      this.toastr.error("Error", "Please select a usertype for deletion");  
      return;  
  }
  if(confirm("Are you sure do you want to delete the usertype?")){
    this.usertypeService.deleteUserType(selectedRows[0].id).subscribe((data:any) => {
      console.log(data);
      if(data.statusCode===200){
        this.toastr.success(data.message);
        this.getAllUserType();  
      }
      else if(data.statusCode==500){
        this.toastr.error("Internal server error")
      }  
  },
  (error:any)=>{
    this.toastr.error("Internal Server Error", "Please check Web Api is running?");
  }
  );  

  }  
}  

//------------------- Add teacher dialog ---------------//


addUserTypeDialog(templateRef: TemplateRef<any>): void{
  this.addDialog.open(templateRef,{
    width:'45%',
    height:'58%'
  });
}

addUserTypeForm(): void{
  this.reGisterUserTypeForm= new FormGroup({
    type:new FormControl('',[Validators.required]),
  })
}
reGisterUserType(){
  this.usertypeService.addUserType(this.reGisterUserTypeForm.value).subscribe((data:any)=>{
    if(data.statusCode===200){
      this.toastr.success('Record updated sucessfully');
      this.addDialog.closeAll();
      this.getAllUserType();  
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


//---------------------Edit user dialog -----------------//
editUserTypeRegister(form:any){
  let upDateFormField={
    id:this.id,
    type:this.type

  };
  var selectedRows = this.api.getSelectedRows(); 
  this.usertypeService.upDateUserType(selectedRows[0].id,upDateFormField).subscribe((data:any)=>{
    if(data.statusCode===200){
      this.toastr.success(data.message);
      this.dialog.closeAll();
      this.getAllUserType();  
    }
    else if(data.statusCode=500){
      this.toastr.error("Internal server error")
    }

  },
  (error:any)=>{
    this.toastr.error("Internal Server Error", "Please check Web Api is running?");
  });

}


editUserTypeDialog(templateRef: TemplateRef<any>): void{
    
  var selectedRows = this.api.getSelectedRows();
  if (selectedRows.length == 0) {  
    this.toastr.error("Error", "Please select a teacher from record");  
};
this.id= selectedRows[0].id;
  this.type = selectedRows[0].type;
  this.dialog.open(templateRef,{
    width:'45%',
    height:'58%'
  });
}

}
