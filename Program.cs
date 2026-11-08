using System;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
namespace TermSeek
{
    class Program
    {
        static void Main(string[] args)
        {
            //===========创建两个数据库对象============
            string[] qstore = {"ns是什么？","你是什么？" };
            string[] astore = { "ns是404开发的一个命令行语言", "我是TermSeek，一个搜索工具。" };
            //===========创建辅助变量============
            int sv = qstore.Length;     //sv是数据库的长度 用于辅助查找
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
                for (int i=0; i < sv; i++)
                {
                    if (qstore[i].Contains(raw))
                    {
                        L = i + 1;
                        Console.WriteLine($"结果编号 {L}: {qstore[i]}");
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
                    //============重置辅助变量============
                    k = 0;
                    K = 0;
                    L = 0;
                    w = 0;
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
                        if (mum > 0 || mum <= L)
                        {
                            w = L - 1;
                            Console.WriteLine(astore[w]);
                            //============重置辅助变量============
                            k = 0;
                            K = 0;
                            L = 0;
                            w = 0;
                        }
                    }
                    else
                    {
                        Console.WriteLine("输入错误 请输入数字");    //不合法
                        //============重置辅助变量============
                        k = 0;
                        K = 0;
                        L = 0;
                        w = 0;
                    }
                }
            }
        }
    }
}