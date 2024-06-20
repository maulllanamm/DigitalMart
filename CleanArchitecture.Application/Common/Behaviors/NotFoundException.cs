namespace CleanArchitecture.Application.Common.Behaviors
{
    public class NotFoundException : Exception
    {
        public string[] Errors { get; set; }
        public NotFoundException(string message) : base(message)
        {
        }
        public NotFoundException(string[] errors) : base("Not Found.")
        {
            Errors = errors;
        }
    }
}
