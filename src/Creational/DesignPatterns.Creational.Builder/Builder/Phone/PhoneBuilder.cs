namespace DesignPatterns.Creational.Builder.Builder.Phone
{
    public abstract class PhoneBuilder<T> : IBuilder<T>
        where T : Domain.Phone
    {
        protected T _phone;

        protected PhoneBuilder()
            : base() => _phone = new Domain.Phone() as T;

        public abstract PhoneBuilder<T> WithMake();

        public virtual PhoneBuilder<T> WithModel(string model)
        {
            _phone.Model = model;
            return this;
        }

        public virtual PhoneBuilder<T> WithOs(Domain.Os os)
        {
            _phone.Os = os;
            return this;
        }

        public virtual void Reset() => _phone = new Domain.Phone() as T;

        public virtual T Build() => _phone;
    }
}
