import { Component, OnInit } from '@angular/core';
import { RestoService } from '../resto.service';
import {Router} from '@angular/router'
@Component({
  selector: 'app-list-student',
  templateUrl: './list-student.component.html',
  styleUrls: ['./list-student.component.css']
})
export class ListStudentComponent implements OnInit {
  constructor(private router: Router, private resto:RestoService) { }
  collection : any = {};
  ngOnInit(): void {
    this.resto.getList().subscribe((result)=>{
      console.warn(result)
      this.collection = result
    })

  }
  deleteResto(item: any)
  {
    this.collection.splice(item-1,1)
    this.resto.deleteResto(item).subscribe((result)=>{
      console.warn("result",result)
    })
  }
  getToAdd() {
    this.router.navigate(['add'])
  }
  logout() {
    this.router.navigate(['login'])
  }
  
}
