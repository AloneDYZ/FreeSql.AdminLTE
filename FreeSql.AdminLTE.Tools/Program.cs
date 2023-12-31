﻿using System;
using System.Threading;

namespace FreeSql.AdminLTE.Tools
{
    class Program
    {
        static void Main(string[] args)
        {
			if (args != null && args.Length == 0) args = new[] { "?" };

			ManualResetEvent wait = new ManualResetEvent(false);
			new Thread(() => {
				Thread.CurrentThread.Join(TimeSpan.FromMilliseconds(10));

                try
                {
                    ConsoleApp app = new ConsoleApp(args, wait);
                }
                finally
                {
                    wait.Set();
                }
			}).Start();
			wait.WaitOne();
			return;
		}
    }
}

//dotnet tool update -g freesql.adminlte.tools --add-source C:\Users\28810\Desktop\github\FreeSql.AdminLTE\FreeSql.AdminLTE.Tools\bin\Debug\