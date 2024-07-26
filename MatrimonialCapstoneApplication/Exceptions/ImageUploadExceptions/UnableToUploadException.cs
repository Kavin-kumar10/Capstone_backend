namespace MatrimonialCapstoneApplication.Exceptions.ImageUploadExceptions
{
    [Serializable]
    public class UnableToUploadException : Exception
    {
        string message;
        public UnableToUploadException()
        {
            message = "Unable to Upload the images";
        }

        public UnableToUploadException(string? message) : base(message)
        {
            this.message = message;
        }
        public override string Message => message;
    }
}
