﻿using System;
using System.Collections.Generic;
using SharedKernel.BaseAbstractions;

namespace Domain
{
    public sealed class Event: EntityBase<Guid>
    {
        public DateTime DateTime { get; }
        public IReadOnlyCollection<Attachment> Attachments { get; }

        private Event(Guid id, DateTime datetime, List<Attachment> attachments) : base(id)
        {
            this.DateTime = datetime;
            this.Attachments = attachments.AsReadOnly() ?? throw new ArgumentException(nameof(attachments));
        }

        public static Event Create(Guid id, DateTime dateTime, List<Attachment> attachments)
        {
            return new Event(id, dateTime, attachments);
        }
    }
}