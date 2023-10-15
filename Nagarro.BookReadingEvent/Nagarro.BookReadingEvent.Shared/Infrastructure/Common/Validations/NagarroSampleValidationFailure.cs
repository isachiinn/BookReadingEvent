namespace Nagarro.BookReadingEvent.Shared
{
    public class NagarroSampleValidationFailure
    {
        public object AttemptedValue { get; private set; }
        public object CustomState { get; set; }
        public string ErrorMessage { get; private set; }
        public string PropertyName { get; set; }

        public NagarroSampleValidationFailure(string propertyName, string error)
        {
            PropertyName = propertyName;
            ErrorMessage = error;
        }

        public NagarroSampleValidationFailure(string propertyName, string error, object attemptedValue)
        {
            PropertyName = propertyName;
            ErrorMessage = error;
            AttemptedValue = attemptedValue;
        }
    }
}
