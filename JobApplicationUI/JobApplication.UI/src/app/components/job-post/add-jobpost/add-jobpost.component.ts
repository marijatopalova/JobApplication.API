import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { defaultIfEmpty } from 'rxjs';
import { EmploymentType } from 'src/app/enums/employment-type.enum';
import { SeniorityLevel } from 'src/app/enums/seniority-level.enum';
import { Industry } from 'src/app/models/industry.model';
import { CreateJobPostRequest } from 'src/app/models/job-post.model';
import { JobPostService } from 'src/app/services/job-post.service';

@Component({
  selector: 'app-add-jobpost',
  templateUrl: './add-jobpost.component.html',
  styleUrls: ['./add-jobpost.component.css']
})
export class AddJobpostComponent implements OnInit {

  jobPost!: CreateJobPostRequest;

  form: FormGroup;

  seniorityLevels = SeniorityLevel;
  employmentTypes = EmploymentType;

  industries: Industry[] = [];

  constructor(public jobPostService: JobPostService,
    private router: Router) {
    this.form = new FormGroup({
      positionName: new FormControl('', [Validators.required]),
      description: new FormControl('', [Validators.required]),
      companyName: new FormControl('', [Validators.required]),
      location: new FormControl('', [Validators.required]),
      isRemote: new FormControl(false),
      seniorityLevel: new FormControl('', [Validators.required]),
      employmentType: new FormControl('', [Validators.required]),
      industryId: new FormControl('', [Validators.required]),
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

  submit() {
    console.log(this.form.value);
    this.jobPostService.createJobPost(this.form.value)
    .subscribe({
      next: () => {
        this.router.navigate(['/jobposts'])
      }
    })
  }

}
