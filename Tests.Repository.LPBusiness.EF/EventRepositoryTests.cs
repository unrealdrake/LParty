using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LPBusiness.Domain;
using LPBusiness.Domain.Attachment_Area;
using LPBusiness.Domain.Repository;
using LPBusiness.Repository.InMemory.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LPBusiness.Testing.Repository.InMemory
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
