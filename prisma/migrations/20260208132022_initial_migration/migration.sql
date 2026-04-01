-- CreateEnum
CREATE TYPE "Level" AS ENUM ('N5', 'N4', 'N3', 'N2', 'N1');

-- CreateEnum
CREATE TYPE "WordType" AS ENUM ('NOUN', 'VERB', 'I_ADJECTIVE', 'NA_ADJECTIVE', 'ADVERB', 'PARTICLE', 'CONJUNCTION', 'PRONOUN', 'EXPRESSION', 'COUNTER', 'OTHER');

-- CreateEnum
CREATE TYPE "Source" AS ENUM ('MINNA_NO_NIHONGO', 'SOUMATOME', 'OTHER');

-- CreateEnum
CREATE TYPE "QuestionType" AS ENUM ('VOCABULARY_CONTEXT_USAGE', 'VOCABULARY_SYNONYMS', 'VOCABULARY_WORD_USAGE', 'KANJI_READING', 'KANJI_WRITING', 'GRAMMAR_SELECT', 'GRAMMAR_STAR_ORDER', 'GRAMMAR_TEXT_GRAMMAR', 'READING_SHORT_PASSAGE', 'READING_MEDIUM_PASSAGE', 'READING_LONG_PASSAGE', 'READING_COMPARISION', 'READING_INFO_RETRIEVAL', 'LISTENING_TASK_BASED', 'LISTENING_KEY_POINT', 'LISTENING_GENERAL_UNDERSTANDING', 'LISTENING_QUICK_RESPONSE', 'LISTENING_INTEGRATED_COMPREHENSION');

-- CreateTable
CREATE TABLE "user" (
    "id" TEXT NOT NULL,
    "email" TEXT NOT NULL,
    "name" TEXT,
    "username" TEXT NOT NULL,
    "password" TEXT NOT NULL,
    "created_at" TIMESTAMP(3) NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "updated_at" TIMESTAMP(3) NOT NULL,

    CONSTRAINT "user_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "user_bookmarked" (
    "userId" TEXT NOT NULL,

    CONSTRAINT "user_bookmarked_pkey" PRIMARY KEY ("userId")
);

-- CreateTable
CREATE TABLE "lesson" (
    "id" TEXT NOT NULL,
    "lesson_title" TEXT NOT NULL,
    "source" "Source" NOT NULL DEFAULT 'OTHER',
    "level" "Level" NOT NULL,
    "created_at" TIMESTAMP(3) NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "updated_at" TIMESTAMP(3) NOT NULL,

    CONSTRAINT "lesson_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "vocabulary" (
    "id" TEXT NOT NULL,
    "word" TEXT NOT NULL,
    "kana" TEXT,
    "romaji" TEXT,
    "meaning" TEXT NOT NULL,
    "word_type" "WordType" NOT NULL,
    "level" "Level" NOT NULL,
    "created_at" TIMESTAMP(3) NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "updated_at" TIMESTAMP(3) NOT NULL,
    "lesson_id" TEXT,
    "userBookMarkedId" TEXT,

    CONSTRAINT "vocabulary_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "grammar" (
    "id" TEXT NOT NULL,
    "pattern" TEXT NOT NULL,
    "structure" TEXT NOT NULL,
    "meaning" TEXT NOT NULL,
    "explaination" TEXT,
    "notes" TEXT,
    "level" "Level" NOT NULL,
    "created_at" TIMESTAMP(3) NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "updated_at" TIMESTAMP(3) NOT NULL,
    "lesson_id" TEXT,
    "user_bookmarked_id" TEXT,

    CONSTRAINT "grammar_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "kanji" (
    "id" TEXT NOT NULL,
    "character" TEXT NOT NULL,
    "kana" TEXT NOT NULL,
    "onyomi" TEXT,
    "kunyomi" TEXT,
    "meaning" TEXT NOT NULL,
    "level" "Level" NOT NULL,
    "stroke_count" INTEGER,
    "created_at" TIMESTAMP(3) NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "updated_at" TIMESTAMP(3) NOT NULL,
    "lesson_id" TEXT,
    "user_bookmarked_id" TEXT,

    CONSTRAINT "kanji_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "vocabulary_kanji" (
    "id" TEXT NOT NULL,
    "position" INTEGER,
    "vocabulary_id" TEXT NOT NULL,
    "kanji_id" TEXT NOT NULL,

    CONSTRAINT "vocabulary_kanji_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "listening" (
    "id" TEXT NOT NULL,
    "level" "Level" NOT NULL,

    CONSTRAINT "listening_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "reading" (
    "id" TEXT NOT NULL,
    "level" "Level" NOT NULL,

    CONSTRAINT "reading_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "media" (
    "id" TEXT NOT NULL,
    "audio" TEXT,
    "image" TEXT,
    "created_at" TIMESTAMP(3) NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "updated_at" TIMESTAMP(3) NOT NULL,
    "vocabulary_id" TEXT,

    CONSTRAINT "media_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "example" (
    "id" TEXT NOT NULL,
    "title" TEXT NOT NULL,
    "description" TEXT NOT NULL,
    "vocabulary_id" TEXT,
    "grammar_id" TEXT,
    "kanji_id" TEXT,

    CONSTRAINT "example_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "test" (
    "id" TEXT NOT NULL,
    "level" "Level" NOT NULL,
    "created_at" TIMESTAMP(3) NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "updated_at" TIMESTAMP(3) NOT NULL,

    CONSTRAINT "test_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "question" (
    "id" TEXT NOT NULL,
    "content" TEXT NOT NULL,
    "level" "Level" NOT NULL,
    "question_type" "QuestionType" NOT NULL,
    "mediaUrl" TEXT,
    "test_id" TEXT NOT NULL,
    "created_at" TIMESTAMP(3) NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "updated_at" TIMESTAMP(3) NOT NULL,

    CONSTRAINT "question_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "choice" (
    "id" TEXT NOT NULL,
    "title" TEXT NOT NULL,
    "point" DOUBLE PRECISION,
    "is_correct" BOOLEAN NOT NULL,
    "question_id" TEXT NOT NULL,
    "created_at" TIMESTAMP(3) NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "updated_at" TIMESTAMP(3) NOT NULL,

    CONSTRAINT "choice_pkey" PRIMARY KEY ("id")
);

