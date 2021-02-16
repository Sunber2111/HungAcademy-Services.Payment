using System.Collections.Generic;

namespace Application.Status
{
    public class GetDataSuccess<T> : StatusAction where T : class
    {
        public IEnumerable<T> Data { get; set; }

        public GetDataSuccess(List<T> data) : base(200)
        {
            Message = "Lấy dữ liệu thành công";
            Data = data;
        }

    }
}
