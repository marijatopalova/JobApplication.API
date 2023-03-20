﻿namespace JobApplication.API.DTOs.Responses
{
    public class JobPostResponse
    {
        public int Id { get; set; }
        public string PositionName { get; set; }

        public string Description { get; set; }

        public string CompanyName { get; set; }

        public string Location { get; set; }

        public bool IsRemote { get; set; }

        public string SeniorityLevel { get; set; }

        public string EmploymentType { get; set; }

        public string ActiveStatus { get; set; }

        public int IndustryId { get; set; }

        public string IndustryName { get; set; }
    }
}
