import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { CreateCandidateRequest } from 'src/app/models/candidate.model';
import { JobPostResponse } from 'src/app/models/job-post.model';
import { JobApplyService } from 'src/app/services/job-apply.service';
import { JobPostService } from 'src/app/services/job-post.service';

@Component({
  selector: 'app-add-candidate',
  templateUrl: './add-candidate.component.html',
  styleUrls: ['./add-candidate.component.css']
})
export class AddCandidateComponent implements OnInit {

  form: FormGroup;

  id: number = 0;

  jobPostName: string = '';

  constructor(private jobApplyService: JobApplyService,
    private jobPostService: JobPostService,
    private route: ActivatedRoute,
    private router: Router) {
    this.form = new FormGroup({
      firstName: new FormControl('', [Validators.required]),
      lastName: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required]),
      phone: new FormControl('', [Validators.required]),
      yearsOfExperience: new FormControl('', [Validators.required]),
      message: new FormControl(''),
    })
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];

    this.jobPostService.getJobPostDetails(this.id)
    .subscribe({
      next: (result) => {
        this.jobPostName = result.positionName;
      }
    })
  }

  submit() {
    console.log(this.form.value);
    this.jobApplyService.addJobApplicant(this.id, this.form.value)
    .subscribe({
      next: () => {
        this.router.navigate(['/jobposts']);
      }
    });
  }

}
