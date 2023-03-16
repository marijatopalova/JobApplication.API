import { Component, OnInit } from '@angular/core';
import { EmploymentType } from 'src/app/enums/employment-type.enum';
import { JobPostStatus } from 'src/app/enums/jobpost-status.enum';
import { SeniorityLevel } from 'src/app/enums/seniority-level.enum';
import { JobPost } from 'src/app/models/job-post.model';

@Component({
  selector: 'app-jobpost-list',
  templateUrl: './jobpost-list.component.html',
  styleUrls: ['./jobpost-list.component.css']
})
export class JobpostListComponent implements OnInit {

  jobPosts: JobPost[] = [
    {
      "id": 1,
      "positionName": "JavaScript Developer",
      "description": "Senior JS developer 5+ years of experience.",
      "companyName": "EndSoft",
      "location": "Ontario, Canada",
      "isRemote": true,
      "seniorityLevel": SeniorityLevel[SeniorityLevel.Associate],
      "employmentType": EmploymentType[EmploymentType.Contract],
      "activeStatus": JobPostStatus[JobPostStatus.Active],
      "industryId": 1,
      "industry": {
        "id": 1,
        "name": "Information Technology and Services"
      }
    },{
      "id": 2,
      "positionName": ".NET Software Developer",
      "description": "Junior developer 1+ years of experience.",
      "companyName": "EndSoft",
      "location": "Ontario, Canada",
      "isRemote": true,
      "seniorityLevel": SeniorityLevel[SeniorityLevel.Senior],
      "employmentType": EmploymentType[EmploymentType.FullTime],
      "activeStatus": JobPostStatus[JobPostStatus.Closed],
      "industryId": 1,
      "industry": {
        "id": 1,
        "name": "Information Technology and Services"
      }
    },
    {
      "id": 3,
      "positionName": ".NET Software Developer",
      "description": "Middeveloper 3+ years of experience.",
      "companyName": "EndSoft",
      "location": "Ontario, Canada",
      "isRemote": true,
      "seniorityLevel": SeniorityLevel[SeniorityLevel.Intermediate],
      "employmentType": EmploymentType[EmploymentType.FullTime],
      "activeStatus": JobPostStatus[JobPostStatus.Active],
      "industryId": 1,
      "industry": {
        "id": 1,
        "name": "Information Technology and Services"
      }
    },
    {
      "id": 4,
      "positionName": ".NET Software Developer",
      "description": "Senior 5+ years of experience.",
      "companyName": "EndSoft",
      "location": "Ontario, Canada",
      "isRemote": true,
      "seniorityLevel": SeniorityLevel[SeniorityLevel.EntryLevel],
      "employmentType": EmploymentType[EmploymentType.PartTime],
      "activeStatus": JobPostStatus[JobPostStatus.Active],
      "industryId": 1,
      "industry": {
        "id": 1,
        "name": "Information Technology and Services"
      }
    }
  ];

  constructor() {}

  ngOnInit(): void {
  }

}
