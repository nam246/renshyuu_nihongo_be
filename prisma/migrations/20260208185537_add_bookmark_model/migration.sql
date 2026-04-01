/*
  Warnings:

  - You are about to drop the column `user_bookmarked_id` on the `grammar` table. All the data in the column will be lost.
  - You are about to drop the column `user_bookmarked_id` on the `kanji` table. All the data in the column will be lost.
  - You are about to drop the column `userBookMarkedId` on the `vocabulary` table. All the data in the column will be lost.
  - You are about to drop the `user_bookmarked` table. If the table is not empty, all the data it contains will be lost.

*/
-- DropForeignKey
ALTER TABLE "grammar" DROP CONSTRAINT "grammar_user_bookmarked_id_fkey";

-- DropForeignKey
ALTER TABLE "kanji" DROP CONSTRAINT "kanji_user_bookmarked_id_fkey";

-- DropForeignKey
ALTER TABLE "user_bookmarked" DROP CONSTRAINT "user_bookmarked_userId_fkey";

-- DropForeignKey
ALTER TABLE "vocabulary" DROP CONSTRAINT "vocabulary_userBookMarkedId_fkey";

-- AlterTable
ALTER TABLE "grammar" DROP COLUMN "user_bookmarked_id";

-- AlterTable
ALTER TABLE "kanji" DROP COLUMN "user_bookmarked_id";

-- AlterTable
ALTER TABLE "vocabulary" DROP COLUMN "userBookMarkedId";

-- DropTable
DROP TABLE "user_bookmarked";

-- CreateTable
CREATE TABLE "bookmark" (
    "id" TEXT NOT NULL,
    "user_id" TEXT NOT NULL,
    "vocabulary_id" TEXT,
    "kanji_id" TEXT,
    "grammar_id" TEXT,
    "created_at" TIMESTAMP(3) NOT NULL DEFAULT CURRENT_TIMESTAMP,

    CONSTRAINT "bookmark_pkey" PRIMARY KEY ("id")
);

-- CreateIndex
CREATE UNIQUE INDEX "bookmark_user_id_vocabulary_id_key" ON "bookmark"("user_id", "vocabulary_id");

-- CreateIndex
CREATE UNIQUE INDEX "bookmark_user_id_kanji_id_key" ON "bookmark"("user_id", "kanji_id");

-- CreateIndex
CREATE UNIQUE INDEX "bookmark_user_id_grammar_id_key" ON "bookmark"("user_id", "grammar_id");

-- AddForeignKey
ALTER TABLE "bookmark" ADD CONSTRAINT "bookmark_user_id_fkey" FOREIGN KEY ("user_id") REFERENCES "user"("id") ON DELETE CASCADE ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "bookmark" ADD CONSTRAINT "bookmark_vocabulary_id_fkey" FOREIGN KEY ("vocabulary_id") REFERENCES "vocabulary"("id") ON DELETE CASCADE ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "bookmark" ADD CONSTRAINT "bookmark_kanji_id_fkey" FOREIGN KEY ("kanji_id") REFERENCES "kanji"("id") ON DELETE CASCADE ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "bookmark" ADD CONSTRAINT "bookmark_grammar_id_fkey" FOREIGN KEY ("grammar_id") REFERENCES "grammar"("id") ON DELETE CASCADE ON UPDATE CASCADE;
