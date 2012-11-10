using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata.LinkedList
{
    [TestClass]
    public class LinkedListTests
    {
        private LinkedList<int> testList;

        public TestContext TestContext { get; set; }

        [TestInitialize()]
        public void MyTestInitialize()
        {
            testList = new LinkedList<int>();
        }

        #region Count Tests

        [TestMethod]
        public void When_List_IsEmpty_Count_Should_Return_Zero()
        {
            var linkedList = new LinkedList<int>();
            Assert.AreEqual(0, linkedList.Count);
        }

        #endregion

        #region AddItem Tests

        [TestMethod]
        public void When_AddTwoItems_Count_Should_Return_Two()
        {
            // ARRANGE
            testList.Add(1);
            testList.Add(2);

            // ACT
            int count = testList.Count;

            // ASSERT
            Assert.AreEqual(2, testList.Count);
        }

        /// <summary></summary>
        [TestMethod]
        [Description("")]
        public void When_Clear_Count_Should_Return_Zero()
        {
            // ARRANGE
            testList.Add(1);

            // ACT
            testList.Clear();

            // ASSERT
            Assert.AreEqual(0, testList.Count);

        }

        #endregion

        #region IndexOf Tests

        /// <summary></summary>
        [TestMethod]
        [Description("")]
        public void When_List_IsEmpty_IndexOf_Should_Return_Neg1()
        {
            // ARRANGE

            // ACT
            var index = testList.IndexOf(1);

            // ASSERT
            Assert.AreEqual(-1, index);

        }

        /// <summary></summary>
        [TestMethod]
        [Description("")]
        public void When_Item_IsNotInList_IndexOf_Should_Return_Neg1()
        {
            // ARRANGE
            testList.Add(1);
            testList.Add(2);

            // ACT
            int index = testList.IndexOf(3);

            // ASSERT
            Assert.AreEqual(-1, index);

        }

        /// <summary></summary>
        [TestMethod]
        [Description("")]
        public void When_Item_IsInList_IndexOf_Should_CorrectIndex()
        {
            // ARRANGE
            testList.Add(1);
            testList.Add(2);

            // ACT
            int index = testList.IndexOf(2);

            // ASSERT
            Assert.AreEqual(1, index);

        }



        #endregion IndexOf Tests

        #region Contains Tests

        /// <summary></summary>
        [TestMethod]
        [Description("")]
        public void When_Item_IsEmpty_Contains_Returns_False()
        {
            // ARRANGE


            // ACT
            var result = testList.Contains(1);

            // ASSERT
            Assert.IsFalse(result);

        }

        /// <summary></summary>
        [TestMethod]
        [Description("")]
        public void When_Item_IsNotInList_Contains_Should_Return_False()
        {
            // ARRANGE
            testList.Add(1);
            testList.Add(2);

            // ACT
            var result = testList.Contains(3);

            // ASSERT
            Assert.IsFalse(result);

        }

        /// <summary></summary>
        [TestMethod]
        [Description("")]
        public void When_Item_IsInList_Contains_Should_Return_True()
        {
            // ARRANGE
            testList.Add(1);
            testList.Add(2);

            // ACT
            var result = testList.Contains(2);

            // ASSERT
            Assert.IsTrue(result);

        }

        #endregion

        #region Insert Test

        /// <summary></summary>
        [TestMethod]
        public void When_List_IsEmpty_Insert_Should_Should_Insert_Item_At_First_Position()
        {
            // ARRANGE

            // ACT
            testList.Insert(0, 1);

            // ASSERT
            Assert.AreEqual(0, testList.IndexOf(1));

        }

        /// <summary></summary>
        [TestMethod]
        [Description("")]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void When_List_IsEmpty_And_Index_IsGreater_Zero_Insert_Should_Throw_AnException()
        {
            // ARRANGE

            // ACT
            testList.Insert(1, 1);

            // ASSERT

        }

        /// <summary></summary>
        [TestMethod]
        [Description("")]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void When_Index_IsGreaterEquals_Count_Insert_Should_Throw_An_Exception()
        {
            // ARRANGE
            testList.Add(1);
            testList.Add(2);

            // ACT
            testList.Insert(2, 3);

            // ASSERT

        }

        /// <summary></summary>
        [TestMethod]
        [Description("")]
        public void When_Insert_At_FirstPosition_It_Should_Insert__Oncorrect_Position()
        {
            // ARRANGE
            testList.Add(2);
            testList.Add(3);

            // ACT
            testList.Insert(0, 1);

            // ASSERT
            testList.IndexOf(1).Should().Be(0);

        }

        /// <summary></summary>
        [TestMethod]
        [Description("")]
        public void When_Index_Is_Less_Count_Insert_Should_Insert_On_CorrectPosition()
        {
            // ARRANGE
            testList.Add(1);
            testList.Add(3);

            // ACT
            testList.Insert(1, 2);

            // ASSERT
            testList.IndexOf(2).Should().Be(1);

        }

        #endregion Insert Test

        #region GetByIndex Tests

        [TestMethod]
        [Description("")]
        public void When_ListIsNotEmpty_GetByIndex_Should_Correct_Item()
        {
            // ARRANGE
            testList.Add(1);
            testList.Add(2);

            // ACT
            var item = testList[1];

            // ASSERT
            Assert.AreEqual(2, item);
        }

        /// <summary></summary>
        [TestMethod]
        [Description("")]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void When_List_IsEmtpy_GetByIndex_Should_Throw_Exception()
        {
            // ARRANGE

            // ACT
            var item = testList[2];

            // ASSERT

        }


        /// <summary></summary>
        [TestMethod]
        [Description("")]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void When_Index_IsInvalid_GetByIndex_Should_Throw_An_Exception()
        {
            // ARRANGE
            testList.Add(1);
            testList.Add(2);

            // ACT
            int i = testList[2];

            // ASSERT

        }

        #endregion Get Index Tests

        #region SetByIndex Tests

        /// <summary></summary>
        [TestMethod]
        [Description("")]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void When_Index_IsInvalid_SetByIndex_ShouldThrowAnException()
        {
            // ARRANGE
            testList.Add(1);
            testList.Add(2);

            // ACT
            testList[2] = 3;

            // ASSERT

        }

        /// <summary></summary>
        [TestMethod]
        [Description("")]
        public void When_Index_IsValid_SetByIndex_Should_ReplaceItem()
        {
            // ARRANGE
            testList.Add(1);
            testList.Add(3);

            // ACT
            testList[1] = 2;

            // ASSERT
            testList.IndexOf(2).Should().Be(1);

        }

        #endregion SetByIndex Tests

        #region Remove At Tests

        /// <summary></summary>
        [TestMethod]
        [Description("")]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void When_List_IsEmpty_RemoveAt_Should_Throw_An_Exception()
        {
            // ARRANGE

            // ACT
            testList.RemoveAt(0);

            // ASSERT

        }

        /// <summary></summary>
        [TestMethod]
        [Description("")]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void When_Index_IsGreateEquals_Count_RemoveAt_Should_Throw_An_Exception()
        {
            // ARRANGE
            testList.Add(1);

            // ACT
            testList.RemoveAt(1);


            // ASSERT

        }

        /// <summary></summary>
        [TestMethod]
        [Description("")]
        public void When_Index_IsZero_And_List_Contains_OneElement_It_Should_Empty_The_List()
        {
            // ARRANGE
            testList.Add(1);

            // ACT
            testList.RemoveAt(0);

            // ASSERT
            testList.Count.Should().Be(0);

        }

        /// <summary></summary>
        [TestMethod]
        [Description("")]
        public void When_Index_IsZero_It_Should_Remove_FirstItem()
        {
            // ARRANGE
            testList.Add(1);
            testList.Add(2);

            // ACT
            testList.RemoveAt(0);

            // ASSERT
            testList.IndexOf(2).Should().Be(0);

        }

        /// <summary></summary>
        [TestMethod]
        [Description("")]
        public void When_List_HasMore_As_One_Element_RemoveAt_Should_Remove_At_CorrectPosition()
        {
            // ARRANGE
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);

            // ACT
            testList.RemoveAt(1);

            // ASSERT
            testList.IndexOf(3).Should().Be(1);

        }


        #endregion Remove At Tests

        #region Remove Tests

        /// <summary></summary>
        [TestMethod]
        [Description("")]
        public void When_Item_IsNo_In_List_Remove_Should_Return_False()
        {
            // ARRANGE
            testList.Add(1);

            // ACT
            var result = testList.Remove(2);

            // ASSERT
            result.Should().Be(false);
        }


        /// <summary></summary>
        [TestMethod]
        [Description("")]
        public void When_Item_IsInList_Remove_Should_Return_True()
        {
            // ARRANGE
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);

            // ACT
            var result = testList.Remove(2);

            // ASSERT
            result.Should().Be(true);
            testList.IndexOf(2).Should().Be(-1);
            testList.IndexOf(3).Should().Be(1);
        }

        #endregion Remove Tests

        #region CopyTo Tests

        /// <summary></summary>
        [TestMethod]
        [Description("")]
        public void A_List_Should_Copy_To_An_Array()
        {
            // ARRANGE
            testList.Add(2);
            testList.Add(3);
            testList.Add(4);

            var arrayOfInt = new int[4];
            arrayOfInt[0] = 1;

            // ACT
            testList.CopyTo(arrayOfInt, 1);


            // ASSERT
            arrayOfInt.Should().BeEquivalentTo(new object[] { 1, 2, 3, 4 });
        }

        /// <summary></summary>
        [TestMethod]
        [Description("")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void When_The_Count_Of_The_List_IsToLarge_For_Array_CopyTo_Should_Throw_An_Exception()
        {
            // ARRANGE
            testList.Add(1);
            testList.Add(2);
            var arrayOfInt = new int[1];

            // ACT
            testList.CopyTo(arrayOfInt, 0);

            // ASSERT

        }

        #endregion CopyTo Tests

        #region Enumeration Tests

        /// <summary></summary>
        [TestMethod]
        [Description("")]
        public void List_Should_Be_Enumerable()
        {
            // ARRANGE
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            var newList = new List<int>();

            // ACT
            foreach (var i in testList)
            {
                newList.Add(i);
            }

            // ASSERT
            newList.Should().BeEquivalentTo(new List<int>() { 1, 2, 3 });

        }

        /// <summary></summary>
        [TestMethod]
        [Description("")]
        public void A_Enumerator_Can_Be_Reset()
        {
            // ARRANGE
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);

            var enumerator = testList.GetEnumerator();

            // ACT
            enumerator.MoveNext();
            enumerator.Current.Should().Be(1);
            enumerator.MoveNext();
            enumerator.Current.Should().Be(2);

            enumerator.Reset();

            enumerator.MoveNext();
            enumerator.Current.Should().Be(1);

            // ASSERT

        }

        #endregion Enumeration Tests

    }

}
