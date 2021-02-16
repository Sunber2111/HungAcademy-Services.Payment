namespace Application.Status
{
    public class CreateSuccessWithData<T> : StatusAction where T : class
    {
        public T data { get; set; }

        public CreateSuccessWithData(T data, string type = null) : base(200)
        {
            Message = type != null ? $"Tạo {type} thành công" : "Tạo thành công";
            this.data = data;
        }
    }
}