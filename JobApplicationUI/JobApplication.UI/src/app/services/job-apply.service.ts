import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CandidateResponse, CreateCandidateRequest } from '../models/candidate.model';

@Injectable({
  providedIn: 'root'
})
export class JobApplyService {

  baseUrl = 'https://localhost:7072/api/jobapply';

  constructor(private http: HttpClient) { }

  getAllCandidatesPerJobPost(id: number): Observable<CandidateResponse[]> {
    return this.http.get<CandidateResponse[]>(this.baseUrl + '/' + id);
  }

  addJobApplicant(id: number, candidate: CreateCandidateRequest) {
    return this.http.post(this.baseUrl + '/' + id, candidate);
  }
}
