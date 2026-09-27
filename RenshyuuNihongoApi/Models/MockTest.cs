using Microsoft.EntityFrameworkCore.Metadata;
using RenshyuuNihongoApi.Enums;
using RenshyuuNihongoApi.Models.Base;

namespace RenshyuuNihongoApi.Models;

public class MockTest :  BaseModel
{
    public Guid Id { get; set; }
    public Level Level { get; set; }
    public DateTime CreatedAt{ get; set; }
    public DateTime UpdatedAt { get; set; }
    
    public ICollection<Question> Questions { get; set; } = new List<Question>();
}
