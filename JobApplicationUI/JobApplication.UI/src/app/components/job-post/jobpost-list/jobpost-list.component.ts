import { Component, OnInit } from '@angular/core';
import { EmploymentType } from 'src/app/enums/employment-type.enum';
import { JobPostStatus } from 'src/app/enums/jobpost-status.enum';
import { SeniorityLevel } from 'src/app/enums/seniority-level.enum';
import { JobPost } from 'src/app/models/job-post.model';
import { JobPostService } from 'src/app/services/job-post.service';

@Component({
  selector: 'app-jobpost-list',
  templateUrl: './jobpost-list.component.html',
  styleUrls: ['./jobpost-list.component.css']
})
export class JobpostListComponent implements OnInit {

  jobPosts: JobPost[] = [];

  constructor(public jobPostService: JobPostService) {}

  ngOnInit(): void {
    this.jobPostService.getJobPosts()
    .subscribe({
      next: (result) => {
        this.jobPosts = result;
      }
    })
  }

}
