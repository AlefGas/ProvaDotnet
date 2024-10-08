﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empresa.Migrations
{
    /// <inheritdoc />
    public partial class Tree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empregados_PX_Departamentos_PX_DepartamentoDepId",
                table: "Empregados_PX");

            migrationBuilder.DropIndex(
                name: "IX_Empregados_PX_DepartamentoDepId",
                table: "Empregados_PX");

            migrationBuilder.DropColumn(
                name: "DepartamentoDepId",
                table: "Empregados_PX");

            migrationBuilder.CreateIndex(
                name: "IX_Empregados_PX_DepId",
                table: "Empregados_PX",
                column: "DepId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empregados_PX_Departamentos_PX_DepId",
                table: "Empregados_PX",
                column: "DepId",
                principalTable: "Departamentos_PX",
                principalColumn: "DepId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empregados_PX_Departamentos_PX_DepId",
                table: "Empregados_PX");

            migrationBuilder.DropIndex(
                name: "IX_Empregados_PX_DepId",
                table: "Empregados_PX");

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoDepId",
                table: "Empregados_PX",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empregados_PX_DepartamentoDepId",
                table: "Empregados_PX",
                column: "DepartamentoDepId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empregados_PX_Departamentos_PX_DepartamentoDepId",
                table: "Empregados_PX",
                column: "DepartamentoDepId",
                principalTable: "Departamentos_PX",
                principalColumn: "DepId");
        }
    }
}
