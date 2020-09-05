namespace DesignPatterns.Creational.Builder.Builder.Phone
{
    public class XiaomiPhoneBuilder<T> : PhoneBuilder<T>
        where T : Domain.Phone
    {
        private const string AppleMake = "Xiaomi";

        public XiaomiPhoneBuilder()
            : base() { }

        public override PhoneBuilder<T> Make()
        {
            _phone.Make = AppleMake;
            return this;
        }
    }
}
