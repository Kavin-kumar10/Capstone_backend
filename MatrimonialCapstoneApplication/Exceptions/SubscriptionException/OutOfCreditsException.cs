namespace MatrimonialCapstoneApplication.Exceptions.SubscriptionException
{
    public class OutOfCreditsException : Exception
    {
        string message;
        public OutOfCreditsException()
        {
            message = "You are out of credits, Please try again tomorrow.";
        }

        public OutOfCreditsException(string? message) : base(message)
        {
            this.message = message;
        }
        public override string Message => message;
    }
}
