import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RestoService } from '../resto.service'
import {FormsModule} from '@angular/forms'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  constructor(private router: Router, private service: RestoService) { }


  studentSearch(data: any) {
    this.service.searchRollNumber = data.rollNumber;
    this.router.navigate(['result']);
  }

  ngOnInit(): void {
  }

}
