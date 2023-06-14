import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddStudentComponent } from './add-student/add-student.component';
import { UpdateStudentComponent } from './update-student/update-student.component';
import { ListStudentComponent } from './list-student/list-student.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { HttpClientModule } from '@angular/common/http'
import { FormsModule , ReactiveFormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { StudentResultComponent } from './student-result/student-result.component';
import { TeacherLoginComponent } from './teacher-login/teacher-login.component';


@NgModule({
  declarations: [
    AppComponent,
    AddStudentComponent,
    UpdateStudentComponent,
    ListStudentComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    StudentResultComponent,
    TeacherLoginComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
