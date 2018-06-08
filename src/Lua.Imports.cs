using System;
using System.Runtime.InteropServices;

namespace Lua.NET {
    public static partial class Lua {
        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern lua_State lua_newstate ();

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void lua_close (lua_State luaState);

        //lua_CFunction
        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr lua_atpanic (lua_State luaState, IntPtr panicf);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern double lua_version (lua_State luaState);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_absindex (lua_State luaState, int idx);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_gettop (lua_State luaState);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void lua_settop (lua_State luaState, int newTop);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void lua_pushvalue (lua_State luaState, int index);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void lua_rotate (lua_State luaState, int idx, int n);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void lua_copy (lua_State luaState, int fromidx, int toidx);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_checkstack (lua_State luaState, int extra);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void lua_xmove (lua_State from, lua_State to, int n);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_isnumber (lua_State luaState, int index);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_isstring (lua_State luaState, int index);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_iscfunction (lua_State luaState, int index);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_isinteger (lua_State luaState, int index);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_isuserdata (lua_State luaState, int index);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_type (lua_State luaState, int index);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CharPtr lua_typename (lua_State luaState, int type);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern double lua_tonumberx (lua_State luaState, int index, out int isnum);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern long lua_tointegerx (lua_State luaState, int index, out int isnum);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_toboolean (lua_State luaState, int index);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CharPtr lua_tolstring (lua_State luaState, int index, out uint strLen);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_rawlen (lua_State luaState, int index);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr lua_tocfunction (lua_State luaState, int index);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr lua_touserdata (lua_State luaState, int index);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr lua_tothread (lua_State luaState, int index);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr lua_topointer (lua_State luaState, int index);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void lua_arith (lua_State luaState, int op);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_rawequal (lua_State luaState, int idx1, int idx2);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_compare (lua_State luaState, int idx1, int idx2, int op);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void lua_pushnil (lua_State luaState);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void lua_pushnumber (lua_State luaState, double number);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void lua_pushinteger (lua_State luaState, long number);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CharPtr lua_pushlstring (lua_State luaState, string s, uint len);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CharPtr lua_pushstring (lua_State luaState, string str);

        //lua_pushvfstring
        //lua_pushfstring

        //lua_CFunction
        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void lua_pushcclosure (lua_State luaState, IntPtr fn, int n);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void lua_pushboolean (lua_State luaState, int value);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void lua_pushlightuserdata (lua_State luaState, IntPtr udata);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_pushthread (lua_State luaState);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_getglobal (lua_State luaState, string name);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_gettable (lua_State luaState, int index);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_getfield (lua_State luaState, int stackPos, string meta);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_geti (lua_State luaState, int idx, long n);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_rawget (lua_State luaState, int index);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_rawgeti (lua_State luaState, int tableIndex, long index);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_rawgetp (lua_State luaState, int idx, IntPtr p);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void lua_createtable (lua_State luaState, int narr, int nrec);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr lua_newuserdata (lua_State luaState, uint size);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_getmetatable (lua_State luaState, int objIndex);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_getuservalue (lua_State luaState, int idx);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void lua_setglobal (lua_State luaState, string name);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void lua_settable (lua_State luaState, int index);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void lua_setfield (lua_State luaState, int index);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void lua_seti (lua_State luaState, int index, long n);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void lua_rawset (lua_State luaState, int index);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void lua_rawseti (lua_State luaState, int tableIndex, long index);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void lua_rawsetp (lua_State luaState, int tableIndex, IntPtr p);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void lua_setmetatable (lua_State luaState, int objIndex);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void lua_setuservalue (lua_State luaState, int idx);

        //lua_KFunction
        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void lua_callk (lua_State L, int nargs, int nresults, long ctx, IntPtr k);

        //lua_KFunction
        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_pcallk (lua_State L, int nargs, int nresults, int errfunc, long ctx, IntPtr k);

        //lua_Reader
        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_load (lua_State L, IntPtr reader, IntPtr dt, string chunkname, string mode);

        //lua_Writer
        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_dump (lua_State L, IntPtr writer, IntPtr data, int strip);

        //lua_KFunction
        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_yieldk (lua_State L, int nresults, long ctx, IntPtr k);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_resume (lua_State L, lua_State from, int narg);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_status (lua_State L);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_isyieldable (lua_State L);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_gc (lua_State luaState, int what, int data);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void lua_error (lua_State luaState);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_next (lua_State luaState, int index);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void lua_concat (lua_State luaState, int n);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void lua_len (lua_State luaState, int idx);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern uint lua_stringtonumber (lua_State luaState, string s);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public extern static IntPtr lua_getallocf (lua_State L, IntPtr ud);

