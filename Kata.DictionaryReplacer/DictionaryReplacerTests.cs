using System;
using System.Collections.Generic;
using NUnit.Framework;

using dict = System.Collections.Generic.Dictionary<string, string>;

namespace Kata.DictionaryReplacer
{
	[TestFixture()]
	public class WhenStringIsEmpty
	{
		[Test()]
		public void ItShouldReturnEmpty ()
		{
			Assert.AreEqual("", DictionaryReplacer.Replace("", new dict()));
		}
	}

	[TestFixture()]
	public class WhenStringContainsPlaceholders
	{
		[Test()]
		public void AndDictContainsOneMatchingKey_ItShouldBeReplaced ()
		{
			Assert.AreEqual("AAA is a brown fox", DictionaryReplacer.Replace("$a$ is a brown fox", new dict(){{"a", "AAA"}}));
		}

		[Test()]
		public void AndDictContainsOneMatchingKeyTwice_ItShouldBothReplaced ()
		{
			Assert.AreEqual("AAA is a AAA fox", DictionaryReplacer.Replace("$a$ is a $a$ fox", new dict(){{"a", "AAA"}}));
		}

		[Test()]
		public void AndDictContainsMultipleMatchinKeysItShouldAllBeReplaced ()
		{
			Assert.AreEqual("AAA is a BBB and also a CCC", DictionaryReplacer.Replace("$a$ is a $b$ and also a $c$", 
			                                                                          new dict() {
																									{"a", "AAA"}, {"b", "BBB"}, {"c", "CCC"}
																								 }));
		}

		[Test()]
		public void AndDictContainsNoMatchingKeys_ItShouldReturnsTheOriginalString ()
		{
			Assert.AreEqual("$a$ is a quick brown fox", DictionaryReplacer.Replace("$a$ is a quick brown fox", new dict() {{"b", "BBB"}}));
		}
	}

	[TestFixture()]
	public class WhenStringContainsLowerCasePlaceholders
	{
		[Test()]
		public void AndDictContainsUpperCaseMatchingKeys_ItShouldReplaceAll ()
		{
			Assert.AreEqual("AAA is a quick brown fox", DictionaryReplacer.Replace("$a$ is a quick brown fox", new dict() {{"A", "AAA"}}));
		}
	}


}

