namespace MatrimonialCapstoneApplication.Models
{
    public class ErrorModel
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }

        public ErrorModel(int ErrorCode, string Message)
        {
            this.ErrorCode = ErrorCode;
            this.Message = Message;
        }
    }
}
