import { Component, OnInit } from '@angular/core';
import { JobPost } from 'src/app/models/job-post.model';

@Component({
  selector: 'app-jobpost-details',
  templateUrl: './jobpost-details.component.html',
  styleUrls: ['./jobpost-details.component.css']
})
export class JobpostDetailsComponent implements OnInit{
  
  jobPost: JobPost = {
    id: 1,
    positionName: 'C# developer',
    description: 'Senior C# developer with more than 5 years of relevant experience.',
    companyName: 'XyzSoft',
    location: 'Ontario, Canada',
    isRemote: false,
    seniorityLevel: 'Senior',
    employmentType: 'Full Time',
    activeStatus: 'Active',
    industryId: 1,
    industry: {
      id: 1,
      name: 'Information and Technology'
    }
  }
  constructor() {}

  ngOnInit(): void {
  }

  deleteJobPost(id: number) {
    
  }

}
