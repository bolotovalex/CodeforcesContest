using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Diagnostics;
using System.Text;

namespace StickersTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void FirstTest1()
        {
            var str = new StringBuilder("somesuperlongstring");
            var actions = new string[] { "1 2 la", "4 4 d", "10 13 tiny", "4 5 ed" };
            foreach (var action in actions)
                str = Stickers.Program.ChangeString(str, action.Split(' '));
            Assert.That("lamedupertinystring", Is.EqualTo(str.ToString()));
            Assert.That("lameduperinystring", !Is.EqualTo(str.ToString()));
        }

        [Test]
        public void TestFromFiles() {
            var testFilesCount = 30;
            for (var i = 1;  i <= testFilesCount; i++)
            {
                var path = "..\\..\\..\\..\\StickersTests\\tests\\";
                var filename = i < 10 ? $"{path}0{i.ToString()}" : $"{path}{i.ToString()}";
                var taskFile = new StreamReader(filename);
                var answerString = new StreamReader($"{filename}.a").ReadLine().Trim();
                var str = new StringBuilder(taskFile.ReadLine());
                var actionsCount = int.Parse(s: taskFile.ReadLine());
                var actions = taskFile.ReadToEnd().Split('\n');
                
                for (var j = 0; j < actionsCount; j++)
                    str = Stickers.Program.ChangeString(str, actions[j].Trim().Split(' '));
                
                var resultString = str.ToString();
                Assert.That(answerString, Is.EqualTo(resultString));
            }
        }
    }
}