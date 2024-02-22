using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anduin.SleepAgent.WebServer.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTypeMore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "HeartRateSummaryMaximumTime",
                table: "MetricData",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "HeartRateSummaryMaximumTime",
                table: "MetricData",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");
        }
    }
}
