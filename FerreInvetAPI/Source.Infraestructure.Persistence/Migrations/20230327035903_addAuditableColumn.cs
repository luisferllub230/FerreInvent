using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Infraestructure.Persistence.Migrations
{
    public partial class addAuditableColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "createBy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "created",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "lastModifiedBy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "lastMoified",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "createBy",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "created",
                table: "Sales",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "lastModifiedBy",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "lastMoified",
                table: "Sales",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "createBy",
                table: "Inventory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "created",
                table: "Inventory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "lastModifiedBy",
                table: "Inventory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "lastMoified",
                table: "Inventory",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "createBy",
                table: "Custumers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "created",
                table: "Custumers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "lastModifiedBy",
                table: "Custumers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "lastMoified",
                table: "Custumers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "createBy",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "created",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "lastModifiedBy",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "lastMoified",
                table: "Categories",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "created",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "lastModifiedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "lastMoified",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "createBy",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "created",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "lastModifiedBy",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "lastMoified",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "createBy",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "created",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "lastModifiedBy",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "lastMoified",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "createBy",
                table: "Custumers");

            migrationBuilder.DropColumn(
                name: "created",
                table: "Custumers");

            migrationBuilder.DropColumn(
                name: "lastModifiedBy",
                table: "Custumers");

            migrationBuilder.DropColumn(
                name: "lastMoified",
                table: "Custumers");

            migrationBuilder.DropColumn(
                name: "createBy",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "created",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "lastModifiedBy",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "lastMoified",
                table: "Categories");
        }
    }
}
