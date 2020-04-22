using Reface.EventBus;
using Reface.NPI.Generators;

namespace Reface.AppStarter.NPI.Events
{
    /// <summary>
    /// 当 <see cref="SqlCommandDescription"/> 生成后的事件
    /// </summary>
    public class SqlCommandDescriptionGeneratedEvent : Event
    {
        /// <summary>
        /// 生成出的 <see cref="SqlCommandDescription"/>
        /// </summary>
        public SqlCommandDescription SqlCommandDescription { get; private set; }
        public SqlCommandDescriptionGeneratedEvent(object source, SqlCommandDescription sqlCommandDescription) : base(source)
        {
            this.SqlCommandDescription = sqlCommandDescription;
        }
    }
}
