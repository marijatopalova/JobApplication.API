import { Component, OnInit } from '@angular/core';
import { JobPostResponse } from 'src/app/models/job-post.model';
import { JobApplyService } from 'src/app/services/job-apply.service';
import { JobPostService } from 'src/app/services/job-post.service';

@Component({
  selector: 'app-jobpost-list',
  templateUrl: './jobpost-list.component.html',
  styleUrls: ['./jobpost-list.component.css']
})
export class JobpostListComponent implements OnInit {

  id: number = 0;

  jobPosts: JobPostResponse[] = [];

  candidatesNumber: number = 0;

  constructor(public jobPostService: JobPostService,
    public jobApplyService: JobApplyService) {}

  ngOnInit(): void {
    this.jobPostService.getJobPosts()
    .subscribe({
      next: (result) => {
        this.jobPosts = result;
      }
    });

    this.jobPosts.forEach(x => this.jobApplyService.getAllCandidatesPerJobPost(x.id)
    .subscribe({
      next: (result) => {
        this.candidatesNumber = result.length;
      }
    }))
  }

}
