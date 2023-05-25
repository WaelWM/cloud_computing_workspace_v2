using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCFlowerShopWeek3.Migrations
{
    /// <inheritdoc />
    public partial class addNewCustomUserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerAddress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerAge",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerDOB",
                table: "AspNetUsers",
                type: "datetime",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerAddress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CustomerAge",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CustomerDOB",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "AspNetUsers");
        }
    }
}
