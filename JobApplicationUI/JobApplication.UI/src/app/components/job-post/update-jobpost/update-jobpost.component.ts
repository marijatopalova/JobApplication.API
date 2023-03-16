import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { EmploymentType } from 'src/app/enums/employment-type.enum';
import { SeniorityLevel } from 'src/app/enums/seniority-level.enum';
import { Industry } from 'src/app/models/industry.model';

@Component({
  selector: 'app-update-jobpost',
  templateUrl: './update-jobpost.component.html',
  styleUrls: ['./update-jobpost.component.css']
})
export class UpdateJobpostComponent implements OnInit{

  form: FormGroup;

  seniorityLevels = SeniorityLevel;
  employmentTypes = EmploymentType;

  industries: Industry[] = [
    { id: 1, name: 'Information Technology'},
    { id: 2, name: 'Digital Marketing'},
    { id: 3, name: 'Human Resources'},
  ]

  constructor() {
    this.form = new FormGroup({
      positionName: new FormControl('', [Validators.required]),
      companyName: new FormControl('', [Validators.required]),
      location: new FormControl('', [Validators.required]),
      description: new FormControl('', [Validators.required]),
      seniorityLevel: new FormControl('', [Validators.required]),
      employmentType: new FormControl('', [Validators.required]),
      industry: new FormControl('', [Validators.required]),
      isRemote: new FormControl('')
    })
  }

  ngOnInit(): void {
  }

}
