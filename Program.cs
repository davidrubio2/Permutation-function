﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Permutation_function
{
    class Program
    {
        static void Main(string[] args)
        {
            Permutatuins(new List<int> {4, 5, 9, 13, 1, 10} ,2,14);
        }
        static void Permutatuins(List<int> numbers, int operandos, int objetivo)
        {
            var list = numbers.ConvertAll<string>(delegate(int i) { return i.ToString(); });
            var result = GetPermutations(list, operandos);
            int numeroObjetivo = objetivo;
            int numeroVariable = 0;
            string listadelnumero = "";
            string numero = "";
            foreach (var perm in result)
            {
                foreach (var c in perm)
                {
                    numero = numero + " + " + c;
                    numeroVariable = Convert.ToInt16(c) + numeroVariable;
                    listadelnumero = listadelnumero + " , " + c;
                }
                if (numeroVariable == numeroObjetivo)
                {
                    numero = numero.Substring(3, numero.Length - 3);
                    listadelnumero = listadelnumero.Substring(3, listadelnumero.Length - 3);
                    listadelnumero = listadelnumero + " ( " + numero + " = " + numeroVariable + " )";
                    Console.Write(listadelnumero);
                    Console.WriteLine();
                }
                listadelnumero = "";
                numero = "";
                numeroVariable = 0;
            }
        }
        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> items, int count)
        {
            int i = 0;
            foreach (var item in items)
            {
                if (count == 1)
                    yield return new T[] { item };
                else
                {
                    foreach (var result in GetPermutations(items.Skip(i + 1), count - 1))
                        yield return new T[] { item }.Concat(result);
                }

                ++i;
            }
        }
    }
}
