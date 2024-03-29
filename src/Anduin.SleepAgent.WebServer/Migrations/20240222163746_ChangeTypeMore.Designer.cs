﻿// <auto-generated />
using System;
using Anduin.SleepAgent.WebServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Anduin.SleepAgent.WebServer.Migrations
{
    [DbContext(typeof(AgentDbContext))]
    [Migration("20240222163746_ChangeTypeMore")]
    partial class ChangeTypeMore
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("Anduin.SleepAgent.WebServer.Data.MetricData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Battery")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BirthDay")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BirthMonth")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BirthYear")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BloodOxygenRetCode")
                        .HasColumnType("INTEGER");

                    b.Property<long>("BloodOxygenTime")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BloodOxygenValue")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Calorie")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CalorieT")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DeviceColor")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DeviceHeight")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DeviceName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("DeviceSource")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DeviceWidth")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Distance")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FatBurning")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FatBurningT")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HeartRateLast")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HeartRateResting")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HeartRateSummaryMaximumHrValue")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("HeartRateSummaryMaximumTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("HeartRateSummaryMaximumTimeZone")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Height")
                        .HasColumnType("REAL");

                    b.Property<int>("IsWearing")
                        .HasColumnType("INTEGER");

                    b.Property<int>("KeyNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("KeyType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("PaiDay")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PaiWeek")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductVer")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("RecordTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("ScreenShape")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SkuId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SleepInfoDeepTime")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SleepInfoEndTime")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SleepInfoScore")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SleepInfoStartTime")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SleepInfoTotalTime")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SleepStgListDeepStage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SleepStgListLightStage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SleepStgListRemStage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SleepStgListWakeStage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SleepingStatus")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Stands")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StandsT")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Steps")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StepsT")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StressTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("StressValue")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Weight")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("MetricData");
                });
#pragma warning restore 612, 618
        }
    }
}
