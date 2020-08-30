using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Velocity.Data.Migrations
{
    public partial class ModelChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_Containers_ContainerId",
                table: "InvoiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_Invoices_InvoiceId",
                table: "InvoiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Clients_ClientId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Transits_Containers_ContainerId",
                table: "Transits");

            migrationBuilder.DropForeignKey(
                name: "FK_Transits_Invoices_InvoiceId",
                table: "Transits");

            migrationBuilder.DropIndex(
                name: "IX_Transits_ContainerId",
                table: "Transits");

            migrationBuilder.DropIndex(
                name: "IX_Transits_InvoiceId",
                table: "Transits");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ClientId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetails_ContainerId",
                table: "InvoiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetails_InvoiceId",
                table: "InvoiceDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Terms",
                table: "Invoices",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<Guid>(
                name: "ContainerId",
                table: "InvoiceDetails",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InvoiceId",
                table: "Clients",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_InvoiceId",
                table: "Clients",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Invoices_InvoiceId",
                table: "Clients",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Invoices_InvoiceId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_InvoiceId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Clients");

            migrationBuilder.AlterColumn<string>(
                name: "Terms",
                table: "Invoices",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ContainerId",
                table: "InvoiceDetails",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_Transits_ContainerId",
                table: "Transits",
                column: "ContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Transits_InvoiceId",
                table: "Transits",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ClientId",
                table: "Invoices",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_ContainerId",
                table: "InvoiceDetails",
                column: "ContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceId",
                table: "InvoiceDetails",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_Containers_ContainerId",
                table: "InvoiceDetails",
                column: "ContainerId",
                principalTable: "Containers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_Invoices_InvoiceId",
                table: "InvoiceDetails",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Clients_ClientId",
                table: "Invoices",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transits_Containers_ContainerId",
                table: "Transits",
                column: "ContainerId",
                principalTable: "Containers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transits_Invoices_InvoiceId",
                table: "Transits",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
