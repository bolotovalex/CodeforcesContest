namespace AirCondBattleTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestFromFiles()
        {
            var testFilexCount = 9;
            var path = "..\\..\\..\\..\\AirCondBattleTests\\tests\\";
            for (var i = 1; i<= testFilexCount; i++)
            {
                var filename = i < 10 ? $"{path}0{i}" : $"{path}{i}";
                var answerFileneam = $"{filename}.a";
                var taskFile = new StreamReader(filename);
                var answerFile = new StreamReader(answerFileneam);

                var testCount = int.Parse(taskFile.ReadLine());
                for (var testNumber = 0; testNumber < testCount; testNumber++)
                {
                    var conduction = (15, 30);
                    var rulesCount = int.Parse(taskFile.ReadLine());
                    for (var ruleNumber = 0; ruleNumber < rulesCount; ruleNumber++)
                    {
                        var rule = taskFile.ReadLine().Trim();
                        
                        var answer = int.Parse(answerFile.ReadLine().Trim());
                        conduction = AirCondBattle.Program.GetNewConditions(conduction, rule);

                        Assert.AreEqual(answer, AirCondBattle.Program.GetTemp(conduction));
                    }

                    answerFile.ReadLine();
                }

            }
        }
    }
}