namespace Application.Status
{
    public class VerifyPaymentSuccess: StatusAction
    {
        public VerifyPaymentSuccess():base(200)
        {
            Message = "Thanh toán thành công - xin mời quý khách vào trải nghiệm khóa học";
        }
    }
}