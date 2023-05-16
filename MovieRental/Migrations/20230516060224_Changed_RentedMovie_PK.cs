using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieRental.Migrations
{
    /// <inheritdoc />
    public partial class Changed_RentedMovie_PK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RentedMovie",
                table: "RentedMovie");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RentedMovie",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<long>(
                name: "RowVersion",
                table: "Movie",
                type: "INTEGER",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "BLOB",
                oldRowVersion: true,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "RowVersion",
                table: "Customer",
                type: "INTEGER",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "BLOB",
                oldRowVersion: true,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentedMovie",
                table: "RentedMovie",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RentedMovie_MovieId",
                table: "RentedMovie",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RentedMovie",
                table: "RentedMovie");

            migrationBuilder.DropIndex(
                name: "IX_RentedMovie_MovieId",
                table: "RentedMovie");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RentedMovie");

            migrationBuilder.AlterColumn<byte[]>(
                name: "RowVersion",
                table: "Movie",
                type: "BLOB",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER",
                oldRowVersion: true,
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "RowVersion",
                table: "Customer",
                type: "BLOB",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER",
                oldRowVersion: true,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentedMovie",
                table: "RentedMovie",
                columns: new[] { "MovieId", "CustomerId" });
        }
    }
}
