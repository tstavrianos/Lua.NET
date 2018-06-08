using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using static Lua.NET.Lua;

namespace ConsoleTest {
    internal class Program {
        private static lua_State globalL;
        private static string progname = "lua";

        private static void lstop (lua_State L, IntPtr ar) {
            lua_sethook (L, IntPtr.Zero, 0, 0); /* reset hook */
            luaL_error (L, "interrupted!");
        }

        private static void laction (object sender, ConsoleCancelEventArgs e) {
            Console.CancelKeyPress -= laction;
            lua_sethook (globalL, lstop, LUA_MASKCALL | LUA_MASKRET | LUA_MASKCOUNT, 1);
        }

        private static void print_usage(string badoption) {
            Console.Error.Write("{0}: ", progname);
            if(badoption[1] == 'e' || badoption[1] == 'l') {
                Console.Error.WriteLine($"'{badoption}' needs argument");
            } else {
                Console.Error.WriteLine($"unrecognized option '{badoption}'");
            }

            Console.Error.Write("usage: {0} [options] [script [args]]", progname);
            Console.Error.Write("Available options are:");
            Console.Error.Write("  -e stat  execute string 'stat'");
            Console.Error.Write("  -i       enter interactive mode after executing 'script'");
            Console.Error.Write("  -l name  require library 'name' into global 'name'");
            Console.Error.Write("  -v       show version information");
            Console.Error.Write("  -E       ignore environment variables");
            Console.Error.Write("  --       stop handling options");
            Console.Error.Write("  -        stop handling options and execute stdin");
        }

        private static void l_message(string pname, string msg) {
            if(!string.IsNullOrEmpty(pname)) Console.Error.Write($"{pname}: ");
            Console.Error.WriteLine($"{msg}");
        }

        private static int report(lua_State L, int status) {
            if(status != LUA_OK) {
                var msg = lua_tostring(L, -1);
                l_message(progname, msg.ToString());
                lua_pop(L, 1);
            }
            return status;
        }

        private static int msghandler (lua_State L) {
            var msg = lua_tostring (L, 1);
            if (msg == IntPtr.Zero) { /* is error object not a string? */
                if (luaL_callmeta (L, 1, "__tostring") != 0 && /* does it have a metamethod */
                    lua_type (L, -1) == LUA_TSTRING) /* that produces a string? */
                    return 1; /* that is the message */
                else
                    msg = lua_pushstring (L, string.Format ("(error object is a {0} value)",
                        luaL_typename (L, 1)));
            }
            luaL_traceback (L, L, msg.ToString (), 1); /* append a standard traceback */
            return 1; /* return the traceback */
        }

        private static int docall (lua_State L, int narg, int clear) {
            int status;
            int base_ = lua_gettop (L) - narg; /* function index */
            lua_pushcfunction (L, msghandler); /* push message handler */
            lua_insert (L, base_); /* put it under chunk and args */
            globalL = L;
            Console.CancelKeyPress += laction;
            status = lua_pcall (L, narg, ((clear != 0) ? 0 : LUA_MULTRET), base_);
            Console.CancelKeyPress -= laction;
            lua_remove (L, base_); /* remove message handler from the stack */
            return status;
        }

        /*private static void print_version() {
            Console.WriteLine(LUA_COPYRIGHT);
        }*/

        /*private static void createargtable(lua_State L, string[] argv, int argc, int script) {
            if(script == argc) script = 0;
            var narg = argc - (script + 1);
            lua_createtable(L, narg, script + 1);
            for(var i = 0; i < argc; i++) {
                lua_pushstring(L, argv[i]);
                lua_rawseti(L, -2, i - script);
            }
            lua_setglobal(L, "arg");
        }*/

        /*private static int dochunk(lua_State L, int status) {
            if(status == LUA_OK) status = docall(L, 0, 0);
            return report(L, status);
        }*/

        /*private static int dofile(lua_State L, string name) {
            return dochunk(L, luaL_loadfile(L, name));
        }*/

        /*private static int dostring(lua_State L, string s, string name) {
            return dochunk(L, luaL_loadbuffer(L, s, (uint)s.Length, name));
        }*/

        /*private static int dolibrary(lua_State L, string name) {
            lua_getglobal(L, "require");
            lua_pushstring(L, name);
            var status = docall(L, 1, 1);  // call 'require(name)' 
            if (status == LUA_OK)
                lua_setglobal(L, name);  // global[name] = require return 
            return report(L, status);
        }*/

        private static int pushargs(lua_State L) {
            if (lua_getglobal(L, "arg") != LUA_TTABLE)
                luaL_error(L, "'arg' is not a table");
            var n = (int)luaL_len(L, -1);
            luaL_checkstack(L, n + 3, "too many arguments to script");
            int i;
            for (i = 1; i <= n; i++)
                lua_rawgeti(L, -i, i);
            lua_remove(L, -i);  /* remove table from the stack */
                return n;
        }

        private static int handle_script(lua_State L, string[] argv, int n) {
            int status;
            var fname = argv[n];
            if(fname == "-" && argv[n - 1] != "--")
                fname = null;
            status = luaL_loadfile(L, fname);
            if(status == LUA_OK) {
                var n1 = pushargs(L);
                status = docall(L, n1, LUA_MULTRET);
            }
            return report(L, status);
        }

        /*private struct Args {
            public string[] args;
        }*/


        /*private static int pmain(lua_State L)
        {
            var argc = (int)lua_tointeger(L, 1);
            var argsPtr = lua_touserdata(L, 2);
            var a = Marshal.PtrToStructure<Args>(argsPtr);
            var argv = a.args;
            int script;
            var args = collectargs(argv, out script);
            luaL_checkversion(L);
            if(!string.IsNullOrEmpty(argv[0]) && args[0][0] != 0) progname = argv[0];
            if(args == has_error) {
                print_usage(argv[script]);
                return 0;
            }

            return 1;

        }*/
        
        private static void Main (string[] args) {
			if(args.Length == 0) {
                print_usage(" ");
                return;
            }
            var newargs = new List<string>(args);
			newargs.Insert(0, "lua");
            args = newargs.ToArray();
            
            var L = luaL_newstate();
            /*lua_pushcfunction(L, pmain);
            lua_pushinteger(L, args.Length);
            var a = new Args(){args = args};
            var aPtr = Marshal.AllocHGlobal (Marshal.SizeOf (a));
            Marshal.StructureToPtr(a, aPtr, false);
            lua_pushlightuserdata(L, aPtr);
            Marshal.FreeHGlobal (aPtr);
            var status = lua_pcall(L, 2, 1, 0);
            var result = lua_toboolean(L, -1);
            report(L, status);
            lua_close(L);*/

            handle_script(L, args, 1);            
        }
    }
}