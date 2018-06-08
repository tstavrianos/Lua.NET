namespace Lua.NET {
    public static partial class Lua {
#if DEBUGLUA
        const string LIBNAME = "lua53d";
#else
        const string LIBNAME = "lua53";
#endif

        public const string LUA_VERSION_MAJOR = "5";
        public const string LUA_VERSION_MINOR = "3";
        public const string LUA_VERSION_RELEASE = "4";
        public const double LUA_VERSION_NUM = 503;
        public static readonly string LUA_VERSION = $"Lua {LUA_VERSION_MAJOR}.{LUA_VERSION_MINOR}";
        public static readonly string LUA_RELEASE = $"{LUA_VERSION}.{LUA_VERSION_RELEASE}";
        public static readonly string LUA_COPYRIGHT = $"{LUA_RELEASE} Copyright (C) 1994-2017 Lua.org, PUC-Rio";
        public const string LUA_AUTHORS = "R. Ierusalimschy, L. H. de Figueiredo, W. Celes";

        public const int LUA_OK = 0;
        public const int LUA_YIELD = 1;
        public const int LUA_ERRRUN = 2;
        public const int LUA_ERRSYNTAX = 3;
        public const int LUA_ERRMEM = 4;
        public const int LUA_ERRGCMM = 5;
        public const int LUA_ERRERR = 6;
        public const int LUA_TNONE = (-1);
        public const int LUA_TNIL = 0;
        public const int LUA_TBOOLEAN = 1;
        public const int LUA_TLIGHTUSERDATA = 2;
        public const int LUA_TNUMBER = 3;
        public const int LUA_TSTRING = 4;
        public const int LUA_TTABLE = 5;
        public const int LUA_TFUNCTION = 6;
        public const int LUA_TUSERDATA = 7;
        public const int LUA_TTHREAD = 8;
        public const int LUA_NUMTAGS = 9;
        public const int LUA_MINSTACK = 20;
        public const int LUA_RIDX_MAINTHREAD = 1;
        public const int LUA_RIDX_GLOBALS = 2;
        public const int LUA_RIDX_LAST = LUA_RIDX_GLOBALS;
        public const int LUA_OPADD = 0;
        public const int LUA_OPSUB = 1;
        public const int LUA_OPMUL = 2;
        public const int LUA_OPMOD = 3;
        public const int LUA_OPPOW = 4;
        public const int LUA_OPDIV = 5;
        public const int LUA_OPIDIV = 6;
        public const int LUA_OPBAND = 7;
        public const int LUA_OPBOR = 8;
        public const int LUA_OPBXOR = 9;
        public const int LUA_OPSHL = 10;
        public const int LUA_OPSHR = 11;
        public const int LUA_OPUNM = 12;
        public const int LUA_OPBNOT = 13;
        public const int LUA_OPEQ = 0;
        public const int LUA_OPLT = 1;
        public const int LUA_OPLE = 2;
        public const int LUA_GCSTOP = 0;
        public const int LUA_GCRESTART = 1;
        public const int LUA_GCCOLLECT = 2;
        public const int LUA_GCCOUNT = 3;
        public const int LUA_GCCOUNTB = 4;
        public const int LUA_GCSTEP = 5;
        public const int LUA_GCSETPAUSE = 6;
        public const int LUA_GCSETSTEPMUL = 7;
        public const int LUA_GCISRUNNING = 9;
        public const int LUA_HOOKCALL = 0;
        public const int LUA_HOOKRET = 1;
        public const int LUA_HOOKLINE = 2;
        public const int LUA_HOOKCOUNT = 3;
        public const int LUA_HOOKTAILCALL = 4;
        public const int LUA_MULTRET = -1;
        public const int LUAI_MAXSTACK = 1000000;
        public const int LUA_REGISTRYINDEX = -LUAI_MAXSTACK - 1000;
        public const int LUA_IDSIZE = 60;
        public const int LUA_MASKCALL = (1 << LUA_HOOKCALL);
        public const int LUA_MASKRET = (1 << LUA_HOOKRET);
        public const int LUA_MASKLINE = (1 << LUA_HOOKLINE);
        public const int LUA_MASKCOUNT = (1 << LUA_HOOKCOUNT);
        public const uint LUAL_NUMSIZES = sizeof (long) * 16 + sizeof (double);
        public const int LUA_NOREF = -2;
        public const int LUA_REFNIL = -1;
    }
}