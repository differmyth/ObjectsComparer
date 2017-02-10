﻿namespace ObjectsComparer
{
    public class NulableStringsValueComparer: IValueComparer
    {
        public bool Compare(object obj1, object obj2)
        {
            if (obj1 == null)
            {
                obj1 = string.Empty;
            }

            if (obj2 == null)
            {
                obj2 = string.Empty;
            }

            return obj1.Equals(obj2);
        }

        public string ToString(object value)
        {
            return value?.ToString() ?? string.Empty;
        }
    }
}
