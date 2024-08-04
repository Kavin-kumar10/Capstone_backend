namespace MatrimonialCapstoneApplication.Exceptions.LikeDuplicateExceptions
{
    public class LikeDuplicateException : Exception
    {
        string message;
        public LikeDuplicateException()
        {
            message = "Like already found.";
        }

        public LikeDuplicateException(string? message) : base(message)
        {
            this.message = message;
        }
        public override string Message => message;
    }
}
