using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anduin.SleepAgent.WebServer.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MetricData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RecordTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Height = table.Column<double>(type: "REAL", nullable: false),
                    Weight = table.Column<double>(type: "REAL", nullable: false),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    NickName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Region = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    BirthYear = table.Column<int>(type: "INTEGER", nullable: false),
                    BirthMonth = table.Column<int>(type: "INTEGER", nullable: false),
                    BirthDay = table.Column<int>(type: "INTEGER", nullable: false),
                    DeviceWidth = table.Column<int>(type: "INTEGER", nullable: false),
                    DeviceHeight = table.Column<int>(type: "INTEGER", nullable: false),
                    ScreenShape = table.Column<int>(type: "INTEGER", nullable: false),
                    DeviceName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    KeyNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    KeyType = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DeviceSource = table.Column<int>(type: "INTEGER", nullable: false),
                    DeviceColor = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductVer = table.Column<int>(type: "INTEGER", nullable: false),
                    SkuId = table.Column<int>(type: "INTEGER", nullable: false),
                    HeartRateLast = table.Column<int>(type: "INTEGER", nullable: false),
                    HeartRateResting = table.Column<int>(type: "INTEGER", nullable: false),
                    HeartRateSummaryMaximumTime = table.Column<long>(type: "INTEGER", nullable: false),
                    HeartRateSummaryMaximumTimeZone = table.Column<int>(type: "INTEGER", nullable: false),
                    HeartRateSummaryMaximumHrValue = table.Column<int>(type: "INTEGER", nullable: false),
                    Battery = table.Column<int>(type: "INTEGER", nullable: false),
                    BloodOxygenValue = table.Column<int>(type: "INTEGER", nullable: false),
                    BloodOxygenTime = table.Column<long>(type: "INTEGER", nullable: false),
                    BloodOxygenRetCode = table.Column<int>(type: "INTEGER", nullable: false),
                    Calorie = table.Column<int>(type: "INTEGER", nullable: false),
                    CalorieT = table.Column<int>(type: "INTEGER", nullable: false),
                    Distance = table.Column<int>(type: "INTEGER", nullable: false),
                    FatBurning = table.Column<int>(type: "INTEGER", nullable: false),
                    FatBurningT = table.Column<int>(type: "INTEGER", nullable: false),
                    PaiDay = table.Column<int>(type: "INTEGER", nullable: false),
                    PaiWeek = table.Column<int>(type: "INTEGER", nullable: false),
                    SleepInfoScore = table.Column<int>(type: "INTEGER", nullable: false),
                    SleepInfoStartTime = table.Column<int>(type: "INTEGER", nullable: false),
                    SleepInfoEndTime = table.Column<int>(type: "INTEGER", nullable: false),
                    SleepInfoDeepTime = table.Column<int>(type: "INTEGER", nullable: false),
                    SleepInfoTotalTime = table.Column<int>(type: "INTEGER", nullable: false),
                    SleepStgListWakeStage = table.Column<int>(type: "INTEGER", nullable: false),
                    SleepStgListRemStage = table.Column<int>(type: "INTEGER", nullable: false),
                    SleepStgListLightStage = table.Column<int>(type: "INTEGER", nullable: false),
                    SleepStgListDeepStage = table.Column<int>(type: "INTEGER", nullable: false),
                    SleepingStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    Stands = table.Column<int>(type: "INTEGER", nullable: false),
                    StandsT = table.Column<int>(type: "INTEGER", nullable: false),
                    Steps = table.Column<int>(type: "INTEGER", nullable: false),
                    StepsT = table.Column<int>(type: "INTEGER", nullable: false),
                    StressValue = table.Column<int>(type: "INTEGER", nullable: false),
                    StressTime = table.Column<long>(type: "INTEGER", nullable: false),
                    IsWearing = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetricData", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MetricData");
        }
    }
}
