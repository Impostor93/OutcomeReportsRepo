namespace OutcomeReports.ApplicationService
{
    using System;

    public class GetPeriodByIdRequest : RequestBase
    {
        public GetPeriodByIdRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
