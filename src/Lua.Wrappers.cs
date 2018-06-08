using System;
using System.Runtime.InteropServices;

namespace Lua.NET {
    public static partial class Lua {
        public static lua_CFunction lua_atpanic (lua_State luaState, lua_CFunction panicf) {
            var ptr = Marshal.GetFunctionPointerForDelegate (panicf);
            var res = lua_atpanic (luaState, ptr);
            if (res == IntPtr.Zero) return null;
            return Marshal.GetDelegateForFunctionPointer<lua_CFunction> (res);
        }

        public static void lua_pushcclosure (lua_State luaState, lua_CFunction fn, int n) => lua_pushcclosure (luaState, fn == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate (fn), n);

        public static void lua_callk (lua_State L, int nargs, int nresults, long ctx, lua_KFunction k) =>
            lua_callk (L, nargs, nresults, ctx, k == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate (k));
        
        public static void lua_call (lua_State L, int nargs, int nresults) => lua_callk (L, nargs, nresults, 0, IntPtr.Zero);

        public static void lua_pcallk (lua_State L, int nargs, int nresults, int errfunc, long ctx, lua_KFunction k) =>
            lua_pcallk (L, nargs, nresults, errfunc, ctx, k == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate (k));
        
        public static int lua_pcall (lua_State L, int nargs, int nresults, int errfunc) => lua_pcallk (L, nargs, nresults, errfunc, 0, IntPtr.Zero);

        public static int lua_load (lua_State L, lua_Reader reader, IntPtr dt, string chunkname, string mode) =>
            lua_load (L, reader == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate (reader), dt, chunkname, mode);

        public static int lua_dump (lua_State L, lua_Writer writer, IntPtr data, int strip) =>
            lua_dump (L, writer == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate (writer), data, strip);

        public static int lua_yieldk (lua_State L, int nresults, int errfunc, long ctx, lua_KFunction k) =>
            lua_yieldk (L, nresults, ctx, k == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate (k));
        
        public static int lua_yield (lua_State L, int nresults) => lua_yieldk (L, nresults, 0, IntPtr.Zero);

        public static void lua_setallocf (lua_State L, lua_Alloc f, IntPtr ud) =>
            lua_setallocf (L, f == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate (f), ud);

        public static double lua_tonumber (lua_State state, int i) {
            int r;
            return lua_tonumberx (state, i, out r);
        }

        public static long lua_tointeger (lua_State state, int i) {
            int r;
            return lua_tointegerx (state, i, out r);
        }

        public static void lua_pop (lua_State state, int n) => lua_settop (state, -n - 1);
        
        public static void lua_newtable (lua_State state) => lua_createtable (state, 0, 0);

        //lua_CFunction
        public static void lua_register (lua_State state, string n, IntPtr f) {
            lua_pushcfunction (state, f);
            lua_setglobal (state, n);
        }

        public static void lua_register (lua_State state, string n, lua_CFunction f) {
            lua_pushcfunction (state, f);
            lua_setglobal (state, n);
        }

        //lua_CFunction
        public static void lua_pushcfunction (lua_State L, IntPtr f) => lua_pushcclosure (L, f, 0);
        
        public static void lua_pushcfunction (lua_State L, lua_CFunction f) => lua_pushcclosure (L, f, 0);
        
        public static bool lua_isfunction (lua_State L, int n) => lua_type(L, n) == LUA_TFUNCTION;

        public static bool lua_istable (lua_State L, int n) => lua_type(L, n) == LUA_TTABLE;

        public static bool lua_islightuserdata (lua_State L, int n) => lua_type(L, n) == LUA_TLIGHTUSERDATA;

        public static bool lua_isnil (lua_State L, int n) => lua_type(L, n) == LUA_TNIL;

        public static bool lua_isboolean (lua_State L, int n) => lua_type(L, n) == LUA_TBOOLEAN;

        public static bool lua_isthread (lua_State L, int n) => lua_type(L, n) == LUA_TTHREAD;

        public static bool lua_isnone (lua_State L, int n) => lua_type(L, n) == LUA_TNONE;

        public static bool lua_isnoneornil (lua_State L, int n) => lua_type(L, n) <= 0;
        
        public static CharPtr lua_pushliteral(lua_State L, string s) => lua_pushstring(L, s ?? string.Empty);

        public static int lua_pushglobaltable(lua_State L) => lua_rawgeti(L, LUA_REGISTRYINDEX, LUA_RIDX_GLOBALS);

        public static CharPtr lua_tostring (lua_State luaState, int index) {
            uint dummy;
            return lua_tolstring (luaState, index, out dummy);
        }

