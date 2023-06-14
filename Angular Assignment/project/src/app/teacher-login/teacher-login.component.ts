import { Component, OnInit } from '@angular/core';
import {RestoService} from '../resto.service';
import {Router} from '@angular/router'

@Component({
  selector: 'app-teacher-login',
  templateUrl: './teacher-login.component.html',
  styleUrls: ['./teacher-login.component.css']
})
export class TeacherLoginComponent implements OnInit {
  cacheData: any;
  constructor(private login: RestoService, private router: Router) { }
  loginTeacher(data: any) {
    this.login.getUser(data.email).subscribe((returnData) => {
      this.cacheData = returnData;
      if (this.cacheData.email === data.email && this.cacheData.password === data.password) {
        this.router.navigate(['list'])
      }
    });
  }
  ngOnInit(): void {
  }

}
