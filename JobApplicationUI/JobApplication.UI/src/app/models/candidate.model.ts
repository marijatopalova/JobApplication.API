export interface CandidateResponse {
    id: number;
    firstName: string;
    lastName: string;
    email: string;
    phone: string;
    yearsOfExperience: number;
    message: string;
    dateOfApplication: Date;
}

export interface CreateCandidateRequest {
    firstName: string;
    lastName: string;
    email: string;
    phone: string;
    yearsOfExperience: number;
    message: string;
}
