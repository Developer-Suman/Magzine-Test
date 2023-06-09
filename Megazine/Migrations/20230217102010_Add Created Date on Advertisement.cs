﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Megazine.Migrations
{
    public partial class AddCreatedDateonAdvertisement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Advertisements",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Advertisements");
        }
    }
}
