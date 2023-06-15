using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task_backend.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BikeBrands",
                columns: table => new
                {
                    BikeBrandId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BikeBrands", x => x.BikeBrandId);
                });

            migrationBuilder.CreateTable(
                name: "BikeTypes",
                columns: table => new
                {
                    BikeTypeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BikeTypes", x => x.BikeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceComponents",
                columns: table => new
                {
                    ServiceComponentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    Currency = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceComponents", x => x.ServiceComponentId);
                });

            migrationBuilder.CreateTable(
                name: "ServicePackages",
                columns: table => new
                {
                    ServicePackageId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<int>(type: "INTEGER", nullable: true),
                    Currency = table.Column<string>(type: "TEXT", nullable: true),
                    ElectroBike = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePackages", x => x.ServicePackageId);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BikeTypeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BikeBrandId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ServiceComponentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Message = table.Column<string>(type: "TEXT", nullable: false),
                    AddPackages = table.Column<bool>(type: "INTEGER", nullable: false),
                    Ebike = table.Column<bool>(type: "INTEGER", nullable: false),
                    MaxMoney = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    SureName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Street = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Street2 = table.Column<string>(type: "TEXT", nullable: false),
                    Zip = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_Reports_BikeBrands_BikeBrandId",
                        column: x => x.BikeBrandId,
                        principalTable: "BikeBrands",
                        principalColumn: "BikeBrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_BikeTypes_BikeTypeId",
                        column: x => x.BikeTypeId,
                        principalTable: "BikeTypes",
                        principalColumn: "BikeTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_ServiceComponents_ServiceComponentId",
                        column: x => x.ServiceComponentId,
                        principalTable: "ServiceComponents",
                        principalColumn: "ServiceComponentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportServicePackage",
                columns: table => new
                {
                    ReportsReportId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ServicePackegesServicePackageId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportServicePackage", x => new { x.ReportsReportId, x.ServicePackegesServicePackageId });
                    table.ForeignKey(
                        name: "FK_ReportServicePackage_Reports_ReportsReportId",
                        column: x => x.ReportsReportId,
                        principalTable: "Reports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportServicePackage_ServicePackages_ServicePackegesServicePackageId",
                        column: x => x.ServicePackegesServicePackageId,
                        principalTable: "ServicePackages",
                        principalColumn: "ServicePackageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_BikeBrandId",
                table: "Reports",
                column: "BikeBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_BikeTypeId",
                table: "Reports",
                column: "BikeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ServiceComponentId",
                table: "Reports",
                column: "ServiceComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportServicePackage_ServicePackegesServicePackageId",
                table: "ReportServicePackage",
                column: "ServicePackegesServicePackageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportServicePackage");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "ServicePackages");

            migrationBuilder.DropTable(
                name: "BikeBrands");

            migrationBuilder.DropTable(
                name: "BikeTypes");

            migrationBuilder.DropTable(
                name: "ServiceComponents");
        }
    }
}
