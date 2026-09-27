namespace RenshyuuNihongoApi.Data;

internal static class SeedData
{
    public static readonly Guid LessonId = Guid.Parse("11111111-1111-1111-1111-111111111111");
    public static readonly Guid VocabularyId = Guid.Parse("22222222-2222-2222-2222-222222222221");
    public static readonly Guid VocabularyId2 = Guid.Parse("22222222-2222-2222-2222-222222222222");
    public static readonly Guid VocabularyId3 = Guid.Parse("22222222-2222-2222-2222-222222222223");
    public static readonly Guid UserId = Guid.Parse("33333333-3333-3333-3333-333333333331");
    public static readonly Guid GrammarId = Guid.Parse("44444444-4444-4444-4444-444444444441");
    public static readonly Guid KanjiId = Guid.Parse("55555555-5555-5555-5555-555555555551");
    public static readonly Guid ExampleId = Guid.Parse("66666666-6666-6666-6666-666666666661");
    public static readonly Guid MockTestId = Guid.Parse("77777777-7777-7777-7777-777777777771");
    public static readonly Guid QuestionId = Guid.Parse("88888888-8888-8888-8888-888888888881");
    public static readonly DateTime Timestamp = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc);
}
