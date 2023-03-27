import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CandidateResponse } from 'src/app/models/candidate.model';
import { JobApplyService } from 'src/app/services/job-apply.service';

@Component({
  selector: 'app-candidates-list',
  templateUrl: './candidates-list.component.html',
  styleUrls: ['./candidates-list.component.css']
})
export class CandidatesListComponent implements OnInit {

  candidates: CandidateResponse[] = [];

  id: number = 0;

  constructor(private jobApplyService: JobApplyService,
    private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];

    this.jobApplyService.getAllCandidatesPerJobPost(this.id)
    .subscribe({
      next: (response) => {
        this.candidates = response;
      }
    })
  }

}
