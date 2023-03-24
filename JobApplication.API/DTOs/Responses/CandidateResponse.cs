﻿using JobApplication.API.DTOs.Common;

namespace JobApplication.API.DTOs.Responses
{
    public class CandidateResponse : IdentityDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int YearsOfExperience { get; set; }

        public string Message { get; set; }
    }
}