import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { EmploymentType } from 'src/app/enums/employment-type.enum';
import { SeniorityLevel } from 'src/app/enums/seniority-level.enum';
import { Industry } from 'src/app/models/industry.model';
import { JobPostService } from 'src/app/services/job-post.service';

@Component({
  selector: 'app-add-jobpost',
  templateUrl: './add-jobpost.component.html',
  styleUrls: ['./add-jobpost.component.css']
})
export class AddJobpostComponent implements OnInit {

  form: FormGroup;

  seniorityLevels = SeniorityLevel;
  employmentTypes = EmploymentType;

  industries: Industry[] = [];

  constructor(public jobPostService: JobPostService) {
    this.form = new FormGroup({
      positionName: new FormControl('', [Validators.required]),
      companyName: new FormControl('', [Validators.required]),
      location: new FormControl('', [Validators.required]),
      description: new FormControl('', [Validators.required]),
      seniorityLevel: new FormControl('', [Validators.required]),
      employmentType: new FormControl('', [Validators.required]),
      industry: new FormControl('', [Validators.required]),
      isRemote: new FormControl(''),
    });
  }

  ngOnInit(): void {
    this.jobPostService.getIndustries()
    .subscribe({
      next: (result) => {
        this.industries = result;
      }
    })
  }

}
