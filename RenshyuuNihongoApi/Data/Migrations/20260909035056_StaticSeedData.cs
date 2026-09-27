using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RenshyuuNihongoApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class StaticSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "examples",
                keyColumn: "id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666661"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "grammars",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444441"),
                column: "notes",
                value: new List<string> { "Danh từ đứng trước は là chủ đề." });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888881"),
                columns: new[] { "answers", "created_at", "updated_at" },
                values: new object[] { new List<string> { "わたし", "あなた", "たべる", "にち" }, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "examples",
                keyColumn: "id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666661"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2026, 9, 9, 10, 41, 43, 42, DateTimeKind.Local).AddTicks(767), new DateTime(2026, 9, 9, 10, 41, 43, 42, DateTimeKind.Local).AddTicks(9733) });

            migrationBuilder.UpdateData(
                table: "grammars",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444441"),
                column: "notes",
                value: new List<string> { "Danh từ đứng trước は là chủ đề." });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888881"),
                columns: new[] { "answers", "created_at", "updated_at" },
                values: new object[] { new List<string> { "わたし", "あなた", "たべる", "にち" }, new DateTime(2026, 9, 9, 10, 41, 43, 56, DateTimeKind.Local).AddTicks(2004), new DateTime(2026, 9, 9, 10, 41, 43, 56, DateTimeKind.Local).AddTicks(2008) });
        }
    }
}
