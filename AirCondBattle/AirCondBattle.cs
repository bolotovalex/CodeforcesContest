﻿namespace AirCondBattle;

public class Program
{
    public static void Main(string[] args)
    {
        var stageCount = int.Parse(Console.ReadLine());
        for (var stageNumb = 0; stageNumb < stageCount; stageNumb++)
        {
            var condition = (15, 30);
            var condCount = int.Parse(Console.ReadLine());
            for (var conditionNumer = 0; conditionNumer < condCount; conditionNumer++)
            {
                var rule = Console.ReadLine();
                condition = GetNewConditions(condition, rule);
                Console.WriteLine(GetTemp(condition));
            }
            Console.WriteLine();
        }
    }

    public static (int, int) GetNewConditions((int min, int max) extCond, string newRule)
    {
        var ruleCommand = newRule.Split('=');
        var temp = int.Parse(ruleCommand[1]);
        if (ruleCommand[0] == ">")
        {
            extCond = (temp > extCond.min ? temp : extCond.min, extCond.max);
        }
        else if (ruleCommand[0] == "<")
        {
            extCond = (extCond.min, temp < extCond.max ? temp : extCond.max);
        }

        return extCond;
    }

    public static int GetTemp((int min, int max) conditions)
    {
        if (conditions.min > conditions.max)
        {
            return -1;
        }
        return conditions.min;
    }
}