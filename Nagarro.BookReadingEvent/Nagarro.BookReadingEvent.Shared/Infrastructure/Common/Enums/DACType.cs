namespace Nagarro.BookReadingEvent.Shared
{
    /// <summary>
    /// Data Access Component Type
    /// </summary>
    public enum DACType
    {
        /// <summary>
        /// Undefined DAC (Default)
        /// </summary>
        Undefined = 0,

        [QualifiedTypeName("Nagarro.BookReadingEvent.Data.dll", "Nagarro.BookReadingEvent.Data.EventDAC")]
        EventDAC = 1,

        [QualifiedTypeName("Nagarro.BookReadingEvent.Data.dll", "Nagarro.BookReadingEvent.Data.UserDAC")]
        UserDAC = 2,

        [QualifiedTypeName("Nagarro.BookReadingEvent.Data.dll", "Nagarro.BookReadingEvent.Data.BookingEnrollmentDAC")]
        BookingEnrollmentDAC = 3,

        [QualifiedTypeName("Nagarro.BookReadingEvent.Data.dll", "Nagarro.BookReadingEvent.Data.CommentDAC")]
        CommentDAC = 4

    }
}