-- CreateIndex
CREATE UNIQUE INDEX "user_email_key" ON "user"("email");

-- CreateIndex
CREATE INDEX "lesson_level_idx" ON "lesson"("level");

-- CreateIndex
CREATE INDEX "lesson_source_idx" ON "lesson"("source");

-- CreateIndex
CREATE INDEX "vocabulary_lesson_id_idx" ON "vocabulary"("lesson_id");

-- CreateIndex
CREATE INDEX "grammar_lesson_id_idx" ON "grammar"("lesson_id");

-- CreateIndex
CREATE UNIQUE INDEX "kanji_character_key" ON "kanji"("character");

-- CreateIndex
CREATE INDEX "kanji_lesson_id_idx" ON "kanji"("lesson_id");

-- CreateIndex
CREATE INDEX "vocabulary_kanji_vocabulary_id_idx" ON "vocabulary_kanji"("vocabulary_id");

-- CreateIndex
CREATE INDEX "vocabulary_kanji_kanji_id_idx" ON "vocabulary_kanji"("kanji_id");

-- CreateIndex
CREATE UNIQUE INDEX "vocabulary_kanji_vocabulary_id_kanji_id_key" ON "vocabulary_kanji"("vocabulary_id", "kanji_id");

-- CreateIndex
CREATE INDEX "choice_question_id_idx" ON "choice"("question_id");

-- AddForeignKey
ALTER TABLE "user_bookmarked" ADD CONSTRAINT "user_bookmarked_userId_fkey" FOREIGN KEY ("userId") REFERENCES "user"("id") ON DELETE CASCADE ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "vocabulary" ADD CONSTRAINT "vocabulary_lesson_id_fkey" FOREIGN KEY ("lesson_id") REFERENCES "lesson"("id") ON DELETE SET NULL ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "vocabulary" ADD CONSTRAINT "vocabulary_userBookMarkedId_fkey" FOREIGN KEY ("userBookMarkedId") REFERENCES "user_bookmarked"("userId") ON DELETE SET NULL ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "grammar" ADD CONSTRAINT "grammar_lesson_id_fkey" FOREIGN KEY ("lesson_id") REFERENCES "lesson"("id") ON DELETE SET NULL ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "grammar" ADD CONSTRAINT "grammar_user_bookmarked_id_fkey" FOREIGN KEY ("user_bookmarked_id") REFERENCES "user_bookmarked"("userId") ON DELETE SET NULL ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "kanji" ADD CONSTRAINT "kanji_lesson_id_fkey" FOREIGN KEY ("lesson_id") REFERENCES "lesson"("id") ON DELETE SET NULL ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "kanji" ADD CONSTRAINT "kanji_user_bookmarked_id_fkey" FOREIGN KEY ("user_bookmarked_id") REFERENCES "user_bookmarked"("userId") ON DELETE SET NULL ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "vocabulary_kanji" ADD CONSTRAINT "vocabulary_kanji_vocabulary_id_fkey" FOREIGN KEY ("vocabulary_id") REFERENCES "vocabulary"("id") ON DELETE CASCADE ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "vocabulary_kanji" ADD CONSTRAINT "vocabulary_kanji_kanji_id_fkey" FOREIGN KEY ("kanji_id") REFERENCES "kanji"("id") ON DELETE CASCADE ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "media" ADD CONSTRAINT "media_vocabulary_id_fkey" FOREIGN KEY ("vocabulary_id") REFERENCES "vocabulary"("id") ON DELETE CASCADE ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "example" ADD CONSTRAINT "example_vocabulary_id_fkey" FOREIGN KEY ("vocabulary_id") REFERENCES "vocabulary"("id") ON DELETE SET NULL ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "example" ADD CONSTRAINT "example_grammar_id_fkey" FOREIGN KEY ("grammar_id") REFERENCES "grammar"("id") ON DELETE SET NULL ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "example" ADD CONSTRAINT "example_kanji_id_fkey" FOREIGN KEY ("kanji_id") REFERENCES "kanji"("id") ON DELETE SET NULL ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "question" ADD CONSTRAINT "question_test_id_fkey" FOREIGN KEY ("test_id") REFERENCES "test"("id") ON DELETE CASCADE ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "choice" ADD CONSTRAINT "choice_question_id_fkey" FOREIGN KEY ("question_id") REFERENCES "question"("id") ON DELETE CASCADE ON UPDATE CASCADE;
