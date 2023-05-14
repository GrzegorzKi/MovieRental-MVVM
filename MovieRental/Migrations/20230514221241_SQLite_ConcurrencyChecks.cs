using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace MovieRental.Migrations {
    /// <inheritdoc />
    public partial class SQLite_ConcurrencyChecks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string triggerQuery = @"CREATE TRIGGER Set{0}RowVersion{1}
                AFTER {1} ON {0}
                BEGIN
                    UPDATE {0}
                    SET RowVersion = CAST(ROUND((julianday('now') - 2440587.5)*86400000) AS INT)
                    WHERE rowid = NEW.rowid;
                END
            ";

            migrationBuilder.Sql(string.Format(triggerQuery, "Customer", "UPDATE"));
            migrationBuilder.Sql(string.Format(triggerQuery, "Customer", "INSERT"));
            migrationBuilder.Sql(string.Format(triggerQuery, "Movie", "UPDATE"));
            migrationBuilder.Sql(string.Format(triggerQuery, "Movie", "INSERT"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string triggerQuery = "DROP TRIGGER IF EXISTS Set{0}RowVersion{1}";

            migrationBuilder.Sql(string.Format(triggerQuery, "Customer", "UPDATE"));
            migrationBuilder.Sql(string.Format(triggerQuery, "Customer", "INSERT"));
            migrationBuilder.Sql(string.Format(triggerQuery, "Movie", "UPDATE"));
            migrationBuilder.Sql(string.Format(triggerQuery, "Movie", "INSERT"));
        }
    }
}
