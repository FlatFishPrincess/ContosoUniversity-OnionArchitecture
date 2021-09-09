using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class RenameIDforAllEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstructor_Courses_CoursesId",
                table: "CourseInstructor");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstructor_Instructors_InstructorsId",
                table: "CourseInstructor");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeAssignments_Instructors_InstructorId",
                table: "OfficeAssignments");

            migrationBuilder.DropIndex(
                name: "IX_OfficeAssignments_InstructorId",
                table: "OfficeAssignments");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Students",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "InstructorId",
                table: "OfficeAssignments",
                newName: "InstructorID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OfficeAssignments",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Instructors",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Enrollments",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Departments",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Courses",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "InstructorsId",
                table: "CourseInstructor",
                newName: "InstructorsID");

            migrationBuilder.RenameColumn(
                name: "CoursesId",
                table: "CourseInstructor",
                newName: "CoursesID");

            migrationBuilder.RenameIndex(
                name: "IX_CourseInstructor_InstructorsId",
                table: "CourseInstructor",
                newName: "IX_CourseInstructor_InstructorsID");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeAssignments_InstructorID",
                table: "OfficeAssignments",
                column: "InstructorID",
                unique: true,
                filter: "[InstructorID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstructor_Courses_CoursesID",
                table: "CourseInstructor",
                column: "CoursesID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstructor_Instructors_InstructorsID",
                table: "CourseInstructor",
                column: "InstructorsID",
                principalTable: "Instructors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeAssignments_Instructors_InstructorID",
                table: "OfficeAssignments",
                column: "InstructorID",
                principalTable: "Instructors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstructor_Courses_CoursesID",
                table: "CourseInstructor");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstructor_Instructors_InstructorsID",
                table: "CourseInstructor");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeAssignments_Instructors_InstructorID",
                table: "OfficeAssignments");

            migrationBuilder.DropIndex(
                name: "IX_OfficeAssignments_InstructorID",
                table: "OfficeAssignments");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Students",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "InstructorID",
                table: "OfficeAssignments",
                newName: "InstructorId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "OfficeAssignments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Instructors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Enrollments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Departments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Courses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "InstructorsID",
                table: "CourseInstructor",
                newName: "InstructorsId");

            migrationBuilder.RenameColumn(
                name: "CoursesID",
                table: "CourseInstructor",
                newName: "CoursesId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseInstructor_InstructorsID",
                table: "CourseInstructor",
                newName: "IX_CourseInstructor_InstructorsId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeAssignments_InstructorId",
                table: "OfficeAssignments",
                column: "InstructorId",
                unique: true,
                filter: "[InstructorId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstructor_Courses_CoursesId",
                table: "CourseInstructor",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstructor_Instructors_InstructorsId",
                table: "CourseInstructor",
                column: "InstructorsId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeAssignments_Instructors_InstructorId",
                table: "OfficeAssignments",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
