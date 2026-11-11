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
            string[,] ku = new string[2, 30]{
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
                    "TermSeek有没有API？",
                    "怎么开启开发者模式？",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
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
                    "等待更新",
                    "输入<cmd>",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",

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
                //============判断开发者员模式=============
                if (raw == "<cmd>")
                {
                    // ============进入开发者模式============
                    Console.WriteLine("已进入开发者模式。");
                    Console.WriteLine("输入</cmd>退出开发者模式。");
                    while (true)
                    {
                        Console.Write("/n执行/ :");

                        string cmd = Console.ReadLine()!;
                        if (cmd == "</cmd>")
                        {
                            Console.WriteLine("已经退出开发者模式。");
                            break;
                        }
                        Console.WriteLine($"执行命令: {cmd}");
                        if (cmd == "help")
                        {
                            Console.WriteLine("开发者模式帮助:");
                            Console.WriteLine("1. 输入</cmd>退出开发者模式。");
                            Console.WriteLine("2. 输入help查看帮助信息。");
                            Console.WriteLine("3. 其他命令请自行探索。");
                        }
                        else if(cmd=="term")
                        {
                            //输入格式介绍
                            Console.WriteLine("开始添加数据库");
                            Console.WriteLine("输入你的问题");
                            String term = Console.ReadLine()!;
                            Console.WriteLine("输入问题编号（提示 输入重复的会导致覆盖）:");
                            string ku1 = Console.ReadLine()!;
                            Console.WriteLine("输入你的回答");
                            string ku2  = Console.ReadLine()!;
                            //首先判断合法性
                            if (int.TryParse(ku1, out int ku3))
                            {
                                if(ku3 < 0 || ku3 >= sv)
                                {
                                    Console.WriteLine("输入的编号超出数据库范围，请重新输入");
                                    continue;
                                }
                                Console.WriteLine("输入合法，正在添加数据库");
                                //添加数据库
                                ku[0, ku3] = term;
                                Console.WriteLine("问题加载成功");
                                ku[1, ku3] = ku2;
                                Console.WriteLine("回答加载成功");
                            }
                            else
                            {
                                Console.WriteLine("输入错误 请输入数字");
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"未知命令: {cmd}");
                        }
                    }
                }
                else
                {
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
}