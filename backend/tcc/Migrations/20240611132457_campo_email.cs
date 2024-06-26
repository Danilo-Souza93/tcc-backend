﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tcc.Migrations
{
    /// <inheritdoc />
    public partial class campo_email : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "vendas",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "vendas");
        }
    }
}
