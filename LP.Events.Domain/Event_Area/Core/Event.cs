using System;
using LP.Events.Domain.Event_Area.Core.Validators;
using SharedKernel.BaseAbstractions;

namespace LP.Events.Domain.Event_Area.Core
{
    public sealed class Event : EntityBase<int>, IAggregateRoot
    {
        #region [PROPS]
        private int _creatorId;
        public int CreatorId
        {
            get => _creatorId;
            private set { EnsureIsValid(new ReporterValidator(), value, "CreatorId"); _creatorId = value; }
        }

        private DateTime _date;
        public DateTime Date
        {
            get => _date;
            private set { EnsureIsValid(new DateValidator(), value, "Date"); _date = value; }
        }

        private string _title;
        public string Title
        {
            get => _title;
            private set { EnsureIsValid(new TitleValidator(), value, "Title"); _title = value; }
        }
        #endregion

        private Event() { }
        private Event(int creatorId, DateTime date, string title)
        {
            CreatorId = creatorId;
            Date = date;
            Title = title;
        }

        public static class Factory
        {
            public static Event Create(int creatorId, DateTime date, string title)
            {
                return new Event(creatorId, date, title);
            }
        }
    }
}
