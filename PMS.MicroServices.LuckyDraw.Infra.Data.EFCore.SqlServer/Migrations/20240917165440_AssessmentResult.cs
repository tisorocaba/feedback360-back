using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class AssessmentResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // AssessmentResult
            migrationBuilder.CreateTable(
                name: "AssessmentResult",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSortition = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "varchar(256)", nullable: false),
                    NickName = table.Column<string>(type: "varchar(256)", nullable: true),
                    UserName = table.Column<string>(type: "varchar(256)", nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", nullable: true),
                    Code = table.Column<string>(type: "varchar(256)", nullable: true),
                    BelongsToManagementTeam = table.Column<bool>(type: "bit", nullable: false),
                    HasImmediateSubordinates = table.Column<bool>(type: "bit", nullable: false),
                    HasMediateSubordinates = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentResult_Sortition_IdSortition",
                        column: x => x.IdSortition,
                        principalSchema: "dbo",
                        principalTable: "Sortition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            // DocumentTemplate
            migrationBuilder.CreateTable(
                name: "DocumentTemplate",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", nullable: false),
                    Description = table.Column<string>(type: "varchar(512)", nullable: true),
                    Content = table.Column<string>(type: "varchar(max)", nullable: false),
                    Keywords = table.Column<string>(type: "varchar(256)", nullable: true),
                    Version = table.Column<string>(type: "varchar(50)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateBy = table.Column<Guid?>(type: "uniqueidentifier", nullable: true),
                    LastUpdateAt = table.Column<DateTime?>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTemplate", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // DocumentTemplate
            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentTemplate",
                table: "DocumentTemplate",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DocumentTemplate",
                schema: "dbo");

            // AssessmentResult
            migrationBuilder.DropForeignKey(
                name: "FK_AssessmentResult_Sortition_IdSortition",
                table: "AssessmentResult",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssessmentResult",
                table: "AssessmentResult",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AssessmentResult",
                schema: "dbo");
        }
    }
}
