namespace CleanArchitecture.Application.Common.Behaviors
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
