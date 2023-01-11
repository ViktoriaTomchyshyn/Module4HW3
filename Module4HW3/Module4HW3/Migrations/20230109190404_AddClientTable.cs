using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Module4HW3.Migrations
{
    /// <inheritdoc />
    public partial class AddClientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

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
                    { 1, 100000f, 1, "MedicalSystem", new DateTime(2023, 1, 9, 22, 4, 4, 408, DateTimeKind.Local).AddTicks(6232) },
                    { 2, 500000f, 2, "CosmeticsShop", new DateTime(2023, 1, 9, 22, 4, 4, 408, DateTimeKind.Local).AddTicks(6260) },
                    { 3, 1000000f, 2, "HomeShop", new DateTime(2023, 1, 9, 22, 4, 4, 408, DateTimeKind.Local).AddTicks(6263) },
                    { 4, 200000f, 3, "SchoolDiary", new DateTime(2023, 1, 9, 22, 4, 4, 408, DateTimeKind.Local).AddTicks(6265) },
                    { 5, 6000000f, 4, "HealthMentainer", new DateTime(2023, 1, 9, 22, 4, 4, 408, DateTimeKind.Local).AddTicks(6267) },
                    { 6, 500000f, 5, "GreenShop", new DateTime(2023, 1, 9, 22, 4, 4, 408, DateTimeKind.Local).AddTicks(6272) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientId",
                table: "Project",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Client_ClientId",
                table: "Project",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Client_ClientId",
                table: "Project");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Project_ClientId",
                table: "Project");

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

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Project");
        }
    }
}
