using Prism.Events;
using QSANN.Data.Entities;

namespace QSANN.Core.Events
{
    public class ConcreteOtherCategoryCalculatedEvent : PubSubEvent<ConcreteOtherCategoryCalculatedEventPayload>
    {
    }

    public class ConcreteOtherCategoryCalculatedEventPayload
    {
        public string SpecificationName { get; set; }
        public ConcreteOtherOutput Output { get; set; }
    }
}