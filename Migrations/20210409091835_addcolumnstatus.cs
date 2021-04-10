using Microsoft.EntityFrameworkCore.Migrations;

namespace vn.edu.payment.qr.Migrations
{
    public partial class addcolumnstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Invoices");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Invoices",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
