using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nm.Reservation.Migrations.Migrations
{
    public partial class createinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RESMANAGERINFOS",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    NAME = table.Column<string>(maxLength: 200, nullable: false),
                    OPENDAYS = table.Column<int>(nullable: false),
                    INCLUDEDAY = table.Column<bool>(nullable: false, defaultValue: true),
                    SCRIPTPOST = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESMANAGERINFOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RESCONDITIONS",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ITEMNAME = table.Column<string>(maxLength: 50, nullable: false),
                    ITEMVALUE = table.Column<string>(maxLength: 100, nullable: false),
                    RMID = table.Column<Guid>(nullable: false),
                    RCTYPE = table.Column<int>(nullable: false, defaultValue: 1),
                    SCRIPTPOST = table.Column<string>(maxLength: 500, nullable: true),
                    ReservationConditionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESCONDITIONS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RESCONDITIONS_RESMS_RMID",
                        column: x => x.RMID,
                        principalTable: "RESMANAGERINFOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RESCONDITIONS_RESCS_RCId",
                        column: x => x.ReservationConditionId,
                        principalTable: "RESCONDITIONS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RESPERIOD",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    STARTTIME = table.Column<DateTime>(nullable: false),
                    ENDTIME = table.Column<DateTime>(nullable: false),
                    NAME = table.Column<string>(maxLength: 100, nullable: false),
                    RCID = table.Column<Guid>(nullable: false),
                    SCRIPTPOST = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESPERIOD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RESPERIOD_RESCS_RCID",
                        column: x => x.RCID,
                        principalTable: "RESCONDITIONS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RESCONDITIONS_ITEMNAME",
                table: "RESCONDITIONS",
                column: "ITEMNAME");

            migrationBuilder.CreateIndex(
                name: "IX_RESCONDITIONS_ITEMVALUE",
                table: "RESCONDITIONS",
                column: "ITEMVALUE");

            migrationBuilder.CreateIndex(
                name: "IX_RESCONDITIONS_RMID",
                table: "RESCONDITIONS",
                column: "RMID");

            migrationBuilder.CreateIndex(
                name: "IX_RESCONDITIONS_RCId",
                table: "RESCONDITIONS",
                column: "ReservationConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_RESMANAGERINFOS_NAME",
                table: "RESMANAGERINFOS",
                column: "NAME");

            migrationBuilder.CreateIndex(
                name: "IX_RESPERIOD_RCID",
                table: "RESPERIOD",
                column: "RCID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RESPERIOD");

            migrationBuilder.DropTable(
                name: "RESCONDITIONS");

            migrationBuilder.DropTable(
                name: "RESMANAGERINFOS");
        }
    }
}
