using SharedKernel.BaseAbstractions;

namespace Domain
{
    public sealed class Settings : ValueObjectBase<Settings>
    {
        public bool AllowedToConnect { get; }

        private Settings(bool allowedToConnect)
        {
            this.AllowedToConnect = allowedToConnect;
        }

        public static Settings Create(bool allowedToConnect)
        {
            return new Settings(allowedToConnect);
        }

        public override bool Equals(Settings otherSettings)
        {
            return this.AllowedToConnect.Equals(otherSettings.AllowedToConnect);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Settings)) return false;

            return this.Equals((Settings) obj);
        }

        public override int GetHashCode()
        {
            return this.AllowedToConnect.GetHashCode();
        }
    }
}
