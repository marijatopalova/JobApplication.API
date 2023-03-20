import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { JobPostResponse } from 'src/app/models/job-post.model';
import { JobPostService } from 'src/app/services/job-post.service';

@Component({
  selector: 'app-jobpost-details',
  templateUrl: './jobpost-details.component.html',
  styleUrls: ['./jobpost-details.component.css']
})
export class JobpostDetailsComponent implements OnInit{
  
  jobPost: JobPostResponse = {
    id: 0,
    positionName: '',
    companyName: '',
    location: '',
    description: '',
    seniorityLevel: '',
    employmentType: '',
    industryId: 0,
    industryName: '',
    activeStatus: '',
    isRemote: false
  }

  jobPostId: number = 0;

  constructor(public jobPostService: JobPostService, 
    private route: ActivatedRoute,
    private router: Router) {
    }

  ngOnInit(): void {

    this.jobPostId = this.route.snapshot.params['id'];

    this.jobPostService.getJobPostDetails(this.jobPostId)
    .subscribe({
      next: (result) => {
        this.jobPost = result;
      }
    })
  }

  deleteJobPost(id: number) {
    this.jobPostService.deleteJobPost(id)
    .subscribe({
      next: () => {
        if(confirm("Are you sure you want to delete this post?")) {
          this.router.navigate(['jobposts']);
        }
      },
      error: (error) => {
        console.log(error)
      }
    })
  }

}
