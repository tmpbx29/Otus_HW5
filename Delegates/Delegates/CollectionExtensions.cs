﻿namespace Delegates
{
    public static class CollectionExtensions
    {
        public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));
            
            if (convertToNumber == null)
                throw new ArgumentNullException(nameof(convertToNumber));

            T maxItem = null;
            float maxValue = float.MinValue;

            foreach (var item in collection)
            {
                if (item == null) 
                    continue;

                float value = convertToNumber(item);
                if (maxItem == null || value > maxValue)
                {
                    maxValue = value;
                    maxItem = item;
                }
            }
            return maxItem;
        }
    }
}