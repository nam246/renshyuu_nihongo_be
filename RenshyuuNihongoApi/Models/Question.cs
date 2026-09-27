using RenshyuuNihongoApi.Enums;
using RenshyuuNihongoApi.Models.Base;

namespace RenshyuuNihongoApi.Models;

public class Question : BaseModel
{
    public required Section Section { get; set; }
    public required string Text { get; set; }
    public required List<string> Answers { get; set; }
    public required string CorrectAnswer { get; set; }

    public Guid? MockTestId { get; set; }
    public MockTest? MockTest { get; set; }
}