import { Component, OnInit } from '@angular/core';
import {FormGroup} from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Cities } from 'src/app/core/classes/cities/cities';
import { Country } from 'src/app/core/classes/country/country';
import { Degrees } from 'src/app/core/classes/degrees/degrees';
import { Districts } from 'src/app/core/classes/district/districts';
import { Files } from 'src/app/core/classes/file/file';
import { Gender } from 'src/app/core/classes/gender/gender';
import { Guardian } from 'src/app/core/classes/guardian/guardian';
import { Language } from 'src/app/core/classes/language/language';
import { Qualification } from 'src/app/core/classes/qualification/qualification';
import { Sections } from 'src/app/core/classes/sections/sections';
import { Students } from 'src/app/core/classes/students/students';
import { Users } from 'src/app/core/classes/user/user';
import { Userprofile } from 'src/app/core/classes/userprofile/userprofile';
import { CitiesService } from 'src/app/core/services/cities/cities.service';
import { CountryService } from 'src/app/core/services/country/country.service';
import { DegreesService } from 'src/app/core/services/degrees/degrees.service';
import { DistrictService } from 'src/app/core/services/district/district.service';
import { FileService } from 'src/app/core/services/file/file.service';
import { GenderService } from 'src/app/core/services/gender/gender.service';
import { GuardianService } from 'src/app/core/services/guardian/guardian.service';
import { LanguageService } from 'src/app/core/services/language/language.service';
import { QualificationService } from 'src/app/core/services/qualification/qualification.service';
import { SectionsService } from 'src/app/core/services/sections/sections.service';
import { UserService } from 'src/app/core/services/user/user.service';
import { UserprofileService } from 'src/app/core/services/userprofile/userprofile.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-userprofile',
  templateUrl: './userprofile.component.html',
  styleUrls: ['./userprofile.component.scss']
})
export class UserprofileComponent implements OnInit {
  imageurl:string="/assets/images/student3_118124.png";
  isLinear = false;
  userProfileSec:boolean=true;
  editForm:boolean=false;
  studentForm=false;
  panelOpenState = false;
  step = 0;
  fileToUpload:File=null;
  firstFormGroup: FormGroup;
  studentRegisterForm:FormGroup;
  students:Students[];  
   degrees:Degrees[];
   sections:Sections[];
   users:Users[];
   cities:Cities[];
   country:Country[];
   distrcits:Districts[];
   gender:Gender[];
   userProfile:Userprofile[];
   guardians:Guardian[];
   languages:Language[];
   qualifications:Qualification[];
   filepath:Files[]
  id:number=0;
  user_id:number=0;
  first_name:string="";
  last_name:string="";
  contact_no:string="";
  date_of_birth;
  cnic_no:string="";
  zip_code:number=0;
  permanent_address:string="";
  resedential_address:string="";
  user_name:string="";  
  gender_id:number=0;
  degree_id:number=0;
  city_id:number=0;
  country_id:number=0;
  section_id:number=0;
  language_id:number=0;
  /*----------Qualification--------*/
  qafId:number=0;
  institute_name:string="";
  major_subjects:string="";
  total_marks:number=0;
  obtained_marks:number=0;
  /*---------------------------------*/
  /*------------ Guardian -----------*/
  guardian_id:number=0;
  father_name:string="";
  father_cnic_no:string="";
  father_contact_no:string="";
  father_occupation:string="";
  /*----------------------------------*/
  fileId:number=0;
  image_url:string="";
  files: any;
  user: any;
  userDetails: any;
  Id:number=0;
  guardian_user_id:number=0;
  //---------------------------------------//
 //---------------------------------------//

