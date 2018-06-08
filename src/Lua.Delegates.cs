using System;
using System.Runtime.InteropServices;

namespace Lua.NET {
    public static partial class Lua {
        //ar = lua_Debug*
        [UnmanagedFunctionPointer (System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public delegate void lua_Hook (lua_State L, IntPtr ar);
        [UnmanagedFunctionPointer (System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public delegate int lua_CFunction (lua_State L);
        [UnmanagedFunctionPointer (System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public delegate int lua_KFunction (lua_State L, int status, long ctx);
        [UnmanagedFunctionPointer (System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public delegate IntPtr lua_Reader (lua_State L, IntPtr ud, ref uint sz);
        [UnmanagedFunctionPointer (System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public delegate int lua_Writer (lua_State L, IntPtr ar);
        [UnmanagedFunctionPointer (System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public delegate IntPtr lua_Alloc (lua_State L, IntPtr p, uint sz, IntPtr ud);
    }
}