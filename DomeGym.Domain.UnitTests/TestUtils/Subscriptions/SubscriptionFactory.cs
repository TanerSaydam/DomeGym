using DomeGym.Domain.SubscriptionAggregate;
using DomeGym.Domain.UnitTests.TestConstants;

namespace DomeGym.Domain.UnitTests.TestUtils.SubScriptions;
public static class SubscriptionFactory
{
    public static Subscription CreateSubscription(
        SubscriptionType? subscriptionType = null,
        Guid? adminId = null,
        Guid? id = null)
    {
        return new Subscription(
            subscriptionType ?? Constants.Subscriptions.DefaultSubscriptionType,
            adminId ?? Constants.Admin.Id,
            id ?? Constants.Subscriptions.Id);
    }
}
