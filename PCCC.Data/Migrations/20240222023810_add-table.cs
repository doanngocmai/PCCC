using System;
using System.Collections;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCCC.Data.Migrations
{
    /// <inheritdoc />
    public partial class addtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApartmentUsers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false),
                    Address = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ApartmentID = table.Column<int>(type: "integer", nullable: false),
                    Longitude = table.Column<float>(type: "real", nullable: true),
                    Latitude = table.Column<float>(type: "real", nullable: true),
                    CreationTime = table.Column<DateOnly>(type: "date", nullable: false),
                    AreaID = table.Column<int>(type: "integer", nullable: false),
                    MapID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    Type = table.Column<string>(type: "character varying", nullable: false),
                    PointAreaID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Address = table.Column<string>(type: "character varying", nullable: false),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    FloorCount = table.Column<int>(type: "integer", nullable: false),
                    Image = table.Column<string>(type: "character varying", nullable: true),
                    ApartmentUserID = table.Column<int>(type: "integer", nullable: false),
                    CreationTime = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Image = table.Column<string>(type: "character varying", nullable: true),
                    Link = table.Column<string>(type: "character varying", nullable: true),
                    Color = table.Column<string>(type: "character varying", nullable: true),
                    Icon = table.Column<string>(type: "character varying", nullable: true),
                    IsActive = table.Column<BitArray>(type: "bit(1)", nullable: false),
                    CreationTime = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Maps",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DisplayName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    Length = table.Column<float>(type: "real", nullable: false),
                    Width = table.Column<float>(type: "real", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Image = table.Column<string>(type: "character varying", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true),
                    CreationTime = table.Column<DateOnly>(type: "date", nullable: false),
                    FloorNumber = table.Column<int>(type: "integer", nullable: false),
                    AreaID = table.Column<int>(type: "integer", nullable: false),
                    BuiildingID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreationTime = table.Column<DateOnly>(type: "date", nullable: false),
                    Image = table.Column<string>(type: "character varying", nullable: true),
                    IsActive = table.Column<BitArray>(type: "bit(1)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false),
                    RoleID = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    UserID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "PointAreas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false),
                    X = table.Column<int>(type: "integer", nullable: false),
                    Y = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false),
                    RoleName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DisplayName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true),
                    CreationTime = table.Column<DateOnly>(type: "date", nullable: false),
                    IsActive = table.Column<BitArray>(type: "bit(1)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false),
                    UserID = table.Column<long>(type: "bigint", nullable: false),
                    RoleID = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false),
                    UserName = table.Column<string[]>(type: "character varying(256)[]", nullable: false),
                    FullName = table.Column<string>(type: "character varying", nullable: true),
                    Phone = table.Column<string[]>(type: "character varying(15)[]", nullable: false),
                    Gmail = table.Column<string[]>(type: "character varying(256)[]", nullable: true),
                    Sex = table.Column<bool>(type: "boolean", nullable: false),
                    Address = table.Column<string>(type: "character varying", nullable: true),
                    Password = table.Column<string>(type: "character varying", nullable: false),
                    IsActive = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    CreationTime = table.Column<DateOnly>(type: "date", nullable: false),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    CreatorUserName = table.Column<string>(type: "character varying", nullable: false),
                    UpgradeAccID = table.Column<long>(type: "bigint", nullable: true),
                    BuildingID = table.Column<long>(type: "bigint", nullable: true),
                    ApartmentUserID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApartmentUsers");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "Maps");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "PointAreas");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
