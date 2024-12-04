using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Team",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", nullable: false),
                    Description = table.Column<string>(type: "varchar(512)", nullable: true),
                    NumberOfParticipants = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.UniqueConstraint("UC_Team", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Sortition",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTeam = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    NumberOfParticipants = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "varchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sortition", x => x.Id);
                    table.ForeignKey("FK_Sortition_Team", x => x.IdTeam, "Team", "Id");
                    table.UniqueConstraint("UC_Sortition", x => new { x.IdTeam, x.Number });
                });

            migrationBuilder.CreateTable(
                name: "SortitionParticipant",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSortition = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "varchar(256)", nullable: false),
                    AccessCounter = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SortitionParticipant", x => x.Id);
                    table.ForeignKey("FK_SortitionParticipant_Sortition", x => x.IdSortition, "Sortition", "Id");
                    table.UniqueConstraint("UC_SortitionParticipant", x => new { x.IdSortition, x.Number });
                });

            migrationBuilder.CreateTable(
                name: "SortitionParticipantPrinting",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSortition = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SortitionParticipantPrinting", x => x.Id);
                    table.ForeignKey("FK_SortitionParticipantPrinting_Sortition", x => x.IdSortition, "Sortition", "Id");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SortitionParticipantPrinting_Sortition",
                table: "SortitionParticipantPrinting",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SortitionParticipantPrinting",
                table: "SortitionParticipantPrinting",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SortitionParticipantPrinting",
                schema: "dbo");

            migrationBuilder.DropUniqueConstraint(
                name: "UC_SortitionParticipant",
                table: "SortitionParticipant",
                schema: "dbo");

            migrationBuilder.DropForeignKey(
                name: "FK_SortitionParticipant_Sortition",
                table: "SortitionParticipant",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SortitionParticipant",
                table: "SortitionParticipant",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SortitionParticipant",
                schema: "dbo");

            migrationBuilder.DropUniqueConstraint(
                name: "UC_Sortition",
                table: "Sortition",
                schema: "dbo");

            migrationBuilder.DropForeignKey(
                name: "FK_Sortition_Team",
                table: "Sortition",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sortition",
                table: "Sortition",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Sortition",
                schema: "dbo");

            migrationBuilder.DropUniqueConstraint(
                name: "UC_Team",
                table: "Team",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Team",
                table: "Team",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Team",
                schema: "dbo");
        }
    }
}
