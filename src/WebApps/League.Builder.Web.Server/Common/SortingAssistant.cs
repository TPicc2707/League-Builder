using MudBlazor;
using System.Linq.Expressions;
using System.Reflection;

namespace League.Builder.Web.Server.Common;

public static class SortingAssistant
{
    public static void UpdateOrder<T>(this IEnumerable<T> items, MudItemDropInfo<T> dropInfo, Expression<Func<T, int>> valueUpdater, int zoneOffset = 0)
    {
        if (valueUpdater.Body is not MemberExpression memberSelectorExpression) { throw new InvalidOperationException(); }

        var property = memberSelectorExpression.Member as PropertyInfo;

        if (property == null) { throw new InvalidOperationException(); }

        var newIndex = dropInfo.IndexInZone + zoneOffset;

        var item = dropInfo.Item;

        var index = 1;
        foreach (var _item in items.OrderBy(x => (int)property.GetValue(x)))
        {
            if (_item.Equals(item))
            {
                property.SetValue(item, newIndex);
            }
            else
            {
                if (index == newIndex)
                {
                    index++;
                }

                property.SetValue(_item, index);

                index++;
            }
        }
    }
}
