using System.Collections.Generic;

namespace Nagarro.BookReadingEvent.Shared
{
    public class NagarroSampleValidationResult
    {
        public IList<NagarroSampleValidationFailure> Errors { get; private set; }

        public bool IsValid
        {
            get { return Errors == null || Errors.Count == 0; }
        }

        public NagarroSampleValidationResult(IList<NagarroSampleValidationFailure> failures)
        {
            Errors = failures;
        }

        public NagarroSampleValidationResult()
        {
            Errors = new List<NagarroSampleValidationFailure>();
        }
    }
}
