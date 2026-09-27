namespace RenshyuuNihongoApi.Services.MockTest;

public interface IMockTestService
{
    // Duyệt tất cả để thi đã tạo
    Task FindAllAsync(CancellationToken cancellationToken);
    // Chi tiết đề thi
    Task FindByIdAsync(Guid id, CancellationToken cancellationToken);
    // Generate đề thi từ ngân haàng câu hỏi
    Task CreateAsync();
    // Duyệt tất cả ngân hàng câu hỏi
    Task FindAllQuestionAsync(CancellationToken cancellationToken);
    // Chi tiet cau hoi
    Task FindQuestionByIdAsync(Guid id, CancellationToken cancellationToken);
    // Thêm Câu hỏi vào ngân hang` cau hoi bao gồm (Câu hỏi thuộc phần nào? Nội dung câu hỏi, Đáp án)
    Task AddQuestionAsync();
    Task EditQuestionAsync();
    Task DeleteQuestionAsync();
}