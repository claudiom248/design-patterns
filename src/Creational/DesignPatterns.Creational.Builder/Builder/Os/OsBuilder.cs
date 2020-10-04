using System.Collections.Generic;

namespace DesignPatterns.Creational.Builder.Builder.Os
{
    public class OsBuilder<T> : IBuilder<T>
        where T : Domain.Os
    {
        private T _os;

        public OsBuilder() => _os = new Domain.Os() as T;

        public OsBuilder<T> WithName(string name)
        {
            _os.Name = name;
            return this;
        }

        public OsBuilder<T> WithVersion(string version)
        {
            _os.Version = version;
            return this;
        }

        public OsBuilder<T> WithApps(IEnumerable<string> apps)
        {
            foreach (var app in apps)
            {
                WithApp(app);
            }

            return this;
        }

        public OsBuilder<T> WithApp(string app)
        {
            _os.Apps ??= new List<string>();

            _os.Apps.Add(app);

            return this;
        }

        public void Reset() => _os = new Domain.Os() as T;

        public T Build() => _os;
    }
}
