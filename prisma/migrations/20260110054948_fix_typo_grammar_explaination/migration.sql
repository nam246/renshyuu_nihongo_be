/*
  Warnings:

  - You are about to drop the column `explanation` on the `grammar` table. All the data in the column will be lost.

*/
-- AlterTable
ALTER TABLE "grammar" DROP COLUMN "explanation",
ADD COLUMN     "explaination" TEXT;
