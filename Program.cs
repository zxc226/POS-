using System;
using System.Collections.Generic;
using System.Linq;
using Dal;
using Microsoft.EntityFrameworkCore;
using Moder;

namespace Cs
{
    //class Program
    //{
    //    public static Dal.DBhelp openclass = new DBhelp();
    //    static void Main(string[] args) 
    //    {

    //        var data = openclass.sp.ToList();
    //        for (int i = 0; i < data.Count; i++)
    //        {
    //            Console.WriteLine(data[i].dw.ToString());
    //        }
    //    }
    //}

    class Program
    {
        [System.Runtime.InteropServices.DllImport("User32.dll", EntryPoint = "ShowWindow")]
        //用于发送信息给窗体
        private static extern bool ShowWindow(IntPtr hWnd, int type);

        [System.Runtime.InteropServices.DllImport("User32.dll", EntryPoint = "FindWindow")]
        ////找子窗体
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        public static Moder.Allopen allopen = new Moder.Allopen();

        public static Meggers Meggers = new Meggers();
        public static List<string> zg = new List<string>();
        public static Dal.DBhelp openclass = new DBhelp();

        static void Main(string[] args)
        {
            Console.Title = "POS收银台";            //当前窗口的标题
            IntPtr ParenthWnd = new IntPtr(0);
            IntPtr et = new IntPtr(0);
            ParenthWnd = FindWindow(null, "POS收银台");
            ShowWindow(ParenthWnd, 3);
            var jg = Loginer();
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                if (jg == true)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ReadKey();
                    Menter();
                }
                else
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Black;
                    jg = Loginer();
                }
            }

        }

        public static void gznr()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;
            List<string> zffs = new List<string>();
            zffs.Add("1.会员卡");
            zffs.Add("2.银行卡");
            zffs.Add("3.扫码支付");
            zffs.Add("4.现金");
            zffs.Add("当前单号：");
            zffs.Add("营业员:");

            List<string> jexx = new List<string>();
            jexx.Add("应收银：");
            jexx.Add("折扣金额:");
            jexx.Add("实收银：");
            jexx.Add("总金额：");
            jexx.Add("数量：");
            jexx.Add("占比：");

            Console.CursorSize = 24;
            Console.SetWindowSize(width: Console.WindowWidth, height: Console.WindowHeight);
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("欢迎使用POS收银台");
            Console.SetCursorPosition(Console.WindowWidth / 2, 0);
            Console.Write("福龙东海");
            Console.SetCursorPosition(Console.WindowWidth / 2 * 2 - 24, 0);
            Console.WriteLine(DateTime.Now.ToShortDateString() + "        " + DateTime.Now.ToShortTimeString());
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("_");
            }

            Console.SetCursorPosition(Console.WindowWidth / 2, 2);
            Console.Write("重来");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 12, 2);
            Console.WriteLine("清除");
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("_");
            }
            Console.WriteLine();

            Console.Write("序号\t商品编号\t商品名称\t\t\t商品单价\t商品数量\t商品单位\t\t商品折扣价\t\t商品应收价\t\n");
            //Console.SetCursorPosition(Console.WindowWidth / 12 + 12, 4);
            //Console.Write("");
            //Console.SetCursorPosition(Console.WindowWidth / 14 + 16, 4);
            //Console.Write("");
            //Console.SetCursorPosition(Console.WindowWidth / 16 + 20, 4);
            //Console.Write("");
            //Console.SetCursorPosition(Console.WindowWidth / 18 + 24, 4);
            //Console.Write("");
            //Console.SetCursorPosition(Console.WindowWidth / 20 + 28, 4);
            //Console.Write("");
            //Console.SetCursorPosition(Console.WindowWidth / 22 + 32, 4);
            //Console.Write("");
            //Console.SetCursorPosition(Console.WindowWidth / 24 + 36, 4);
            Console.Write("");
            Random r = new Random();
            Console.SetCursorPosition(5, Console.WindowHeight - 12);
            try
            {
                for (int i = 0; i < zffs.Count; i++)
                {
                    Console.SetCursorPosition(5, Console.WindowHeight - 14 + i);
                    Console.WriteLine("{0}\t\t\t\t{1}\n", zffs[i * 2 - i], zffs[i * 2 + 1 - i]);
                    i++;
                }
                Console.SetCursorPosition(15, Console.WindowHeight - 14 + zffs.Count - 2);
                Console.WriteLine("{0}\t\t\t\t{1}\n", "JZ" + DateTime.Now.ToLongTimeString() + r.Next(0, 999999).ToString(), "Admmin");
            }
            catch (Exception e)
            {
                Console.WriteLine("");
            }

            try
            {
                for (int i = 0; i < jexx.Count; i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 + 12, Console.WindowHeight - 14 + i);
                    Console.WriteLine("{0}\t\t\t\t{1}\n", jexx[i * 2 - i], jexx[i * 2 + 1 - i]);
                    i++;

                }
                zg.Add("12");
                zg.Add("13");
                zg.Add("14");
                zg.Add("15");
                zg.Add("16");
                zg.Add("17");
                zgxs(zg);

            }
            catch (Exception e)
            {
                Console.WriteLine("");
            }
            Console.SetCursorPosition(1, 2);
            Console.Write("编号：");

            Console.SetCursorPosition(Console.WindowWidth / 6, 2);
            Console.Write("数量：");

            Console.SetCursorPosition(Console.WindowWidth / 2 + 12, Console.WindowHeight - 5);
            Console.Write("购物卡号：");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 12, Console.WindowHeight - 7);
            Console.Write("收款方式：");
            xzsr("1");

        }

        public static void xzsr(string xzxh)
        {
            string xzxhs = "";
            ConsoleKeyInfo keyInfo;
            switch (xzxh)
            {
                case "1"://编号
                    Console.SetCursorPosition(7, 2);
                    allopen.bh = Console.ReadLine();
                    keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        xzxhs = "2";
                        xzsr(xzxhs);
                    }
                    else if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        Loginer();
                    }
                    break;
                case "2"://数量
                    Console.SetCursorPosition(Console.WindowWidth / 6 + 6, 2);
                    allopen.bh = Console.ReadLine();
                    keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        xzxhs = "3";
                        xzsr(xzxhs);
                    }
                    else if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        Loginer();
                    }
                    break;
                case "3"://购物卡
                    Console.SetCursorPosition(Console.WindowWidth / 2 + 22, Console.WindowHeight - 5);
                    allopen.gwkh = Console.ReadLine();
                    keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        xzxhs = "4";
                        xzsr(xzxhs);
                    }
                    else if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        Loginer();
                    }
                    break;
                case "4"://付款方式
                    Console.SetCursorPosition(Console.WindowWidth / 2 + 22, Console.WindowHeight - 7);
                    allopen.bh = Console.ReadLine();
                    keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        xzxhs = "1";
                        xzsr(xzxhs);
                    }
                    else if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        Loginer();
                    }
                    break;
                default:
                    Meggers.Meggerbox("错误信息", "该操作项有误，请重新输入！", "ERROR", 0, 0);
                    break;
            }
        }

        public static bool Loginer()
        {
            Console.Clear();
            string name = "";
            string pwd = "";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 12, Console.WindowHeight / 2 - 12);
            Console.WriteLine("欢迎使用POS收银系统，请登入");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 - 10);
            Console.WriteLine("登入账号：");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 - 8);
            Console.WriteLine("登入密码：");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 1, Console.WindowHeight / 2 - 10);
            name = Console.ReadLine();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 1, Console.WindowHeight / 2 - 8);
            Console.BackgroundColor = ConsoleColor.Gray;
            pwd = Console.ReadLine();
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
                return false;
            }
            else
            {
                if (name == "Admin" && pwd == "123")
                {
                    return true;
                }
                else
                {
                    Meggers.Meggerbox("提示", "账号或密码有误，请重新确认！", "quers", 0, 0);
                    Loginer();
                    return false;
                }
            }

        }

        public static void Menter()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < 50; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 42 + 14 + i, Console.WindowHeight / 2 - 22 + 14);
                Console.Write("——");
            }

            Console.SetCursorPosition(Console.WindowWidth / 2 - 22 + 14, Console.WindowHeight / 2 - 22 + 16);
            Console.WriteLine("1.进入收银台");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 22 + 14, Console.WindowHeight / 2 - 22 + 18);
            Console.WriteLine("2.管理出入库");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 22 + 14, Console.WindowHeight / 2 - 22 + 20);
            Console.WriteLine("3.关于本系统");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 22 + 14, Console.WindowHeight / 2 - 22 + 22);
            Console.WriteLine("4.退出本系统");

            for (int i = 0; i < 50; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 42 + 14 + i, Console.WindowHeight / 2 - 22 + 36);
                Console.Write("——");
            }

            Console.SetCursorPosition(Console.WindowWidth / 2 - 12, Console.WindowHeight / 2 - 22 + 30);
            Console.Write("请输入选项序号，开始操作：");
            var xh = Console.ReadKey(true);
            switch (xh.KeyChar)
            {
                case '1':
                    gznr();
                    break;
                case '2':
                    crkglmece();
                    break;
                case '3':
                    Console.Clear();
                    Console.WriteLine("2022-11-12");
                    Console.WriteLine("made in cxy");
                    break;
                case '4':
                    Environment.Exit(0);
                    break;
                case '5':
                    loginers();
                    break;
                default:
                    break;
            }

        }

        public static void crkglmece()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < 50; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 42 + 14 + i, Console.WindowHeight / 2 - 22 + 14);
                Console.Write("——");
            }

            Console.SetCursorPosition(Console.WindowWidth / 2 - 22 + 14, Console.WindowHeight / 2 - 22 + 16);
            Console.WriteLine("1.添加出入库");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 22 + 14, Console.WindowHeight / 2 - 22 + 18);
            Console.WriteLine("2.删除出入库");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 22 + 14, Console.WindowHeight / 2 - 22 + 20);
            Console.WriteLine("3.修改出入库");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 22 + 14, Console.WindowHeight / 2 - 22 + 22);
            Console.WriteLine("4.查询出入库");

            for (int i = 0; i < 50; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 42 + 14 + i, Console.WindowHeight / 2 - 22 + 36);
                Console.Write("——");
            }

            Console.SetCursorPosition(Console.WindowWidth / 2 - 22, Console.WindowHeight / 2 - 22 + 30);
            Console.Write("请输入选项序号，开始操作：");
            var xh = Console.ReadKey(true);
            switch (xh.KeyChar)
            {
                case '1':
                    crkgl("1");
                    break;
                case '2':
                    crkgl("2");
                    break;
                case '3':
                    crkgl("3");
                    break;
                case '4':
                    crkgl("4");
                    break;
                default:
                    Meggers.Meggerbox("错误", "数据异常，请重新尝试！", "ERROR", 0, 0);
                    break;
            }
        }

        public static void crkgl(string xh)
        {
            Console.Clear();
            var name = "";
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            int num = SelectArry().Count + 1;
            List<string> spp = new List<string>();
            sp sp = new sp();
            int xhnum = 0;
            switch (xh)
            {
                case "1":
                    try
                    {
                        Console.WriteLine("请输入商品编号：");
                        Console.WriteLine("请输入商品名称：");
                        Console.WriteLine("请输入商品单价：");
                        Console.WriteLine("请输入商品数量：");
                        Console.WriteLine("请输入商品单位：");
                        Console.WriteLine("请输入商品折扣价：");
                        Console.WriteLine("请输入商品应收价：");
                        Console.WriteLine("是否保存?：是按‘Y’否按‘N’取消按‘ESC’");
                        while (true)
                        {
                            if (keyInfo.Key == ConsoleKey.Tab)
                            {
                                if (xhnum >= 7)
                                {
                                    xhnum = 0;
                                }

                                Console.SetCursorPosition(20, xhnum);
                                spp.Add(Console.ReadLine());
                                keyInfo = Console.ReadKey(true);
                                xhnum = xhnum + 1;
                            }
                            else if (keyInfo.Key == ConsoleKey.Y || keyInfo.Key == ConsoleKey.Escape)
                            {
                                break;
                            }
                            else
                            {
                                if (xhnum >= 7)
                                {
                                    xhnum = 0;
                                }
                                Console.SetCursorPosition(20, xhnum);
                                spp.Add(Console.ReadLine());

                                keyInfo = Console.ReadKey(true);
                                xhnum = xhnum + 1;
                            }
                        }
                        sp.xh = openclass.sp.ToList().Count.ToString();
                        sp.spbh = spp[0].ToString();
                        sp.spmc = spp[1].ToString();
                        sp.price = Convert.ToDecimal(spp[2].ToString());
                        sp.number = Convert.ToInt32(spp[3].ToString());
                        sp.dw = spp[4].ToString();
                        sp.zkprice = Convert.ToDecimal(spp[5].ToString());
                        sp.ysprice = Convert.ToDecimal(spp[6].ToString());
                        keyInfo = Console.ReadKey(true);
                        AddArry(sp);
                        Meggers.Meggerbox("成功", "操作成功！", "SUCCESS", 0, 0);
                        spp.Clear();
                        crkglmece();
                    }
                    catch (Exception e)
                    {
                        Meggers.Meggerbox(title: "错误提示", "该输入项不得为空或输入项有误！" + e.ToString(), "ERROR", 0, 0);
                    }

                    break;
                case "2":
                    try
                    {
                        Console.WriteLine("请输入商品名称：");
                        Console.WriteLine("请输入商品编号：");
                        Console.Write("序号\t商品编号\t商品名称\t\t\t商品单价\t商品数量\t商品单位\t\t商品折扣价\t\t商品应收价\t\n");
                        var data1 = SelectArry();
                        for (int i = 0; i < data1.Count; i++)
                        {
                            Console.SetCursorPosition(0, 4 + i);
                            Console.WriteLine("{0}\t{1}\t\t{2}\t\t\t\t{3}\t\t{4}\t\t{5}\t\t\t{6}\t\t\t{7}\n", data1[i].xh, data1[i].spbh, data1[i].spmc, data1[i].price, data1[i].number, data1[i].dw, data1[i].zkprice, data1[i].ysprice);
                        }
                        Console.SetCursorPosition(16, 0);
                        name = Console.ReadLine();
                        Console.SetCursorPosition(16, 1);
                        string bhS = Console.ReadLine();
                        keyInfo = Console.ReadKey(true);
                        if (keyInfo.Key == ConsoleKey.Enter)
                        {
                            Meggers.Meggerbox("警告", "是否删除此信息？按‘Y’为是，‘N’为否", "WRANING", 0, 0);
                            keyInfo = Console.ReadKey(true);
                            if (keyInfo.Key == ConsoleKey.Y)
                            {
                                var DATA = Selectlist(name, bhS);
                                if (DATA == null || DATA.Count == 0)
                                {
                                    Meggers.Meggerbox("提示", "无数据", "INFO", 0, 0);
                                    crkgl("2");
                                }
                                else
                                {
                                    DelArry(name, bhS);
                                    Meggers.Meggerbox("成功", "操作成功！", "SUCCESS", 0, 0);
                                    crkglmece();
                                }

                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Meggers.Meggerbox(title: "错误提示", "该输入项不得为空或输入项有误！" + e.ToString(), "ERROR", 0, 0);
                    }
                    break;
                case "3":
                    Console.WriteLine("请输入商品名称：");
                    Console.WriteLine("请输入商品编号：");
                    Console.Write("序号\t商品编号\t商品名称\t\t\t商品单价\t商品数量\t商品单位\t\t商品折扣价\t\t商品应收价\t\n");
                    var data2 = SelectArry();
                    for (int i = 0; i < data2.Count; i++)
                    {
                        Console.SetCursorPosition(0, 4 + i);
                        Console.WriteLine("{0}\t{1}\t\t{2}\t\t\t\t{3}\t\t{4}\t\t{5}\t\t\t{6}\t\t\t{7}\n", data2[i].xh, data2[i].spbh, data2[i].spmc, data2[i].price, data2[i].number, data2[i].dw, data2[i].zkprice, data2[i].ysprice);
                    }
                    Console.SetCursorPosition(16, 0);
                    name = Console.ReadLine();
                    Console.SetCursorPosition(16, 1);
                    string bh = Console.ReadLine();
                    keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        var data3 = GetSp(name, bh);
                        if (data3 == null)
                        {
                            data3 = new sp();
                        }
                        Console.WriteLine("请输入商品编号：{0}", data3.spbh);
                        Console.WriteLine("请输入商品名称：{0}", data3.spmc);
                        Console.WriteLine("请输入商品单价：{0}", data3.price);
                        Console.WriteLine("请输入商品数量：{0}", data3.number);
                        Console.WriteLine("请输入商品单位：{0}", data3.dw);
                        Console.WriteLine("请输入商品折扣价：{0}", data3.zkprice);
                        Console.WriteLine("请输入商品应收价：{0}", data3.ysprice);
                        for (int i = 0; i < 50; i++)
                        {
                            Console.Write(">>");
                        }
                        Console.WriteLine();
                        sp.xh = data3.xh;
                        Console.WriteLine("请输入商品编号：");
                        sp.spbh = Console.ReadLine();
                        Console.WriteLine("请输入商品名称：");
                        sp.spmc = Console.ReadLine();
                        Console.WriteLine("请输入商品单价：");
                        sp.price = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("请输入商品数量：");
                        sp.number = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("请输入商品单位：");
                        sp.dw = Console.ReadLine();
                        Console.WriteLine("请输入商品折扣价：");
                        sp.zkprice = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("请输入商品应收价：");
                        sp.ysprice = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("是否保存?：是按‘Y’否按‘N’取消按‘ESC’");
                        keyInfo = Console.ReadKey(true);
                        if (keyInfo.Key == ConsoleKey.Y)
                        {
                            UpdataArry(sp);
                            Meggers.Meggerbox("成功", "操作成功！", "SUCCESS", 0, 0);
                        }
                        else
                        {
                            crkglmece();
                        }
                    }
                    else if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Menter();
                    }
                    else
                    {
                        Console.Clear();
                        crkglmece();
                    }
                    break;
                case "4":
                    Console.WriteLine("请输入商品名称：");
                    Console.Write("序号\t商品编号\t商品名称\t\t\t商品单价\t商品数量\t商品单位\t\t商品折扣价\t\t商品应收价\t\n");
                    var data = SelectArry();
                    for (int i = 0; i < data.Count; i++)
                    {
                        Console.SetCursorPosition(0, 4 + i);
                        Console.WriteLine("{0}\t{1}\t\t{2}\t\t\t\t{3}\t\t{4}\t\t{5}\t\t\t{6}\t\t\t{7}\n", data[i].xh, data[i].spbh, data[i].spmc, data[i].price, data[i].number, data[i].dw, data[i].zkprice, data[i].ysprice);
                    }
                    Console.SetCursorPosition(16, 0);
                    name = Console.ReadLine();
                    keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        var select = Selectlist(name: name, bh: "");
                        if (select.Count == 0)
                        {
                            Meggers.Meggerbox("提示", "查无数据", "info", 0, 0);
                        }
                        for (int i = 0; i < select.Count; i++)
                        {
                            Console.Clear();
                            Console.WriteLine("请输入商品名称：");
                            Console.Write("序号\t商品编号\t商品名称\t\t\t商品单价\t商品数量\t商品单位\t\t商品折扣价\t\t商品应收价\t\n");
                            Console.SetCursorPosition(0, 4 + i);
                            Console.WriteLine("{0}\t{1}\t\t{2}\t\t\t\t{3}\t\t{4}\t\t{5}\t\t\t{6}\t\t\t{7}\n", select[i].xh, select[i].spbh, select[i].spmc, select[i].price, select[i].number, select[i].dw, select[i].zkprice, select[i].ysprice);
                        }
                    }
                    else if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Menter();
                    }
                    else
                    {
                        Console.Clear();
                        crkglmece();
                    }
                    break;
                default:
                    Meggers.Meggerbox("错误", "数据异常，请重新尝试！", "ERROR", 0, 0);
                    break;
            }

        }



        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static List<sp> SelectArry()
        {
            var data = openclass.sp.Where(s => true).AsNoTracking().ToList();
            return data;
        }

        public static sp GetSp(string name, string bh)
        {
            if ((name != "" && name != null) && (bh != "" && bh != null))
            {
                var data = openclass.sp.Where(s => s.spmc.Contains(name) && s.spbh == bh).AsNoTracking().FirstOrDefault();
                return data;
            }
            else
          if (name != "" || name != null)
            {
                var data = openclass.sp.Where(s => s.spmc.Contains(name)).AsNoTracking().FirstOrDefault();

                return data;
            }
            else
          if (bh != "" || bh != null)
            {
                var data = openclass.sp.Where(s => s.spbh == bh).AsNoTracking().FirstOrDefault();
                return data;
            }
            else
            {
                return null;
            }
        }

        public static List<sp> Selectlist(string name, string bh)
        {
            if ((name != "" && name != null) && (bh != "" && bh != null))
            {
                var data = openclass.sp.Where(s => s.spmc.Contains(name) && s.spbh == bh).AsNoTracking().ToList();
                return data;


            }
            else
            if (name != "" || name != null)
            {
                var data = openclass.sp.Where(s => s.spmc.Contains(name)).AsNoTracking().ToList();
                return data;
            }
            else
            if (bh != "" || bh != null)
            {
                var data = openclass.sp.Where(s => s.spbh == bh).AsNoTracking().ToList();
                return data;
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sp"></param>
        /// <returns></returns>
        public static string AddArry(sp sp)
        {
            var data = openclass.sp.Add(sp);
            openclass.SaveChanges();
            return data.State.ToString();
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sp"></param>
        /// <returns></returns>
        public static string UpdataArry(sp sp)
        {
            //openclass.Entry(sp).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            var data = openclass.sp.Update(sp);
            openclass.SaveChanges();
            return data.State.ToString();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string DelArry(string name, string bh)
        {
            try
            {
                if ((name != "" && name != null) && (bh != "" && bh != null))
                {
                    var data = openclass.sp.Where(s => s.spmc.Contains(name) && s.spbh == bh).FirstOrDefault();
                    openclass.sp.Remove(data);
                }
                else if (name != "" || name != null)
                {
                    var data = openclass.sp.Where(s => s.spmc.Contains(name)).FirstOrDefault();
                    openclass.sp.Remove(data);
                }
                else if (bh != "" || bh != null)
                {
                    var data = openclass.sp.Where(s => s.spbh == bh).FirstOrDefault();
                    openclass.sp.Remove(data);
                }
                else
                {
                    return null;
                }
                openclass.SaveChanges();
                return "ok";
            }
            catch (Exception e)
            {
                Meggers.Meggerbox("错误信息", "删除失败" + e.ToString(), "error", 0, 0);
                throw;
            }


        }
        /// <summary>
        /// 登入
        /// </summary>
        public static void loginers()
        {

        }

        public static void zgxs(List<string> zg)
        {
            for (int i = 0; i < zg.Count; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 + 20, Console.WindowHeight - 14 + i);
                Console.WriteLine("{0}\t\t\t\t\t  {1}\n", zg[i * 2 - i], zg[i * 2 + 1 - i]);
                i++;
            }
        }

    }
}
