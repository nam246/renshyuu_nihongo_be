using System.Text.Json.Serialization;

namespace RenshyuuNihongoApi.Enums;

// [Tùy chọn] Nếu bạn muốn API trả về chữ "N5", "N4"... thay vì số 1, 2, 3...
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Level
{
    // Bắt buộc nên gán giá trị số cụ thể (Explicit Values)
    // Để tránh lỗi sai lệch data trong DB nếu sau này bạn đổi thứ tự dòng
    N5 = 5,
    N4 = 4,
    N3 = 3,
    N2 = 2,
    N1 = 1
    
    // Lưu ý: Có thể thêm giá trị mặc định nếu cần
    // None = 0
}
