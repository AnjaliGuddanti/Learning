import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms'
import { ActivatedRoute } from '@angular/router'
import { RestoService } from '../resto.service'

@Component({
  selector: 'app-update-student',
  templateUrl: './update-student.component.html',
  styleUrls: ['./update-student.component.css']
})
export class UpdateStudentComponent implements OnInit {
  alert:boolean=false;
  editResto = new FormGroup({
    rollNo: new FormControl(''),
    name: new FormControl(''),
    dob: new FormControl(''),
    score: new FormControl('')
  })
  constructor(private router: ActivatedRoute, private resto: RestoService) { }

  ngOnInit(): void {
    console.warn(this.router.snapshot.params['id'])
    this.resto.getCurrentResto(this.router.snapshot.params['id']).
      subscribe((result: any) => {
        this.editResto = new FormGroup({
          rollNo: new FormControl(result['rollNo']),
          name: new FormControl(result['name']),
          dob: new FormControl(result['dob']),
          score: new FormControl(result['score'])
        })
      })
  }
  collection() 
  {
    console.warn(this.editResto.value)
    this.resto.updateResto(this.router.snapshot.params['id'], this.editResto.value).subscribe((result)=>{
      this.alert=true
    })
  }
  closeAlert()
  {
    this.alert=false
  }
}