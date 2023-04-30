using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class FeatureUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Features2");

            migrationBuilder.RenameColumn(
                name: "Feature1Id",
                table: "Features",
                newName: "FeatureId");

            migrationBuilder.AddColumn<bool>(
                name: "isBigImage",
                table: "Features",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isBigImage",
                table: "Features");

            migrationBuilder.RenameColumn(
                name: "FeatureId",
                table: "Features",
                newName: "Feature1Id");

            migrationBuilder.CreateTable(
                name: "Features2",
                columns: table => new
                {
                    Feature1Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features2", x => x.Feature1Id);
                });
        }
    }
}
