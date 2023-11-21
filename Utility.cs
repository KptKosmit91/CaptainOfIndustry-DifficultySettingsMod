using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DifficultySettingsMod
{
    internal static class Utility
    {
        public static void SetProperty(string propName, object objectInstance, object value)
        {
            PropertyInfo propertyInfo = objectInstance.GetType().GetProperty(propName,
                                                    BindingFlags.SetProperty |
                                                    BindingFlags.Public |
                                                    BindingFlags.NonPublic |
                                                    BindingFlags.Instance);

            if (propertyInfo == null)
            {
                Mafi.Log.Error($"Property Info returned null.\n  propName: {propName}\n  objectOn: {objectInstance}");
                return;
            }

            propertyInfo.SetValue(objectInstance, value);
        }
    }
}
