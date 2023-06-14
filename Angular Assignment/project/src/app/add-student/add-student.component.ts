import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms'
import { RestoService } from '../resto.service'

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.css']
})
export class AddStudentComponent implements OnInit {
alert : boolean = false;
  addResto = new FormGroup({
    rollNo: new FormControl(''),
    name: new FormControl(''),
    dob: new FormControl(''),
    score: new FormControl('')
  })

  constructor(private resto : RestoService) { }

  ngOnInit(): void {
  }
  collectResto() 
  {
    this.resto.saveResto(this.addResto.value).subscribe((result) => {
      this.alert = true
      this.addResto.reset({})
    })
  }
  closeAlert()
  {
    this.alert = false
  }
}
