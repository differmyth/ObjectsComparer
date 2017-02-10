﻿using System;

namespace ObjectsComparer
{
    public class DynamicValueComparer<T>: IValueComparer
    {
        private readonly Func<T, T, bool> _compareFunction;
        private readonly Func<T, string> _toStringFunction;

        public DynamicValueComparer(Func<T, T, bool> compareFunction, Func<T, string> toStringFunction)
        {
            if (compareFunction == null)
            {
                throw new ArgumentNullException(nameof(compareFunction));
            }

            if (toStringFunction == null)
            {
                throw new ArgumentNullException(nameof(toStringFunction));
            }

            _compareFunction = compareFunction;
            _toStringFunction = toStringFunction;
        }

        public bool Compare(object obj1, object obj2)
        {
            IsArgumentException(obj1, nameof(obj1));
            IsArgumentException(obj2, nameof(obj2));

            return _compareFunction((T)obj1, (T)obj2);
        }

        public string ToString(object value)
        {
            IsArgumentException(value, nameof(value));

            return _toStringFunction((T)value);
        }

        // ReSharper disable once UnusedParameter.Local
        private void IsArgumentException(object obj, string argumentName)
        {
            if (!(obj is T) && !(typeof(T).IsClass && obj == null))
            {
                throw new ArgumentException(argumentName);
            }
        }
    }
}
