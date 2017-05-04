using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.LBPusiness.Repository;
using Core.LPBusiness.Domain;
using Core.LPBusiness.Domain.Attachment_Area;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.LPBusiness.InMemory.Repositories;


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
                Event.Create(Guid.NewGuid(), DateTime.Parse("05/05/2029"), new List<Attachment>()
                {
                    Attachment.Create(Attachment.AttachmentType.Photo),
                    Attachment.Create(Attachment.AttachmentType.Video)
                }),
                Event.Create(Guid.NewGuid(), DateTime.Parse("05/05/2030"), new List<Attachment>()
                {
                    Attachment.Create(Attachment.AttachmentType.Photo),
                    Attachment.Create(Attachment.AttachmentType.Video)
                }),
                Event.Create(Guid.NewGuid(), DateTime.Parse("05/05/2015"), new List<Attachment>()),
                Event.Create(Guid.NewGuid(), DateTime.Parse("05/05/2013"), new List<Attachment>())
            });
        }

        [TestMethod]
        public async Task FilterAndExpectTwoEvents()
        {
            IEventRepository eventRepository = new EventRepository();
            Assert.IsTrue((await eventRepository.GetFromTimeAsync(DateTime.UtcNow)).Count() == 2);
        }

        [TestMethod]
        public async Task CreatesAndExpectsFiveEvents()
        {
            IEventRepository eventRepository = new EventRepository();
            await eventRepository.CreateEventAsync(Event.Create(Guid.NewGuid(), DateTime.Parse("05/05/2029"),
                new List<Attachment>()
                {
                        Attachment.Create(Attachment.AttachmentType.Photo),
                        Attachment.Create(Attachment.AttachmentType.Video)
                }));
            Assert.IsTrue((await eventRepository.GetAllAsync()).Count() == 5);
        }
    }
}
