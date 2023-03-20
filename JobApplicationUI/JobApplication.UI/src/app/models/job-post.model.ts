import { EmploymentType } from "../enums/employment-type.enum";
import { JobPostStatus } from "../enums/jobpost-status.enum";
import { SeniorityLevel } from "../enums/seniority-level.enum";
import { Industry } from "./industry.model";

export interface JobPostResponse {
    id: number;
    positionName: string;
    description: string;
    companyName: string;
    location: string;
    isRemote: boolean;
    seniorityLevel: string;
    employmentType: string;
    activeStatus: string;
    industryId: number;
    industryName: string;
}

export interface CreateJobPostRequest {
    positionName: string;
    description: string;
    companyName: string;
    location: string;
    isRemote: boolean;
    seniorityLevel: string;
    employmentType: string;
    industryId: number;
}

export interface UpdateJobPostRequest {
    positionName: string;
    description: string;
    companyName: string;
    location: string;
    isRemote: boolean;
    seniorityLevel: string;
    employmentType: string;
    industryId: number;
}

