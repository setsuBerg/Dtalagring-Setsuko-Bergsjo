using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNavigationMappings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CourseEventEntityId",
                table: "Teachings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TeacherEntityId",
                table: "Teachings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CourseEventEntityId",
                table: "CourseRegistrations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentEntityId",
                table: "CourseRegistrations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachings_CourseEventEntityId",
                table: "Teachings",
                column: "CourseEventEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachings_TeacherEntityId",
                table: "Teachings",
                column: "TeacherEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRegistrations_CourseEventEntityId",
                table: "CourseRegistrations",
                column: "CourseEventEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRegistrations_StudentEntityId",
                table: "CourseRegistrations",
                column: "StudentEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseRegistrations_Students_StudentEntityId",
                table: "CourseRegistrations",
                column: "StudentEntityId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseRegistrations_courseEvents_CourseEventEntityId",
                table: "CourseRegistrations",
                column: "CourseEventEntityId",
                principalTable: "courseEvents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachings_Teachers_TeacherEntityId",
                table: "Teachings",
                column: "TeacherEntityId",
                principalTable: "Teachers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachings_courseEvents_CourseEventEntityId",
                table: "Teachings",
                column: "CourseEventEntityId",
                principalTable: "courseEvents",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseRegistrations_Students_StudentEntityId",
                table: "CourseRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseRegistrations_courseEvents_CourseEventEntityId",
                table: "CourseRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachings_Teachers_TeacherEntityId",
                table: "Teachings");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachings_courseEvents_CourseEventEntityId",
                table: "Teachings");

            migrationBuilder.DropIndex(
                name: "IX_Teachings_CourseEventEntityId",
                table: "Teachings");

            migrationBuilder.DropIndex(
                name: "IX_Teachings_TeacherEntityId",
                table: "Teachings");

            migrationBuilder.DropIndex(
                name: "IX_CourseRegistrations_CourseEventEntityId",
                table: "CourseRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_CourseRegistrations_StudentEntityId",
                table: "CourseRegistrations");

            migrationBuilder.DropColumn(
                name: "CourseEventEntityId",
                table: "Teachings");

            migrationBuilder.DropColumn(
                name: "TeacherEntityId",
                table: "Teachings");

            migrationBuilder.DropColumn(
                name: "CourseEventEntityId",
                table: "CourseRegistrations");

            migrationBuilder.DropColumn(
                name: "StudentEntityId",
                table: "CourseRegistrations");
        }
    }
}
