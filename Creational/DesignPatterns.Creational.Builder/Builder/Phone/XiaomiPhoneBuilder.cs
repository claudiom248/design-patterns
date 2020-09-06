namespace DesignPatterns.Creational.Builder.Builder.Phone
{
    public class XiaomiPhoneBuilder<T> : PhoneBuilder<T>
        where T : Domain.Phone
    {
        private const string XiaomiMake = "Xiaomi";

        public XiaomiPhoneBuilder()
            : base() { }

        public override PhoneBuilder<T> Make()
        {
            _phone.Make = XiaomiMake;
            return this;
        }
    }
}
