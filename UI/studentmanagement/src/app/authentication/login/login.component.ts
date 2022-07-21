import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import {FormControl,FormBuilder,NgForm,FormGroup, Validators} from '@angular/forms'
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../auth/auth.service';
import { UserService } from 'src/app/core/services/user/user.service';
import { UpdatePassword, UserLogin, Users } from 'src/app/core/classes/user/user';
import { MatDialog } from '@angular/material/dialog';
import { SidenavComponent } from 'src/app/shared/components/sidenav/sidenav.component';
import { Userprofile } from 'src/app/core/classes/userprofile/userprofile';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  @ViewChild('Dialog',{static:true}) Dialog:TemplateRef<any>;
  @ViewChild(SidenavComponent) sidenavComp:SidenavComponent;
  reg:string="/register";
  checked:boolean=false;
  indeterminate = false;
  labelPosition: 'before' | 'after' = 'after';
  loginForm:FormGroup;
  forgotForm:FormGroup;
  hide=true;
  loginhide=true;
  confirmpasswordhide=true;
  user:Users;
  email:any;
  password:any;
  id:any;
  loginDetail: UserLogin;
  userpasswordupdate:UpdatePassword;
  private formSubmitAttempt: boolean;
  private SubmitAttempt: boolean;
  
  userType:number=0;
  constructor(
    private router:Router,
    private toastr:ToastrService,
    private authService: AuthService,
    private userService:UserService,
    public dialog:MatDialog,
    ){ 
      
     }
  ngOnInit(): void {
    this.contactform();
    this.forgotPasswordForm();
    this.getLogin();
  }
  contactform(){
    this.loginForm= new FormGroup({
      email:new FormControl('',[Validators.required,Validators.email]),
      password:new FormControl('',[Validators.required])
    })
  }
  forgotPasswordForm(){
    this.forgotForm=new FormGroup({
      email:new FormControl('',[Validators.required,Validators.email]),
      password:new FormControl('',[Validators.required,Validators.minLength(8)]),
      confirmPassword:new FormControl('',[Validators.required,Validators.minLength(8)])
    })
  }
  isfieldinvalid(field: string) {
    return (
      (!this.loginForm.get(field).valid && this.loginForm.get(field).touched) ||
      (this.loginForm.get(field).untouched && this.formSubmitAttempt)
    );
  }
  isFieldInvalid(field:string){
    return(
      (!this.forgotForm.get(field).valid && this.forgotForm.get(field).touched ) ||
      (this.forgotForm.get(field).untouched && this.SubmitAttempt)
    )
  }
  getLogin(){
    this.userService.getUser().subscribe((data)=>{
      this.user=data.result;
    })
  } 
  login(form:any){
    this.loginDetail = new UserLogin();
    this.loginDetail.email=form.email;
    this.loginDetail.password =form.password;
    console.log("Checking Login details.....");
    // console.log(this.loginDetail);
    this.userService.userLoginValidate(this.loginDetail).subscribe((data)=>{
      //  console.log(data);
      if(data.statusCode==200){
        // console.log(data);
        localStorage.setItem('userData',JSON.stringify(data.result));
        this.toastr.success(data.message);
        this.router.navigate(['/management']);
        }
      else if(data.statusCode==409){
      // console.log(data);
      this.toastr.error("Please provide valid user name and password")
        return;
      }
      else{
        this.toastr.error("Internal Server error, Please contact system administrator")
      }
    })
  }
  register(a){
    this.router.navigate(['/register']);
  }
  changePassword(templateRef: TemplateRef<any>){
    this.dialog.open(templateRef,{
      width:'30%',
      height:'71'
    });
  }
submitForgotPassword(form:any){
this.userpasswordupdate=new UpdatePassword();
this.userpasswordupdate.email=form.email;
this.userpasswordupdate.password=form.password;
this.userpasswordupdate.password=form.confirmPassword;
if(this.userpasswordupdate.email !==form.email  || form.email=="" && this.userpasswordupdate.email==""){
  this.toastr.error("Please type correct email")
 return;
}
else if(form.password !== form.confirmPassword){
  this.toastr.error("Your password or confirmpassword is mismatch")
  return;
}
else if(form.password.isFieldInvalid=="" && form.confirmPassword.isFieldInvalid==""){
this.toastr.error("Please type a password")
return;
}
else {
    this.userService.updateUserPassword(this.userpasswordupdate).subscribe((data)=>{
    console.log(data);
    if(data.statusCode==200){
      this.toastr.success("Password updated sucessfully");
      this.dialog.closeAll();
    }
    else if(data.statusCode==409){
      this.toastr.error("Internal server error")
      return;
    }
    })
}
}
}
  