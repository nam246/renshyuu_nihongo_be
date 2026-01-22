import {
  Prisma,
  Level,
  WordType,
  Source,
} from '../src/generated/prisma/client';

export const lessonsData: Prisma.LessonCreateInput[] = [
  // Lesson 1 - N5 Minna no Nihongo
  {
    lessonTitle: '1',
    source: Source.MINNA_NO_NIHONGO,
    level: Level.N5,
    vocabularies: {
      create: [
        {
          word: '学生',
          kana: 'がくせい',
          romaji: 'gakusei',
          meaning: 'Học sinh, sinh viên',
          wordType: WordType.NOUN,
          level: Level.N5,
          examples: {
            create: [
              {
                title: '私は大学の学生です。',
                description: 'Tôi là sinh viên đại học.',
              },
              {
                title: 'あの学生は日本人です。',
                description: 'Học sinh kia là người Nhật.',
              },
            ],
          },
        },
        {
          word: '食べる',
          kana: 'たべる',
          romaji: 'taberu',
          meaning: 'Ăn',
          wordType: WordType.VERB,
          level: Level.N5,
          examples: {
            create: [
              {
                title: '朝ごはんを食べます。',
                description: 'Tôi ăn cơm sáng.',
              },
              {
                title: '何を食べたいですか。',
                description: 'Bạn muốn ăn gì?',
              },
            ],
          },
        },
        {
          word: '静か',
          kana: 'しずか',
          romaji: 'shizuka',
          meaning: 'Yên tĩnh',
          wordType: WordType.NA_ADJECTIVE,
          level: Level.N5,
          examples: {
            create: [
              {
                title: '図書館は静かです。',
                description: 'Thư viện yên tĩnh.',
              },
              {
                title: '静かな場所が好きです。',
                description: 'Tôi thích nơi yên tĩnh.',
              },
            ],
          },
        },
        {
          word: '勉強',
          kana: 'べんきょう',
          romaji: 'benkyou',
          meaning: 'Học tập',
          wordType: WordType.NOUN,
          level: Level.N5,
          examples: {
            create: [
              {
                title: '毎日日本語の勉強をします。',
                description: 'Mỗi ngày tôi học tiếng Nhật.',
              },
              {
                title: '勉強が好きです。',
                description: 'Tôi thích học.',
              },
            ],
          },
        },
      ],
    },
    grammars: {
      create: [
        {
          pattern: '〜ます',
          structure: '動詞ます形',
          meaning: 'Thể lịch sự của động từ',
          explaination:
            'Dùng để diễn đạt hành động một cách lịch sự, trang trọng',
          notes: 'Thể cơ bản trong giao tiếp hàng ngày',
          level: Level.N5,
          examples: {
            create: [
              {
                title: '私は毎日日本語を勉強します。',
                description: 'Tôi học tiếng Nhật mỗi ngày.',
              },
              {
                title: '明日学校に行きます。',
                description: 'Mai tôi đi học.',
              },
            ],
          },
        },
        {
          pattern: '〜ません',
          structure: '動詞ます形 + ません',
          meaning: 'Phủ định lịch sự của động từ',
          explaination: 'Dùng để phủ định hành động một cách lịch sự',
          notes: 'Thể phủ định của ます',
          level: Level.N5,
          examples: {
            create: [
              {
                title: '今日は働きません。',
                description: 'Hôm nay tôi không làm việc.',
              },
              {
                title: '肉を食べません。',
                description: 'Tôi không ăn thịt.',
              },
            ],
          },
        },
        {
          pattern: '〜ました',
          structure: '動詞ます形 + ました',
          meaning: 'Thể quá khứ lịch sự',
          explaination: 'Diễn đạt hành động đã xảy ra trong quá khứ',
          notes: 'Quá khứ của ます',
          level: Level.N5,
          examples: {
            create: [
              {
                title: '昨日映画を見ました。',
                description: 'Hôm qua tôi đã xem phim.',
              },
              {
                title: '先週京都に行きました。',
                description: 'Tuần trước tôi đã đi Kyoto.',
              },
            ],
          },
        },
      ],
    },
    kanjis: {
      create: [
        {
          character: '日',
          kana: 'ひ / にち',
          onyomi: 'ニチ, ジツ',
          kunyomi: 'ひ, び, か',
          meaning: 'Ngày, mặt trời',
          level: Level.N5,
          strokeCount: 4,
          examples: {
            create: [
              {
                title: '毎日日本語を勉強します。',
                description: 'Tôi học tiếng Nhật mỗi ngày.',
              },
              {
                title: '日曜日は休みです。',
                description: 'Chủ nhật là ngày nghỉ.',
              },
            ],
          },
        },
        {
          character: '人',
          kana: 'ひと',
          onyomi: 'ジン, ニン',
          kunyomi: 'ひと',
          meaning: 'Người',
          level: Level.N5,
          strokeCount: 2,
          examples: {
            create: [
              {
                title: 'あの人は先生です。',
                description: 'Người kia là giáo viên.',
              },
              {
                title: '日本人です。',
                description: 'Tôi là người Nhật.',
              },
            ],
          },
        },
      ],
    },
  },

  // Lesson 2 - N5 Minna no Nihongo
  {
    lessonTitle: '2',
    source: Source.MINNA_NO_NIHONGO,
    level: Level.N5,
    vocabularies: {
      create: [
        {
          word: '美しい',
          kana: 'うつくしい',
          romaji: 'utsukushii',
          meaning: 'Đẹp',
          wordType: WordType.I_ADJECTIVE,
          level: Level.N4,
          examples: {
            create: [
              {
                title: '富士山は美しいです。',
                description: 'Núi Phú Sĩ thật đẹp.',
              },
              {
                title: '美しい景色を見ました。',
                description: 'Tôi đã xem phong cảnh đẹp.',
              },
            ],
          },
        },
      ],
    },
    grammars: {
      create: [
        {
          pattern: '〜たい',
          structure: '動詞ます形 + たい',
          meaning: 'Muốn làm gì đó',
          explaination: 'Diễn đạt mong muốn, ước muốn của bản thân',
          notes: 'Chỉ dùng cho người nói (ngôi thứ nhất)',
          level: Level.N5,
          examples: {
            create: [
              {
                title: '日本に行きたいです。',
                description: 'Tôi muốn đi Nhật.',
              },
              {
                title: 'ラーメンが食べたいです。',
                description: 'Tôi muốn ăn ramen.',
              },
            ],
          },
        },
        {
          pattern: '〜てください',
          structure: '動詞て形 + ください',
          meaning: 'Xin hãy làm gì đó (nhờ vả, yêu cầu)',
          explaination:
            'Dùng để nhờ vả hoặc yêu cầu ai đó làm điều gì đó một cách lịch sự',
          notes: 'Câu mệnh lệnh lịch sự',
          level: Level.N5,
          examples: {
            create: [
              {
                title: 'ちょっと待ってください。',
                description: 'Xin hãy đợi một chút.',
              },
              {
                title: '窓を開けてください。',
                description: 'Xin hãy mở cửa sổ.',
              },
            ],
          },
        },
      ],
    },
    kanjis: {
      create: [
        {
          character: '学',
          kana: 'まな',
          onyomi: 'ガク',
          kunyomi: 'まな',
          meaning: 'Học',
          level: Level.N5,
          strokeCount: 8,
          examples: {
            create: [
              {
                title: '日本語を学びます。',
                description: 'Tôi học tiếng Nhật.',
              },
              {
                title: '大学で勉強しています。',
                description: 'Tôi đang học ở đại học.',
              },
            ],
          },
        },
      ],
    },
  },

  // Lessons 3-25 (N5) - Template trống
  ...Array.from({ length: 23 }, (_, i) => ({
    lessonTitle: String(i + 3),
    source: Source.MINNA_NO_NIHONGO,
    level: Level.N5,
    vocabularies: { create: [] },
    grammars: { create: [] },
    kanjis: { create: [] },
  })),

  // Lessons 26-50 (N4) - Template trống
  ...Array.from({ length: 25 }, (_, i) => ({
    lessonTitle: String(i + 26),
    source: Source.MINNA_NO_NIHONGO,
    level: Level.N4,
    vocabularies: { create: [] },
    grammars: { create: [] },
    kanjis: { create: [] },
  })),

  // Lessons 51-55 (N3 Soumatome) - Template trống
  ...Array.from({ length: 5 }, (_, i) => ({
    lessonTitle: String(i + 51),
    source: Source.SOUMATOME,
    level: Level.N3,
    vocabularies: { create: [] },
    grammars: { create: [] },
    kanjis: { create: [] },
  })),

  // Lessons 56-60 (N2 Soumatome) - Template trống
  ...Array.from({ length: 5 }, (_, i) => ({
    lessonTitle: String(i + 56),
    source: Source.SOUMATOME,
    level: Level.N2,
    vocabularies: { create: [] },
    grammars: { create: [] },
    kanjis: { create: [] },
  })),

  // Lessons 61-65 (N1 Soumatome) - Template trống
  ...Array.from({ length: 5 }, (_, i) => ({
    lessonTitle: String(i + 61),
    source: Source.SOUMATOME,
    level: Level.N1,
    vocabularies: { create: [] },
    grammars: { create: [] },
    kanjis: { create: [] },
  })),
];
