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

