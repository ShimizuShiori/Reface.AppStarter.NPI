using Reface.EventBus;
using Reface.NPI.Generators;

namespace Reface.AppStarter.NPI.Events
{
    public class SqlCommandDescriptionGeneratedEvent : Event
    {
        public SqlCommandDescription SqlCommandDescription { get; private set; }
        public SqlCommandDescriptionGeneratedEvent(object source, SqlCommandDescription sqlCommandDescription) : base(source)
        {
            this.SqlCommandDescription = sqlCommandDescription;
        }
    }
}
