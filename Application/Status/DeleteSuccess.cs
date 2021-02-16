namespace Application.Status
{
    public class DeleteSuccess : StatusAction
    {
        public DeleteSuccess(string entity = null) : base(200)
        {
            Message = entity != null ? $"Xóa {entity} thành công" : "Xóa thành công";
        }
    }
}