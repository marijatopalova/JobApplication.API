import { Industry } from "./industry.model";

export interface JobPost {
    id: number;
    positionName: string;
    description: string;
    companyName: string;
    location: string;
    isRemote: boolean;
    seniorityLevel: string;
    employmentType: string;
    activeStatus: string;
    industryName: string;
}
