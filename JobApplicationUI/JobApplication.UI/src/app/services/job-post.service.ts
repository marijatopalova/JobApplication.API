import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Industry } from '../models/industry.model';
import { CreateJobPostRequest, JobPostResponse, UpdateJobPostRequest } from '../models/job-post.model';

@Injectable({
  providedIn: 'root'
})
export class JobPostService {

  baseUrl = 'https://localhost:7072/api/jobposts';

  constructor(private http: HttpClient) { }

  getIndustries(): Observable<Industry[]> {
    return this.http.get<Industry[]>(this.baseUrl + '/industries');
  }

  getJobPosts(): Observable<JobPostResponse[]> {
    return this.http.get<JobPostResponse[]>(this.baseUrl);
  }

  createJobPost(jobPost: CreateJobPostRequest): Observable<JobPostResponse> {
    return this.http.post<JobPostResponse>(this.baseUrl, jobPost);
  }

  updateJobPost(id: number, jobPost: UpdateJobPostRequest): Observable<JobPostResponse> {
    return this.http.put<JobPostResponse>(this.baseUrl + '/' + id, jobPost);
  }

  getJobPostDetails(id: number): Observable<JobPostResponse> {
    return this.http.get<JobPostResponse>(this.baseUrl + '/' + id);
  }

  deleteJobPost(id: number) {
    return this.http.delete(this.baseUrl + '/' + id);
  }

}
