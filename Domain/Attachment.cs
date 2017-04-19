using SharedKernel.Domain;

namespace Domain
{
    public sealed class Attachment : ValueObjectBase<Attachment>
    {
        public AttachmentType Type { get; }

        private Attachment(AttachmentType attachmentType)
        {
            this.Type = attachmentType;
        }

        public static Attachment Create(AttachmentType attachmentType)
        {
            return new Attachment(attachmentType);
        }

        public override bool Equals(Attachment otherSettings)
        {
            return this.Type.Equals(otherSettings.Type);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Attachment)) return false;

            return this.Equals((Attachment)obj);
        }

        public override int GetHashCode()
        {
            return this.Type.GetHashCode();
        }


        public enum AttachmentType
        {
            Photo,
            Video
        }
    }
}