        //lua_Alloc
        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public extern static void lua_setallocf (lua_State L, IntPtr f, IntPtr ud);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_getstack (lua_State luaState, int level, IntPtr ar);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_getinfo (lua_State luaState, string what, IntPtr ar);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CharPtr lua_getlocal (lua_State luaState, IntPtr ar, int n);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CharPtr lua_setlocal (lua_State luaState, IntPtr ar, int n);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CharPtr lua_getupvalue (lua_State luaState, int funcindex, int n);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CharPtr lua_setupvalue (lua_State luaState, int funcindex, int n);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr lua_upvalueid (lua_State luaState, int fidx, int n);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void lua_upvaluejoin (lua_State luaState, int fidx1, int n1, int fidx2, int n2);

        //lua_Hook
        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void lua_sethook (lua_State luaState, IntPtr func, int mask, int count);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr lua_gethook (lua_State luaState);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_gethookmask (lua_State luaState);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int lua_gethookcount (lua_State luaState);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void luaL_openlibs (lua_State luaState);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void luaL_checkversion_ (lua_State luaState, double ver, uint sz);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int luaL_getmetafield (lua_State luaState, int stackPos, string field);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int luaL_callmeta (lua_State luaState, int obj, string e);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CharPtr luaL_tolstring (lua_State luaState, int idx, out uint len);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int luaL_argerror (lua_State luaState, int arg, string extramsg);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CharPtr luaL_checklstring (lua_State luaState, int arg, out uint len);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CharPtr luaL_optlstring (lua_State luaState, int arg, string def, out uint len);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern double luaL_checknumber (lua_State luaState, int arg);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern double luaL_optnumber (lua_State luaState, int arg, double def);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern long luaL_checkinteger (lua_State luaState, int arg);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern long luaL_optinteger (lua_State luaState, int arg, long def);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void luaL_checkstack (lua_State luaState, int sz, string msg);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void luaL_checktype (lua_State luaState, int arg, int t);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void luaL_checkany (lua_State luaState, int arg);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int luaL_newmetatable (lua_State luaState, string meta);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void luaL_setmetatable (lua_State luaState, string meta);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr luaL_testudata (lua_State luaState, int stackPos, string meta);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr luaL_checkudata (lua_State luaState, int stackPos, string meta);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void luaL_where (lua_State luaState, int level);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int luaL_error (lua_State luaState, string message);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int luaL_checkoption (lua_State luaState, int arg, string def, string[] lst);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int luaL_fileresult (lua_State luaState, int stat, string fname);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int luaL_execresult (lua_State luaState, int stat);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int luaL_ref (lua_State luaState, int registryIndex);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void luaL_unref (lua_State luaState, int registryIndex, int reference);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int luaL_loadfilex (lua_State luaState, string filename, string mode);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int luaL_loadbufferx (lua_State luaState, string buff, uint sz, string name, string mode);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int luaL_loadstring (lua_State luaState, string chunk);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int luaL_loadstring (lua_State luaState, byte[] chunk);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern lua_State luaL_newstate ();

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern long luaL_len (lua_State luaState, int idx);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CharPtr luaL_gsub (lua_State luaState, string s, string p, string r);

        //l = luaL_Reg[]
        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void luaL_setfuncs (lua_State luaState, IntPtr[] l, int nup);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int luaL_getsubtable (lua_State luaState, string fname);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void luaL_traceback (lua_State luaState, lua_State L1, string msg, int level);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void luaL_requiref (lua_State luaState, string modname, IntPtr openf, int glb);

        //luaL_buffinit

        //luaL_prepbuffsize

        //luaL_addlstring

        //luaL_addstring

        //luaL_addvalue

        //luaL_pushresult

        //luaL_pushresultsize

        //luaL_buffinitsize

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void luaL_pushmodule (lua_State luaState, string modname, int sizehint);

        //l = luaL_Reg[]
        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void luaL_openlib (lua_State luaState, string libname, IntPtr[] l, int nup);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int luaopen_base (lua_State luaState);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int luaopen_coroutine (lua_State luaState);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int luaopen_table (lua_State luaState);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int luaopen_io (lua_State luaState);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int luaopen_os (lua_State luaState);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int luaopen_string (lua_State luaState);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int luaopen_utf8 (lua_State luaState);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int luaopen_bit32 (lua_State luaState);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int luaopen_math (lua_State luaState);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int luaopen_debug (lua_State luaState);

        [DllImport (LIBNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int luaopen_package (lua_State luaState);
    }
}