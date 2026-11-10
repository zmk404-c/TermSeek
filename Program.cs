/* 这个作品是由404开发的一个命令行搜索工具，名为TermSeek。
 * 它可以让用户输入搜索关键词，
 * 并在预设的数据库中查找相关问题和答案。
 * 用户可以通过输入具体编号来查看对应的答案。
 * 点点点，TermSeek正在不断完善中，未来可能会加入更多功能和更大的数据库。
 * 求关注404的GitHub主页，获取更多有趣的项目和工具。
 * 还有 点一个赞，404会更有动力开发更多有趣的工具。
*/
/*本次更新了数据库和代码
 *减少了了代码的冗余
 * 预计在未来的版本中，TermSeek将会加入更多的功能和更大的数据库，以提供更丰富的搜索体验。
 * 甚至加入图形化界面和网络搜索功能，让用户能够更方便地获取信息。
 */
using System;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
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
                "404是谁？",
                "ns是什么？",
                "你是什么？",
                "TermSeek怎么使用？",
                "TermSeek支持哪些平台？",
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

            //===========创建辅助变量============
            int sv = ku.GetLength(1);     //sv是数据库的长度 用于辅助查找
            int L = 0;    //L是搜索结果的编号
            int k = 0;  //k是命中检测
            int K = 0;  //K是命中检测的辅助变量
            int w = 0;  //w是辅助打印的变量
            //============这是开始界面============
            Console.WriteLine("欢迎使用TermSeek! 你可以在这里进行搜索。");
            while (true)
            {
                //============开始获取用户输入============
                Console.Write("搜索:");
                string raw = Console.ReadLine()!;
                //============开始进行数据库比对============
                for ( int i=0; i < sv; i++)
                {
                    if (ku[0,i].Contains(raw))
                    {
                        L = i + 1;
                        Console.WriteLine($"结果编号 {L}: {ku[0,i]}");
                        K = 1;
                    }
                    else
                    { 
                        k = 1;
                    }
                }
                //============命中检测============
                if (k == 1 && K == 0)
                {
                    Console.WriteLine("没有找到相关结果。");
                    
                }
                else
                {
                    //============开始获取用户选择============
                    //============判断选择合法性============
                    Console.Write("输入具体编号以查看结果:");
                    
                    string raw2 = Console.ReadLine()!;
                    //w = int.TryParse(raw2, out int mum);

                    if (int.TryParse(raw2, out int mum))   //合法 
                    {
                        //============开始查找============
                        if (mum > 0 || mum <= sv)
                        {
                            w = L - 1;
                            Console.WriteLine(ku[1,mum-1]);

                        }
                        else
                        {
                            Console.WriteLine("输入合法的数字");
                        }
                    }
                    else
                    {
                        Console.WriteLine("输入错误 请输入数字");    //不合法
                       
                    }
                     
                }
                //============重置辅助变量============
                k = 0;
                K = 0;
                L = 0;
                w = 0;
            }
        }
    }
}