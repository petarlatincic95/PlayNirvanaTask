using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NearbyPlaces.Migrations
{
    /// <inheritdoc />
    public partial class CorrectingGrammarMistakeOnSuccessfulRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReqestSentTime",
                table: "SuccessfulRequests",
                newName: "RequestSentTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestSentTime",
                table: "SuccessfulRequests",
                newName: "ReqestSentTime");
        }
    }
}
