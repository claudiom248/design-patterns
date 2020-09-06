namespace DesignPatterns.Creational.Builder.Builder.Phone
{
    public class ApplePhoneBuilder<T> : PhoneBuilder<T>
        where T : Domain.Phone
    {
        private const string AppleMake = "Apple";

        public ApplePhoneBuilder()
            : base() { }

        public override PhoneBuilder<T> WithMake()
        {
            _phone.Make = AppleMake;
            return this;
        }
    }
}
