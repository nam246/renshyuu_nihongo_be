using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RenshyuuNihongoApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lessons",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    lesson_number = table.Column<int>(type: "integer", nullable: false),
                    source = table.Column<string>(type: "text", nullable: true),
                    level = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lessons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    username = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "grammars",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    pattern = table.Column<string>(type: "text", nullable: false),
                    structure = table.Column<string>(type: "text", nullable: false),
                    meaning = table.Column<string>(type: "text", nullable: false),
                    explanation = table.Column<string>(type: "text", nullable: true),
                    notes = table.Column<List<string>>(type: "text[]", nullable: true),
                    level = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lesson_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_grammars", x => x.id);
                    table.ForeignKey(
                        name: "fk_grammars_lessons_lesson_id",
                        column: x => x.lesson_id,
                        principalTable: "lessons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "kanjis",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    character = table.Column<string>(type: "text", nullable: false),
                    kana = table.Column<string>(type: "text", nullable: false),
                    onyomi = table.Column<string>(type: "text", nullable: true),
                    kunyomi = table.Column<string>(type: "text", nullable: true),
                    meaning = table.Column<string>(type: "text", nullable: false),
                    level = table.Column<int>(type: "integer", nullable: false),
                    stroke_count = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lesson_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_kanjis", x => x.id);
                    table.ForeignKey(
                        name: "fk_kanjis_lessons_lesson_id",
                        column: x => x.lesson_id,
                        principalTable: "lessons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "vocabularies",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    word = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    kana = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    romaji = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    meaning = table.Column<string>(type: "text", nullable: false),
                    word_type = table.Column<string>(type: "text", nullable: false),
                    level = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    lesson_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vocabularies", x => x.id);
                    table.ForeignKey(
                        name: "FK_vocabulary_lesson_id",
                        column: x => x.lesson_id,
                        principalTable: "lessons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "examples",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    vocabulary_id = table.Column<Guid>(type: "uuid", nullable: false),
                    grammar_id = table.Column<Guid>(type: "uuid", nullable: false),
                    kanji_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_examples", x => x.id);
                    table.ForeignKey(
                        name: "fk_examples_grammars_grammar_id",
                        column: x => x.grammar_id,
                        principalTable: "grammars",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_examples_kanjis_kanji_id",
                        column: x => x.kanji_id,
                        principalTable: "kanjis",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_examples_vocabularies_vocabulary_id",
                        column: x => x.vocabulary_id,
                        principalTable: "vocabularies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kanji_vocabulary",
                columns: table => new
                {
                    kanjis_id = table.Column<Guid>(type: "uuid", nullable: false),
                    vocabularies_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_kanji_vocabulary", x => new { x.kanjis_id, x.vocabularies_id });
                    table.ForeignKey(
                        name: "fk_kanji_vocabulary_kanjis_kanjis_id",
                        column: x => x.kanjis_id,
                        principalTable: "kanjis",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_kanji_vocabulary_vocabularies_vocabularies_id",
                        column: x => x.vocabularies_id,
                        principalTable: "vocabularies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "lessons",
                columns: new[] { "id", "created_at", "lesson_number", "level", "source" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "N5", "Minna no Nihongo" });

            migrationBuilder.InsertData(
                table: "vocabularies",
                columns: new[] { "id", "created_at", "kana", "lesson_id", "level", "meaning", "romaji", "word", "word_type" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-2222-2222-222222222221"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "わたし", new Guid("11111111-1111-1111-1111-111111111111"), "N5", "Tôi", "watashi", "私", "PRONOUN" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "あなた", new Guid("11111111-1111-1111-1111-111111111111"), "N5", "Bạn", "anata", "あなた", "PRONOUN" },
                    { new Guid("22222222-2222-2222-2222-222222222223"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "たべる", new Guid("11111111-1111-1111-1111-111111111111"), "N5", "Ăn", "taberu", "食べる", "VERB" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_examples_grammar_id",
                table: "examples",
                column: "grammar_id");

            migrationBuilder.CreateIndex(
                name: "ix_examples_kanji_id",
                table: "examples",
                column: "kanji_id");

            migrationBuilder.CreateIndex(
                name: "ix_examples_vocabulary_id",
                table: "examples",
                column: "vocabulary_id");

            migrationBuilder.CreateIndex(
                name: "ix_grammars_lesson_id",
                table: "grammars",
                column: "lesson_id");

            migrationBuilder.CreateIndex(
                name: "ix_kanji_vocabulary_vocabularies_id",
                table: "kanji_vocabulary",
                column: "vocabularies_id");

            migrationBuilder.CreateIndex(
                name: "ix_kanjis_lesson_id",
                table: "kanjis",
                column: "lesson_id");

            migrationBuilder.CreateIndex(
                name: "ix_lessons_lesson_number",
                table: "lessons",
                column: "lesson_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_lessons_level",
                table: "lessons",
                column: "level");

            migrationBuilder.CreateIndex(
                name: "ix_lessons_source",
                table: "lessons",
                column: "source");

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vocabulary_lesson_id",
                table: "vocabularies",
                column: "lesson_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "examples");

            migrationBuilder.DropTable(
                name: "kanji_vocabulary");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "grammars");

            migrationBuilder.DropTable(
                name: "kanjis");

            migrationBuilder.DropTable(
                name: "vocabularies");

            migrationBuilder.DropTable(
                name: "lessons");
        }
    }
}
