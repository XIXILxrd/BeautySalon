namespace BeautySalon.Exceptions
{
    class CustomException : Exception
    {
        public int Value { get; }

        public CustomException(string message, int value)
            : base(message)
        {
            Value = value;
        } 
    }
}
