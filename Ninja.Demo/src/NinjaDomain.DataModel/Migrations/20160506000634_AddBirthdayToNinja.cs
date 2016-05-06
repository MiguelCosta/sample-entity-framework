using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace NinjaDomain.DataModel.Migrations
{
    public partial class AddBirthdayToNinja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Ninja_Clan_ClanId", table: "Ninja");
            migrationBuilder.DropForeignKey(name: "FK_NinjaEquipment_Ninja_NinjaId", table: "NinjaEquipment");
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Ninja",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddForeignKey(
                name: "FK_Ninja_Clan_ClanId",
                table: "Ninja",
                column: "ClanId",
                principalTable: "Clan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_NinjaEquipment_Ninja_NinjaId",
                table: "NinjaEquipment",
                column: "NinjaId",
                principalTable: "Ninja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Ninja_Clan_ClanId", table: "Ninja");
            migrationBuilder.DropForeignKey(name: "FK_NinjaEquipment_Ninja_NinjaId", table: "NinjaEquipment");
            migrationBuilder.DropColumn(name: "DateOfBirth", table: "Ninja");
            migrationBuilder.AddForeignKey(
                name: "FK_Ninja_Clan_ClanId",
                table: "Ninja",
                column: "ClanId",
                principalTable: "Clan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_NinjaEquipment_Ninja_NinjaId",
                table: "NinjaEquipment",
                column: "NinjaId",
                principalTable: "Ninja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
