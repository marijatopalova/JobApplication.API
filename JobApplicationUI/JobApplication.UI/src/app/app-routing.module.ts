import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddCandidateComponent } from './components/job-apply/add-candidate/add-candidate.component';
import { AddJobpostComponent } from './components/job-post/add-jobpost/add-jobpost.component';
import { JobpostDetailsComponent } from './components/job-post/jobpost-details/jobpost-details.component';
import { JobpostListComponent } from './components/job-post/jobpost-list/jobpost-list.component';
import { UpdateJobpostComponent } from './components/job-post/update-jobpost/update-jobpost.component';

const routes: Routes = [
  { path: '', component: JobpostListComponent },
  { path: 'jobposts', component: JobpostListComponent },
  { path: 'jobposts/details/:id', component: JobpostDetailsComponent },
  { path: 'jobposts/edit/:id', component: UpdateJobpostComponent },
  { path: 'jobposts/create', component: AddJobpostComponent },
  { path: 'jobapply/:id', component: AddCandidateComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
