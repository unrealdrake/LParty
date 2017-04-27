
namespace Repository.LPBusiness.EF.DataModel
{
    public class Attachment
    {
        public int Id { get; set; }
        public Core.LPBusiness.Domain.Attachment_Area.Attachment.AttachmentType Type { get; set; }
    }
}
