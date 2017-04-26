using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Attachment_Area;
using Domain.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositoryLPBusiness.InMemory.Repositories;


namespace Tests.Repository.LPBusiness.InMemory
{
    [TestClass]
    public class EventRepositoryTests
    {
        [TestInitialize]
        public void SeedEvents()
        {
            EventRepository.FillEvents(new List<Event>()
            {
                Event.Create(Guid.NewGuid(), DateTime.Now, new List<Attachment>()
                {
                    Attachment.Create(Attachment.AttachmentType.Photo),
                    Attachment.Create(Attachment.AttachmentType.Video)
                }),
                Event.Create(Guid.NewGuid(), DateTime.Today, new List<Attachment>()
                {
                    Attachment.Create(Attachment.AttachmentType.Photo),
                    Attachment.Create(Attachment.AttachmentType.Video)
                }),
                Event.Create(Guid.NewGuid(), DateTime.Parse("05/05/2015"), new List<Attachment>()),
                Event.Create(Guid.NewGuid(), DateTime.Parse("05/05/2013"), new List<Attachment>())
            });
        }

        [TestMethod]
        public async Task ExpectTwoEvents()
        {
            IEventRepository eventRepository = new EventRepository();
            Assert.IsTrue((await eventRepository.GetFromTimeAsync(DateTime.UtcNow)).Count() == 2);
        }
}
}
