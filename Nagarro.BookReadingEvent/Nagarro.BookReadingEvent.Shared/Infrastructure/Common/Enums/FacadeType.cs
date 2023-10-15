namespace Nagarro.BookReadingEvent.Shared
{
    /// <summary>
    /// The Facade Types
    /// </summary>
    public enum FacadeType
    {
        /// <summary>
        /// Undefined Facade Type (Default)
        /// </summary>
        Undefined = 0,


        [QualifiedTypeName("Nagarro.BookReadingEvent.BusinessFacades.dll", "Nagarro.BookReadingEvent.BusinessFacades.EventFacade")]
        EventFacade = 1,

        [QualifiedTypeName("Nagarro.BookReadingEvent.BusinessFacades.dll", "Nagarro.BookReadingEvent.BusinessFacades.UserFacade")]
        UserFacade = 2,

        [QualifiedTypeName("Nagarro.BookReadingEvent.BusinessFacades.dll", "Nagarro.BookReadingEvent.BusinessFacades.BookingEnrollmentFacade")]
        BookingEnrollment = 3,

        [QualifiedTypeName("Nagarro.BookReadingEvent.BusinessFacades.dll", "Nagarro.BookReadingEvent.BusinessFacades.CommentFacade")]
        CommentFacade = 4




    }
}
