import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EmploymentType } from 'src/app/enums/employment-type.enum';
import { SeniorityLevel } from 'src/app/enums/seniority-level.enum';
import { Industry } from 'src/app/models/industry.model';
import { CreateJobPostRequest, UpdateJobPostRequest } from 'src/app/models/job-post.model';
import { JobPostService } from 'src/app/services/job-post.service';

@Component({
  selector: 'app-update-jobpost',
  templateUrl: './update-jobpost.component.html',
  styleUrls: ['./update-jobpost.component.css']
})
export class UpdateJobpostComponent implements OnInit{

  id: number = 0;

  form: FormGroup;

  jobPost: UpdateJobPostRequest = {
    positionName: '',
    companyName: '',
    location: '',
    description: '',
    seniorityLevel: '',
    employmentType: '',
    industryId: 0,
    isRemote: false
  }

  seniorityLevels = SeniorityLevel;
  employmentTypes = EmploymentType;

  industries: Industry[] = [];

  constructor(public jobPostService: JobPostService,
    private route: ActivatedRoute,
    private router: Router) {
    this.form = new FormGroup({
      positionName: new FormControl('', [Validators.required]),
      companyName: new FormControl('', [Validators.required]),
      location: new FormControl('', [Validators.required]),
      description: new FormControl('', [Validators.required]),
      seniorityLevel: new FormControl('', [Validators.required]),
      employmentType: new FormControl('', [Validators.required]),
      industryId: new FormControl('', [Validators.required]),
      isRemote: new FormControl(false)
    })
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id']

    this.jobPostService.getIndustries()
    .subscribe({
      next: (response) => {
        this.industries = response;
      }
    })

    this.jobPostService.getJobPostDetails(this.id)
    .subscribe({
      next: (response) => {
        this.populateForm(response);
      }
    })
  }

  populateForm(jobPost: CreateJobPostRequest) {
    this.form.patchValue({
      positionName: jobPost.positionName,
      companyName: jobPost.companyName,
      location: jobPost.location,
      description: jobPost.description,
      seniorityLevel: jobPost.seniorityLevel,
      employmentType: jobPost.employmentType,
      industryId: jobPost.industryId,
      isRemote: jobPost.isRemote
    })
  }

  updateJobPost() {
    console.log(this.form.value)
    this.jobPostService.updateJobPost(this.id, this.form.value)
    .subscribe({
      next: () => {
        this.router.navigate(['/jobposts']);
      }
    })
  }

}
