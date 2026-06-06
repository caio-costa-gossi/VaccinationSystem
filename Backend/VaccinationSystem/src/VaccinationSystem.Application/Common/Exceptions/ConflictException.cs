namespace VaccinationSystem.Application.Common.Exceptions
{
    internal class ConflictException : Exception
    {
        public ConflictException(string message)
            : base(message) { }
    }
}
