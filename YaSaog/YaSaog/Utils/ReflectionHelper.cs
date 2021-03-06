﻿using System;
using System.Reflection;
using YaSaog.Tweening;

namespace YaSaog.Utils {

    public static class ReflectionHelper {
        public static Assembly ExecutingAssembly = Assembly.GetExecutingAssembly();

        public static Type GetTypeByName(Assembly assembly, string name) {
            var type = assembly.GetType(name, false);

            return type;
        }

        public static Type GetTypeByName(string name) {
            return GetTypeByName(ExecutingAssembly, name);
        }

        public static T CreateInstance<T>(this Type type) {
            T ent = default(T);

            if (type == null) return ent;

            ent = (T)Activator.CreateInstance(type);

            return ent;
        }

        public static void SetProperty(this Type type, object obj, string name, object value) {
            PropertyInfo prop = type.GetProperty(name);
            if (prop != null) {
                prop.SetValue(obj, Convert.ChangeType(value, prop.PropertyType), null);
            }
        }

        public static TweeningFunction GetTweenDelegateByName(string tweenName) {
            var tweenClass = tweenName.Split('.')[0];
            var tweenMethod = tweenName.Split('.')[1];

            var type = ReflectionHelper.GetTypeByName("YaSaog.Tweening." + tweenClass);
            var method = type.GetMethod(tweenMethod);

            return (TweeningFunction)TweeningFunction.CreateDelegate(typeof(TweeningFunction), method);
        }
    }
}