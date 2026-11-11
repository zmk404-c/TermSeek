/*
 * TermSeek - 一个命令行搜索工具。
 * 作者: 404。
 * GitHub:zmk404-c/TermSeek。
 * 简化了搜索流程，方便在命令行中快速搜索和获取信息。
 * 后面预计加入管理员模式，支持自定义配置和插件。
 * 后面我会学习xml，然后加入xml配置文件，方便自定义搜索内容和插件。
 * 等我学会了windows窗体，我会加入一个图形界面，方便不熟悉命令行的用户使用。
 */
using System;

namespace TermSeek
{
    class Program
    {
        static void Main(string[] args)
        {
            //===========创建一个数据库对象============
            string[,] ku = {
                // 问题数据库
                {
                    "404是谁？", "ns是什么？", "你是什么？",
                    "TermSeek怎么使用？", "TermSeek支持哪些平台？",
                    "TermSeek如何安装？",
                    "TermSeek是开源的吗？",
                    "TermSeek支持搜索哪些内容？", 
                    "TermSeek和普通搜索有什么区别？",
                    "TermSeek需要联网吗？", 
                    "如何反馈问题或建议？", 
                    "如何自定义TermSeek的配置？", 
                    "TermSeek支持哪些命令？",
                    "如何更新TermSeek？", 
                    "TermSeek有没有API？"
                },
                // 答案数据库
                {
                    "404是一个开发者，喜欢开发有趣的工具和项目。",
                    "ns是404开发的一个语言。",
                    "我是TermSeek，一个命令行搜索工具。",
                    "TermSeek通常通过在命令行输入关键词，然后输入答案编号来查看结果。",
                    "只支持命令行环境。",
                    "https://github.com/zmk404-c/TermSeek.git", 
                    "已经开源，https://github.com/zmk404-c/TermSeek.git",
                    "具体范围取决于配置和插件。",
                    "TermSeek强调命令行内快速检索和可定制工作流，普通搜索引擎更偏向网页信息检索。",
                    "如果搜索本地数据通常不需要联网。",
                    "注意3839316842。",
                    "学习C#编程。",
                    "请等待开发者模式。",
                    "github上我会更新。",
                    "等待更新"
                }
            };

            // 栈（用来存匹配到的真实索引）
            int[] zhan = new int[100];
            int sv = ku.GetLength(1);     // 数据库的列数（问题数量）

            Console.WriteLine("欢迎使用TermSeek! 你可以在这里进行搜索。");

            while (true)
            {
                Console.Write("\n搜索:");
                string raw = Console.ReadLine()!;

                int L = 0;    // 匹配到的结果数量
                bool isFound = false; // 是否找到的标志

                //============开始进行数据库比对============
                for (int i = 0; i < sv; i++)
                {
                    if (ku[0, i].Contains(raw))
                    {
                        L++; // 结果编号
                        Console.WriteLine($"结果编号 {L}: {ku[0, i]}");
                        zhan[L - 1] = i;  // 将匹配的真实索引存入栈中
                        isFound = true;
                    }
                }

                //============命中检测============
                if (!isFound)
                {
                    Console.WriteLine("没有找到相关结果。");
                    continue; //  关键：没找到直接重新开始循环，不往下走
                }

                //============开始获取用户选择============
                Console.Write("输入具体编号以查看结果:");
                string raw2 = Console.ReadLine()!;

                //============判断选择合法性============
                if (int.TryParse(raw2, out int mum))
                {
                    //  修复1：必须是 &&，不能是 ||
                    // 编号必须大于0，且不能超过搜出来的最大数量 L
                    if (mum > 0 && mum <= L)
                    {
                        //  修复2：直接用用户的输入 mum - 1 作为 zhan 的下标去拿真实索引
                        int w = zhan[mum - 1];

                        Console.WriteLine($"结果编号 {mum}: {ku[0, w]}");
                        Console.WriteLine($"答案: {ku[1, w]}");
                    }
                    else
                    {
                        Console.WriteLine($"输入错误，请输入 1 到 {L} 之间的数字！");
                    }
                }
                else
                {
                    Console.WriteLine("输入错误 请输入数字"); // 不合法
                }
            }
        }
    }
}