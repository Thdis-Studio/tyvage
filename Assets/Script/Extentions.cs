﻿using System.Collections.Generic;
using System.Linq;

public static partial class Extensions
{
    /// <summary>
    ///     A string extension method that replace first occurence.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <param name="oldValue">The old value.</param>
    /// <param name="newValue">The new value.</param>
    /// <returns>The string with the first occurence of old value replace by new value.</returns>
    public static string ReplaceFirst(this string @this, string oldValue, string newValue)
    {
        int startindex = @this.IndexOf(oldValue);

        if (startindex == -1)
        {
            return @this;
        }

        return @this.Remove(startindex, oldValue.Length).Insert(startindex, newValue);
    }

    /// <summary>
    ///     A string extension method that replace first number of occurences.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <param name="number">Number of.</param>
    /// <param name="oldValue">The old value.</param>
    /// <param name="newValue">The new value.</param>
    /// <returns>The string with the numbers of occurences of old value replace by new value.</returns>
    public static string ReplaceFirst(this string @this, int number, string oldValue, string newValue)
    {
        List<string> list = @this.Split(System.Convert.ToChar(oldValue)).ToList();
        int old = number + 1;
        IEnumerable<string> listStart = list.Take(old);
        IEnumerable<string> listEnd = list.Skip(old);

        return string.Join(newValue, listStart) +
               (listEnd.Any() ? oldValue : "") +
               string.Join(oldValue, listEnd);
    }
}