using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Linq;
using System.Windows.Markup;

namespace WpfApplication.Model
{
    class EnumToItem : MarkupExtension
    {
        private readonly Type _type;

        public EnumToItem(Type type)
        {
            _type = type;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _type.GetMembers().SelectMany(t => t.GetCustomAttributes(typeof(DescriptionAttribute),true).Cast<DescriptionAttribute>()).Select(x => x.Description).ToList();
        }
    }

    public enum Status
    {
        [Description("Получена")]
        Received,
        [Description("В работе")]
        InWork,
        [Description("Выполнена")]
        Completed,
        [Description("Отклонена")]
        Rejected,
        [Description("Отменена")]
        Canceled
    }
}
