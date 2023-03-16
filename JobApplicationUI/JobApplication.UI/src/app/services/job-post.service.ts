import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Industry } from '../models/industry.model';
import { JobPost } from '../models/job-post.model';

@Injectable({
  providedIn: 'root'
})
export class JobPostService {

  baseUrl = 'https://localhost:7072/api/jobPosts';

  constructor(private http: HttpClient) { }

  getIndustries(): Observable<Industry[]> {
    return this.http.get<Industry[]>(this.baseUrl + '/industries');
  }

  getJobPosts(): Observable<JobPost[]> {
    return this.http.get<JobPost[]>(this.baseUrl);
  }

  createJobPost(jobPost: JobPost): Observable<JobPost> {
    return this.http.post<JobPost>(this.baseUrl, jobPost);
  }

  updateJobPost(id: number, jobPost: JobPost): Observable<JobPost> {
    return this.http.put<JobPost>(this.baseUrl + '/' + id, jobPost);
  }

  getJobPostDetails(id: number): Observable<JobPost> {
    return this.http.get<JobPost>(this.baseUrl + '/' + id);
  }

  deleteJobPost(id: number) {
    return this.http.delete(this.baseUrl + '/' + id);
  }

}
