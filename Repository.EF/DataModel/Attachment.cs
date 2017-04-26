
namespace RepositoryLPBusiness.EF.DataModel
{
    public class Attachment
    {
        public int Id { get; set; }
        public Domain.Attachment_Area.Attachment.AttachmentType Type { get; set; }
    }
}