  constructor(
    private fileUploadService:FileService,
    private sectionsService:SectionsService,
    private degreeService:DegreesService,
    private citiesService:CitiesService,
    private distrcitService:DistrictService,
    private languageSevice:LanguageService,
    private countryService:CountryService,
    private genderService:GenderService,
    private userService:UserService,
    private userProflieService:UserprofileService,
    private userguardianService:GuardianService,
    private userqualificationService:QualificationService,
    private toastr: ToastrService,
    ) {
     
      }
  ngOnInit(): void {
    this.getGender();
    this.getCountry();
    this.getDegree();
    this.getSection();
    this.getCity();
    this.getDistrict();
    this.getLanguage();
    const data=JSON.parse(localStorage.getItem('userData'));
    console.log("-------Assigning user_id value-------");
    this.user_id=data.id;
    if(this.user_id){
      this.userProflieService.getUserProfileById(this.user_id).subscribe((res:any)=>{
        this.userProfile=res.result;
        this.id =this.userProfile[0].id;
        this.user_name=this.userProfile[0].user_name;
        this.gender_id =this.userProfile[0].gender_id;
        this.degree_id =this.userProfile[0].degree_id;
        this.city_id =this.userProfile[0].city_id;
        this.country_id =this.userProfile[0].country_id;
        this.section_id =this.userProfile[0].section_id;
        this.user_id =this.userProfile[0].user_id;
        this.zip_code = this.userProfile[0].zip_code;
        this.language_id=this.userProfile[0].language_id,
        this.first_name=this.userProfile[0].first_name,
        this.last_name=this.userProfile[0].last_name,
        this.cnic_no=this.userProfile[0].cnic_no,
        this.contact_no=this.userProfile[0].contact_no,
        this.date_of_birth=this.userProfile[0].date_of_birth,
        this.resedential_address=this.userProfile[0].resedential_address,
        this.permanent_address=this.userProfile[0].permanent_address
        
      })
    }
    if(this.user_id){
      this.userguardianService.getGuardiansDetailsById(this.user_id).subscribe((res:any)=>{
       this.guardians=res.result;
       this.Id=res.result.id;
       this.guardian_user_id=res.result.user_id;
       this.father_name=res.result.father_name;
       this.father_contact_no=res.result.father_contact_no;
       this.father_cnic_no=res.result.father_cnic_no;
       this.father_occupation=res.result.father_occupation;
      })
    }
    if(this.user_id){
    this.userqualificationService.getQualificationsDetailsById(this.user_id).subscribe((res:any)=>{
      this.qualifications=res.result;
      console.log(this.qualifications);
      this.qafId=res.result.id;
      this.user_id=res.result.user_id;
      this.institute_name=res.result.institute_name;
      this.major_subjects=res.result.major_subjects;
      this.total_marks=res.result.total_marks;
      this.obtained_marks=res.result.obtained_marks;
    })
    }
    if(this.user_id){
      this.fileUploadService.getFileById(this.user_id).subscribe((res:any)=>{
      this.filepath=res.result;
      this.fileId=res.result.fileId;
      this.user_id=res.result.user_id;
      this.imageurl=res.result.image_url;
      })
    }
    else{
      this.getUserProfile();
    }
  }
  onSelectFile(files: FileList) {
    if (files.length === 0)
      return;  
    this.fileToUpload = files.item(0);
    const fileReader: FileReader = new FileReader();
    fileReader.readAsDataURL(this.fileToUpload);
    fileReader.onload = (event: any) => {
      this.imageurl = event.target.result;
    };
    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);  
   this.fileUploadService.addFile(formData).subscribe((res:any)=>{
    this.imageurl=res.path;
    alert(this.image_url)
    console.log(this.imageurl);
    let updateImageFiles={
      fileId:this.fileId,
      user_id:this.user_id,
      image_url:this.image_url
    };
    this.fileUploadService.addFiles(updateImageFiles).subscribe((res:any)=>{
      Swal.fire({
        position:'center',
        icon:'success',
        title:'image uploaded sucessfully',
        showConfirmButton:false,
        timer:1500,
       });
    })
   })
  }
  delete() {
    this.imageurl = null;
  }
  setStep(index: number) {
    this.step = index;
  }
  getUser(){
    this.userService.getUser().subscribe((data:any)=>{
      this.users=data.result;
  })
  }
  
  getUserProfile(){
    this.userProflieService.getUserProfile().subscribe((data)=>{
      this.userProfile=data.result;
      // this.imageurl=data.result.coverimage_url;
      // console.log("//------------Get Alluser profile-----------//")
      // console.log(this.userProfile)
      
    })
  } 
  getGender(){
    this.genderService.getGender().subscribe((data:any)=>{
      this.gender=data.result;
    })
  }
  getDegree(){
    this.degreeService.getDegrees().subscribe((data:any)=>{
      this.degrees=data.result;
    })
  }
  getSection(){
    this.sectionsService.getSections().subscribe((data:any)=>{
      this.sections=data.result;
    })
  }
  getCountry(){
    this.countryService.getCountry().subscribe((data:any)=>{
      this.country=data.result;
    })
  }
  getDistrict(){
   this.distrcitService.getAllDistricts().subscribe((data:any)=>{
    this.distrcits=data.result;
   })
  }
  getCity(){
    this.citiesService.getCities().subscribe((data:any)=>{
      this.cities=data.result;
    })
  }
  getLanguage(){
    this.languageSevice.getAllLanguages().subscribe((data:any)=>{
      this.languages=data.result;
    })
  }
 
  editUserProfile(form:any){
    debugger;
    let upDateFormFields={
      id:this.id,
      user_id:this.user_id,
      gender_id:form.gender_id,
      degree_id:form.degree_id,
      section_id:form.section_id,
      country_id:form.country_id,
      city_id:form.city_id,
      language_id:form.language_id,
      first_name:form.first_name,
      last_name:form.last_name,
      cnic_no:form.cnic_no,
      permanent_address:form.permanent_address,
      resedential_address:form.resedential_address,
      zip_code:form.zip_code,
      contact_no:form.contact_no,
      date_of_birth:form.date_of_birth,
    };
      this.userProflieService.updateUserProfile(upDateFormFields).subscribe((data:any)=>{
        if(data.statusCode==200){
          this.toastr.success('Record updated sucessfully');
          this.getUserProfile();
        }
        else if(data.statusCode==500){
          this.toastr.error("Internal server error")
        }
      },
      (error:any)=>{
        this.toastr.error("Internal Server Error");
      },
      );
    }
    editGuardian(form:any){
      debugger;
      let guardianFields={
        Id:this.Id,
        user_id:this.user_id,
        father_name:form.father_name,
        father_cnic_no:form.father_cnic_no,
        father_contact_no:form.father_contact_no,
        father_occupation:form.father_occupation,
      }
      this.userguardianService.updateGuardian(guardianFields).subscribe((data:any)=>{
        if(data.statusCode==200){
          this.toastr.success('Record updated sucessfully');
          this.getUserProfile();
        }
        else if(data.statusCode==500){
          this.toastr.error("Internal server error")
        }
      },
      (error:any)=>{
        this.toastr.error("Internal Server Error");
      },
      );
    }
    editQualification(form:any){
      debugger;
      let qualificationFields={
        qafId:this.qafId,
        user_id:this.user_id,
        institute_name:form.institute_name,
        major_subjects:form.major_subjects,
        total_marks:form.total_marks,
        obtained_marks:form.obtained_marks,
      };
      this.userqualificationService.updateQualification(qualificationFields).subscribe((data:any)=>{
        debugger;
        if(data.statusCode==200){
          this.toastr.success('Record updated sucessfully');
          this.getUserProfile();
        }
        else if(data.statusCode==500){
          this.toastr.error("Internal server error")
        }
      },
      (error:any)=>{
        this.toastr.error("Internal Server Error");
      },
      );
    }
}
