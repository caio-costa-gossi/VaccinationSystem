namespace VaccinationSystem.Application.Common.Exceptions
{
    internal class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message)
            : base(message) { }
    }
}
