namespace Nagarro.BookReadingEvent.Shared
{
    /// <summary>
    /// Business Domain Component Type
    /// </summary>
    public enum BDCType
    {
        /// <summary>
        /// Undefined BDC (Default)
        /// </summary>
        Undefined = 0,

        [QualifiedTypeName("Nagarro.BookReadingEvent.Business.dll", "Nagarro.BookReadingEvent.Business.EventBDC")]
        EventBDC = 1,

        [QualifiedTypeName("Nagarro.BookReadingEvent.Business.dll", "Nagarro.BookReadingEvent.Business.UserBDC")]
        UserBDC = 2,

        [QualifiedTypeName("Nagarro.BookReadingEvent.Business.dll", "Nagarro.BookReadingEvent.Business.BookingEnrollmentBDC")]
        BookingEnrollmentBDC = 3,

        [QualifiedTypeName("Nagarro.BookReadingEvent.Business.dll", "Nagarro.BookReadingEvent.Business.CommentBDC")]
        CommentBDC = 4


    }
}
