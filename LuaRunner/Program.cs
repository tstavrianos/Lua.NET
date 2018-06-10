using System;
using LuaInterface;

namespace LuaRunner {
    internal class LuaNetRunner {
        //[STAThread]
        private static void Main (string[] args) {
			if(args.Length > 0) 
			{
				// For attaching from the debugger
				// Thread.Sleep(20000);

				using(var lua = new LuaInterface.Lua())
				{
                    //lua.OpenLibs();			// steffenj: Lua 5.1.1 API change (all libs already opened in Lua constructor!)
					lua.NewTable("arg");
					LuaTable argc = (LuaTable)lua["arg"];
					argc[-1] = "LuaRunner";
					argc[0] = args[0];

					for(int i = 1; i < args.Length; i++)
						argc[i] = args[i];

					argc["n"] = args.Length - 1;

					try
					{
						//Console.WriteLine("DoFile(" + args[0] + ");");
						lua.DoFile(args[0]);
					}
					catch(Exception e)
					{
						// steffenj: BEGIN error message improved, output is now in decending order of importance (message, where, stacktrace)
						// limit size of strack traceback message to roughly 1 console screen height
						string trace = e.StackTrace;

						if(e.StackTrace.Length > 1300)
							trace = e.StackTrace.Substring(0, 1300) + " [...] (traceback cut short)";

						Console.WriteLine();
						Console.WriteLine(e.Message);
						Console.WriteLine(e.Source + " raised a " + e.GetType().ToString());
						Console.WriteLine(trace);

						// wait for keypress if there is an error
						Console.ReadKey();
						// steffenj: END error message improved
					}
				}
			} 
			else 
			{
				Console.WriteLine("LuaRunner -- runs Lua scripts with CLR access");
				Console.WriteLine("Usage: luarunner <script.lua> [{<arg>}]");
            }           
        }
    }
}