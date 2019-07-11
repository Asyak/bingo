using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bingo.Tests
{
    [TestClass]
    public class HomeTests
    {

        [TestMethod]
        public void Play_GeneratedIndex_Ok()
        {
            List<String> testList = new List<string>();
            testList.Add("a");
            testList.Add("b");
            testList.Add("c");
            testList.Add("d");
            testList.Add("e");

            Random rnd = new Random();
            var nIndex = rnd.Next(testList.Count);
            var bResult = true;

            // As we test a random number from a range of numbers, 
            // only one result is not statistically reliable
            for (int i = 0; i < 100; i++)
            {
                if (nIndex > testList.Count)
                {
                    bResult = false;
                    break;
                }
            }

            Assert.IsTrue(bResult);
        }


        [TestMethod]
        public void ShuffleList_ListeIsDifferent()
        {
            List<Song> shuffledList = new List<Song>();
            Home h = new Home();
            int count = 0;
            List<Song> testList = new List<Song>();

            Song a = new Song(1, "a", "a");
            Song b = new Song(2, "b", "b");
            Song c = new Song(3, "c", "c");
            Song d = new Song(4, "d", "d");
            Song e = new Song(5, "e", "e");

            testList.Add(a);
            testList.Add(b);
            testList.Add(c);
            testList.Add(d);
            testList.Add(e);

            shuffledList = h.ShuffleList(testList);
            if (shuffledList[0] == a)
            {
                count++;
            }
            else if (shuffledList[1] == b)
            {
                count++;
            }
            else if (shuffledList[2] == c)
            {
                count++;
            }
            else if (shuffledList[3] == d)
            {
                count++;
            }
            else if (shuffledList[4] == e)
            {
                count++;
            }

            // Not all list element are at their initial index
            Assert.AreNotEqual(5, count);
        }


        [TestMethod]
        public void ContainsSong_IsTrue()
        {
            List<Song> testList = new List<Song>();
            Song a = new Song(1, "a", "a");
            Song b = new Song(2, "b", "b");
            Song c = new Song(3, "c", "c");
            Song d = new Song(2, "d", "d");
            Song e = new Song(2, "e", "e");

            testList.Add(a);
            testList.Add(b);
            testList.Add(c);
            testList.Add(d);
            testList.Add(e);

            Home h = new Home();
            bool bResult = true;
            bResult = h.ContainsSong(b, testList);

            Assert.IsTrue(bResult);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void DisplaySong_IndexOutOfRange_ThrowExp()
        {
            List<Song> testList = new List<Song>();
            Song a = new Song(1, "a", "a");
            Song b = new Song(2, "b", "b");
            Song c = new Song(3, "c", "c");
            Song d = new Song(2, "d", "d");
            Song e = new Song(2, "e", "e");

            testList.Add(a);
            testList.Add(b);
            testList.Add(c);
            testList.Add(d);
            testList.Add(e);

            Home h = new Home();
            h.DisplaySong(10, testList);
        }

    }
}
