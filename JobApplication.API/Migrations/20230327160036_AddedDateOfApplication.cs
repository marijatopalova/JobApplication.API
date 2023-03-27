﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobApplication.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedDateOfApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfApplication",
                table: "Candidates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfApplication",
                table: "Candidates");
        }
    }
}
