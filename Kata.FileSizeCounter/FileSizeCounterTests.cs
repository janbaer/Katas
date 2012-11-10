using System;
using System.Diagnostics.Contracts;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata.FileSizeCounter
{

    [TestClass]
    [DeploymentItem(@"TestDirectory", "TestDirectory")]
    [DeploymentItem(@"TestDirectory2", "TestDirectory2")]
    [DeploymentItem(@"TestDirectory2\TestDirectory", @"TestDirectory2\TestDirectory")]
    public class FileSizeCounterTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void CountFileSizeWithOneExistingFile()
        {
            // ARRANGE
            string fileName = Path.Combine(TestContext.TestDeploymentDir, "TestDirectory", "TextFile1.txt");

            // ACT
            IFileSizeCounter fileSizeCounter = new FileSizeCounter(fileName);            

            // ASSERT
            Assert.AreEqual(4, fileSizeCounter.FileSize);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void CountFileSizeOfNotExistingFile()
        {
            // ARRANGE
            string fileName = Path.Combine(TestContext.TestDeploymentDir, "TestDirectory", "NotExistingFile.txt");

            // ACT
            IFileSizeCounter fileSizeCounter = new FileSizeCounter(fileName);

            // ASSERT
        }

        [TestMethod]
        public void CountFileSizeOfDirectoryWithTwoFiles()
        {
            // ARRANGE
            string directoryName = Path.Combine(TestContext.DeploymentDirectory, "TestDirectory");

            // ACT
            IFileSizeCounter fileSizeCounter = new FileSizeCounter(directoryName);

            // ASSERT
            Assert.AreEqual(8, fileSizeCounter.FileSize);
        }

        [TestMethod]
        public void CountFileSizeOfDirectorywithSubDirectories()
        {
            // ARRANGE
            string directoryName = Path.Combine(TestContext.DeploymentDirectory, "TestDirectory2");

            // ACT
            IFileSizeCounter fileSizeCounter = new FileSizeCounter(directoryName);

            // ASSERT
            Assert.AreEqual(16, fileSizeCounter.FileSize);
        }

    }

    public interface IFileSizeCounter
    {
        long FileSize { get; }
    }

    public class FileSizeCounter : IFileSizeCounter
    {
        public FileSizeCounter(string name)
        {
            if (Directory.Exists(name))
            {
                this.FileSize = this.GetTotalSizeOfDirectory(new DirectoryInfo(name));
            }
            else if (File.Exists(name))
            {
                this.FileSize = new FileInfo(name).Length;                      
            }
            else
            {
                throw new FileNotFoundException("File not found", name);        
            }

        }

        private long GetTotalSizeOfDirectory(DirectoryInfo directoryInfo)
        {
            Contract.Assert(directoryInfo != null);

            long totalFileSize = 0;

            foreach (var file in directoryInfo.GetFiles("*.*"))
            {
                totalFileSize += file.Length;
            }

            foreach (var subDirectory in directoryInfo.GetDirectories())
            {
                totalFileSize += GetTotalSizeOfDirectory(subDirectory);
            }

            return totalFileSize;
        }

        public long FileSize { get; set; }
    }
}
