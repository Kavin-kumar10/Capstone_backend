namespace MatrimonialCapstoneApplication.Exceptions.SubscriptionException
{
    public class NoPremiumSubscriptionException : Exception
    {
        string message;
        public NoPremiumSubscriptionException()
        {
            message = "You're not subscibed to premium. Please subscribe to use the credits.";
        }

        public NoPremiumSubscriptionException(string? message) : base(message)
        {
            this.message = message;
        }
        public override string Message => message;
    }
}
