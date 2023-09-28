using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.SharedKernel.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo? fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo != null)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0)
                {
                    return attributes[0].Description;
                }
            }

            return value.ToString();
        }
    }
}