        public static void lua_insert (lua_State L, int idx) => lua_rotate (L, idx, 1);
        
        public static void lua_remove (lua_State L, int idx) {
            lua_rotate (L, idx, -1);
            lua_pop (L, 1);
        }
        
        public static void lua_replace (lua_State L, int idx) {
            lua_copy (L, -1, idx);
            lua_pop (L, 1);
        }

        public static int lua_getstack (lua_State luaState, int level, ref lua_Debug ar) {

            IntPtr pDebug = Marshal.AllocHGlobal (Marshal.SizeOf (ar));
            var ret = 0;

            try {
                Marshal.StructureToPtr (ar, pDebug, false);
                ret = lua_getstack (luaState, level, pDebug);
                ar = Marshal.PtrToStructure<lua_Debug> (pDebug);

            } finally {
                Marshal.FreeHGlobal (pDebug);
            }
            return ret;
        }

        public static int lua_getinfo (lua_State luaState, string what, ref lua_Debug ar) {
            IntPtr pDebug = Marshal.AllocHGlobal (Marshal.SizeOf (ar));
            int ret = 0;

            try {
                Marshal.StructureToPtr (ar, pDebug, false);
                ret = lua_getinfo (luaState, what, pDebug);
                ar = Marshal.PtrToStructure<lua_Debug> (pDebug);
            } finally {
                Marshal.FreeHGlobal (pDebug);
            }
            return ret;
        }

        public static CharPtr lua_getlocal (lua_State luaState, lua_Debug ar, int n) {

            IntPtr pDebug = Marshal.AllocHGlobal (Marshal.SizeOf (ar));
            CharPtr local = IntPtr.Zero;

            try {
                Marshal.StructureToPtr (ar, pDebug, false);
                local = lua_getlocal (luaState, pDebug, n);

            } finally {
                Marshal.FreeHGlobal (pDebug);
            }
            return local;
        }

        public static CharPtr lua_setlocal (lua_State luaState, lua_Debug ar, int n) {
            IntPtr pDebug = Marshal.AllocHGlobal (Marshal.SizeOf (ar));
            CharPtr local = IntPtr.Zero;

            try {
                Marshal.StructureToPtr (ar, pDebug, false);
                local = lua_setlocal (luaState, pDebug, n);

            } finally {
                Marshal.FreeHGlobal (pDebug);
            }
            return local;
        }

        public static void lua_sethook (lua_State luaState, lua_Hook func, int mask, int count) => lua_sethook (luaState, func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate (func), mask, count);

        public static void luaL_checkversion (lua_State L) => luaL_checkversion_ (L, LUA_VERSION_NUM, LUAL_NUMSIZES);

        public static int luaL_loadfile (lua_State luaState, string filename) => luaL_loadfilex (luaState, filename, null);

        public static void luaL_requiref (lua_State luaState, string modname, lua_CFunction openf, int glb) => luaL_requiref (luaState, modname, openf == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate (openf), glb);

        //l = luaL_Reg[]
        public static void luaL_newlibtable (lua_State L, IntPtr[] l) => lua_createtable (L, 0, l.Length);

        //l = luaL_Reg[]
        public static void luaL_newlib (lua_State L, IntPtr[] l) {
            luaL_checkversion (L);
            luaL_newlibtable (L, l);
            luaL_setfuncs (L, l, 0);
        }

        public static void luaL_argcheck (lua_State L, bool cond, int arg, string extramsg) {
            if (!cond) luaL_argerror (L, arg, extramsg);
        }

        public static CharPtr luaL_checkstring (lua_State L, int n) {
            uint dummy;
            return luaL_checklstring (L, n, out dummy);
        }

        public static CharPtr luaL_optstring (lua_State L, int n, string def) {
            uint dummy;
            return luaL_optlstring (L, n, def, out dummy);
        }

        public static CharPtr luaL_typename (lua_State L, int idx) => lua_typename (L, lua_type (L, (idx)));

        public static int luaLdofile (lua_State L, string fn) {
            var res = luaL_loadfile (L, fn);
            if (res == LUA_OK)
                return lua_pcall (L, 0, LUA_MULTRET, 0);
            return res;
        }

        public static int luaL_dostring (lua_State L, string s) {
            var res = luaL_loadstring (L, s);
            if (res == LUA_OK)
                return lua_pcall (L, 0, LUA_MULTRET, 0);
            return res;
        }

        public static int luaL_getmetatable (lua_State L, string n) => lua_getfield (L, LUA_REGISTRYINDEX, (n));

        public static int luaL_loadbuffer (lua_State L, string s, uint sz, string n) => luaL_loadbufferx (L, s, sz, n, null);
    }
}