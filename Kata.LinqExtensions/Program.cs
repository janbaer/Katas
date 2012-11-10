using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Kata.Linq.Extensions
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    [TestFixture]
    public class LinqExtensionTests
    {
        [Test]
        public void WhereTest()
        {
            // ARRANGE
            var ints = new List<int>() {1, 2, 3, 4, 5, 6};

            // ACT
            var result = ints.Where(i => i > 2 && i < 5);

            // ASSERT
            Assert.NotNull(result);
            ints = new List<int>(result);
            Assert.AreEqual(2, ints.Count);
            Assert.AreEqual(3, ints[0]);
            Assert.AreEqual(4, ints[1]);
        }

        [Test]
        public void SelectTest()
        {
            // ARRANGE
            var persons = new List<Person>()
                              {
                                  new Person() {FirstName = "Max", LastName = "Mustermann"},
                                  new Person() {FirstName = "Clara", LastName = "Musterfrau"}
                              };

            // ACT
            var query = persons.Select(person => person.FirstName);

            // ASSERT
            var firstNames = new List<string>(query);
            Assert.NotNull(query);
            Assert.AreEqual(2, persons.Count);
            Assert.AreEqual("Max", firstNames[0]);
            Assert.AreEqual("Clara", firstNames[1]);
        }

        [Test]
        public void GroupTest()
        {
            // ARRANGE
            var persons = new List<Person>()
                              {
                                  new Person() {FirstName = "Max", LastName = "Zitterbacke"},
                                  new Person() {FirstName = "Fritz", LastName = "Bachmann"},
                                  new Person() {FirstName = "Clara", LastName = "Musterfrau"}
                              };

            // ACT
            var groupedPersons = persons.GroupBy(person => person.LastName.Substring(0,1));

            // ASSERT
            Assert.IsNotNull(groupedPersons);
            List<IGrouping<string, Person>> list = new List<IGrouping<string, Person>>(groupedPersons);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual("Z", list[0].Key);
            Assert.AreEqual("B", list[1].Key);
            Assert.AreEqual("M", list[2].Key);
        }

    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public static class LinqExtensions
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> enumeration, Predicate<T> predicate)
        {
            foreach (var element in enumeration)
            {
                if (predicate(element))
                {
                    yield return element;
                }
            }
        }

        public static IEnumerable<TTarget> Select<TSource, TTarget>(this IEnumerable<TSource> enumeration, Func<TSource, TTarget> func)
        {
            foreach (var element in enumeration)
            {
                yield return func(element);
            }
        }

        public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IEnumerable<TSource> source,Func<TSource, TKey> keySelector)
        {
            ILookup<TKey, TSource> lookup = source.ToLookup(keySelector);

            foreach (var result in lookup)
            {
                yield return result;
            }

        }


    }
}


