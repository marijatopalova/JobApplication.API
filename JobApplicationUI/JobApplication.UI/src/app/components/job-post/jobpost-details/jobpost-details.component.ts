import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { JobPost } from 'src/app/models/job-post.model';
import { JobPostService } from 'src/app/services/job-post.service';

@Component({
  selector: 'app-jobpost-details',
  templateUrl: './jobpost-details.component.html',
  styleUrls: ['./jobpost-details.component.css']
})
export class JobpostDetailsComponent implements OnInit{
  
  jobPost: JobPost = {
    id: 0,
    positionName: '',
    description: '',
    companyName: '',
    location: '',
    isRemote: false,
    seniorityLevel: '',
    employmentType: '',
    activeStatus: '',
    industryName: ''
  }

  jobPostId: number = 0;

  constructor(public jobPostService: JobPostService, 
    private route: ActivatedRoute) {
    }

  ngOnInit(): void {

    this.jobPostId = this.route.snapshot.params['id'];

    this.jobPostService.getJobPostDetails(this.jobPostId)
    .subscribe({
      next: (result) => {
        this.jobPost = <JobPost>result;
      }
    })
  }

  deleteJobPost(id: number) {
    
  }

}
