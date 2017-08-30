using System;
using System.Collections.Generic;
using UnityEngine;

namespace Extensions
{
    public static class ListExtenstions
    {
        public static void AddMultiple<T>(this List<T> list, params T[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                list.Add(elements[i]);
            }
        }

        public static T Random<T>(this List<T> list)
        {
            if (list.Count == 0)
            {
                return default(T);
            }
            return list[UnityEngine.Random.Range(0, list.Count)];
        }

        public static List<T> Random<T>(this List<T> list, int count)
        {
            if (list.Count == 0)
            {
                return null;
            }
            if (list.Count < count)
            {
                Debug.LogError("Requested count is higher than List count! Requested: " + count + ", List: " + list.Count);
                return null;
            }
            List<T> candidates = new List<T>();
            candidates.AddRange(list);
            List<T> results = new List<T>();
            for (int i = 0; i < count; i++)
            {
                T element = candidates.Random();
                candidates.Remove(element);
                results.Add(element);
            }
            return results;

        }

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            System.Random rnd = new System.Random();
            while (n > 1)
            {
                int k = (rnd.Next(0, n) % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static string ToString<T>(this List<T> list)
        {
            System.Text.StringBuilder log = new System.Text.StringBuilder();
            foreach (T e in list)
            {
                log.Append(e);
                log.Append(",");
                log.AppendLine();
            }
            return log.ToString();
        }

        public static List<T> DeepCopy<T>(this List<T> list) where T : ICloneable
        {
            List<T> copy = new List<T>();
            foreach (T e in list)
            {
                copy.Add((T)e.Clone());
            }
            return copy;
        }


    }
}
