using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RenshyuuNihongoApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lesson",
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
                    table.PrimaryKey("PK_lesson", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    email = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    username = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Grammars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Pattern = table.Column<string>(type: "text", nullable: false),
                    Structure = table.Column<string>(type: "text", nullable: false),
                    Meaning = table.Column<string>(type: "text", nullable: false),
                    Explanation = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LessonId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grammars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grammars_lesson_LessonId",
                        column: x => x.LessonId,
                        principalTable: "lesson",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Kanjis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Character = table.Column<string>(type: "text", nullable: false),
                    Kana = table.Column<string>(type: "text", nullable: false),
                    Onyomi = table.Column<string>(type: "text", nullable: true),
                    Kunyomi = table.Column<string>(type: "text", nullable: true),
                    Meaning = table.Column<string>(type: "text", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    StrokeCount = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LessonId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kanjis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kanjis_lesson_LessonId",
                        column: x => x.LessonId,
                        principalTable: "lesson",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "vocabulary",
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
                    table.PrimaryKey("PK_vocabulary", x => x.id);
                    table.ForeignKey(
                        name: "FK_vocabulary_lesson_id",
                        column: x => x.lesson_id,
                        principalTable: "lesson",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Examples",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    VocabularyId = table.Column<Guid>(type: "uuid", nullable: false),
                    GrammarId = table.Column<Guid>(type: "uuid", nullable: false),
                    KanjiId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Examples_Grammars_GrammarId",
                        column: x => x.GrammarId,
                        principalTable: "Grammars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Examples_Kanjis_KanjiId",
                        column: x => x.KanjiId,
                        principalTable: "Kanjis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Examples_vocabulary_VocabularyId",
                        column: x => x.VocabularyId,
                        principalTable: "vocabulary",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KanjiVocabulary",
                columns: table => new
                {
                    KanjisId = table.Column<Guid>(type: "uuid", nullable: false),
                    VocabulariesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KanjiVocabulary", x => new { x.KanjisId, x.VocabulariesId });
                    table.ForeignKey(
                        name: "FK_KanjiVocabulary_Kanjis_KanjisId",
                        column: x => x.KanjisId,
                        principalTable: "Kanjis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KanjiVocabulary_vocabulary_VocabulariesId",
                        column: x => x.VocabulariesId,
                        principalTable: "vocabulary",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Examples_GrammarId",
                table: "Examples",
                column: "GrammarId");

            migrationBuilder.CreateIndex(
                name: "IX_Examples_KanjiId",
                table: "Examples",
                column: "KanjiId");

            migrationBuilder.CreateIndex(
                name: "IX_Examples_VocabularyId",
                table: "Examples",
                column: "VocabularyId");

            migrationBuilder.CreateIndex(
                name: "IX_Grammars_LessonId",
                table: "Grammars",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Kanjis_LessonId",
                table: "Kanjis",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_KanjiVocabulary_VocabulariesId",
                table: "KanjiVocabulary",
                column: "VocabulariesId");

            migrationBuilder.CreateIndex(
                name: "IX_lesson_lesson_number",
                table: "lesson",
                column: "lesson_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_lesson_level",
                table: "lesson",
                column: "level");

            migrationBuilder.CreateIndex(
                name: "IX_lesson_source",
                table: "lesson",
                column: "source");

            migrationBuilder.CreateIndex(
                name: "IX_user_email",
                table: "user",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vocabulary_lesson_id",
                table: "vocabulary",
                column: "lesson_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Examples");

            migrationBuilder.DropTable(
                name: "KanjiVocabulary");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "Grammars");

            migrationBuilder.DropTable(
                name: "Kanjis");

            migrationBuilder.DropTable(
                name: "vocabulary");

            migrationBuilder.DropTable(
                name: "lesson");
        }
    }
}
