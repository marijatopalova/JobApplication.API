import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { JobpostListComponent } from './components/job-post/jobpost-list/jobpost-list.component';
import { JobpostDetailsComponent } from './components/job-post/jobpost-details/jobpost-details.component';
import { AddJobpostComponent } from './components/job-post/add-jobpost/add-jobpost.component';
import { UpdateJobpostComponent } from './components/job-post/update-jobpost/update-jobpost.component';
import { KeysPipe } from './pipes/keys.pipe';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SeniorityLevelPipe } from './pipes/seniorityLevel.pipe';
import { EmploymentTypePipe } from './pipes/employmentType.pipe';
import { AddCandidateComponent } from './components/job-apply/add-candidate/add-candidate.component';

@NgModule({
  declarations: [
    AppComponent,
    JobpostListComponent,
    JobpostDetailsComponent,
    AddJobpostComponent,
    UpdateJobpostComponent,
    KeysPipe,
    SeniorityLevelPipe,
    EmploymentTypePipe,
    AddCandidateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
