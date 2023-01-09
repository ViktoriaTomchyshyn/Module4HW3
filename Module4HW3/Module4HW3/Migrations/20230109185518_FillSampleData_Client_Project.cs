using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Module4HW3.Migrations
{
    /// <inheritdoc />
    public partial class FillSampleDataClientProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "vktrtmchshn@gmail.com", "Viktoriia", "Tomchyshyn", "+380978945678" },
                    { 2, "vtmchshn@gmail.com", "Volodymyr", "Tomchyshyn", "+380978945600" },
                    { 3, "anasttmchshn@gmail.com", "Anastasiia", "Tomchyshyn", "+380958445600" },
                    { 4, "ihor.ant@gmail.com", "Ihor", "Antoniuk", "+380937890567" },
                    { 5, "yuliakoval@gmail.com", "Yulia", "Koval", "+380937890533" }
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "Budjet", "ClientId", "Name", "StartedDate" },
                values: new object[,]
                {
                    { 1, 100000f, 1, "MedicalSystem", new DateTime(2023, 1, 9, 21, 55, 17, 576, DateTimeKind.Local).AddTicks(5095) },
                    { 2, 500000f, 2, "CosmeticsShop", new DateTime(2023, 1, 9, 21, 55, 17, 576, DateTimeKind.Local).AddTicks(5124) },
                    { 3, 1000000f, 2, "HomeShop", new DateTime(2023, 1, 9, 21, 55, 17, 576, DateTimeKind.Local).AddTicks(5127) },
                    { 4, 200000f, 3, "SchoolDiary", new DateTime(2023, 1, 9, 21, 55, 17, 576, DateTimeKind.Local).AddTicks(5129) },
                    { 5, 6000000f, 4, "HealthMentainer", new DateTime(2023, 1, 9, 21, 55, 17, 576, DateTimeKind.Local).AddTicks(5132) },
                    { 6, 500000f, 5, "GreenShop", new DateTime(2023, 1, 9, 21, 55, 17, 576, DateTimeKind.Local).AddTicks(5138) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "ClientId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "ClientId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "ClientId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "ClientId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "ClientId",
                keyValue: 5);
        }
    }
}
