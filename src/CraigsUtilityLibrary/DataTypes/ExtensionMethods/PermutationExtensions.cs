﻿/*
Copyright (c) 2014 <a href="http://www.gutgames.com">James Craig</a>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.*/

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Utilities.DataTypes
{
    /// <summary>
    /// Permutation extensions
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class PermutationExtensions
    {
        /// <summary>
        /// Finds all permutations of the items within the list
        /// </summary>
        /// <typeparam name="T">Object type in the list</typeparam>
        /// <param name="input">Input list</param>
        /// <returns>The list of permutations</returns>
        public static ListMapping<int, T> Permute<T>(this IEnumerable<T> input)
        {
            if (input == null)
                return new ListMapping<int, T>();
            var Current = new List<T>();
            Current.AddRange(input);
            var ReturnValue = new ListMapping<int, T>();
            int Max = (input.Count() - 1).Factorial();
            int CurrentValue = 0;
            for (int x = 0; x < input.Count(); ++x)
            {
                int z = 0;
                while (z < Max)
                {
                    int y = input.Count() - 1;
                    while (y > 1)
                    {
                        T TempHolder = Current[y - 1];
                        Current[y - 1] = Current[y];
                        Current[y] = TempHolder;
                        --y;
                        foreach (T Item in Current)
                            ReturnValue.Add(CurrentValue, Item);
                        ++z;
                        ++CurrentValue;
                        if (z == Max)
                            break;
                    }
                }
                if (x + 1 != input.Count())
                {
                    Current.Clear();
                    Current.AddRange(input);
                    T TempHolder2 = Current[0];
                    Current[0] = Current[x + 1];
                    Current[x + 1] = TempHolder2;
                }
            }
            return ReturnValue;
        }
    }
}