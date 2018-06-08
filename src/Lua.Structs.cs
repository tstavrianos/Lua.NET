using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Lua.NET {
    public static partial class Lua {
        public struct lua_State {
            private IntPtr state;
            public lua_State (IntPtr ptr) {
                this.state = ptr;
            }

            static public implicit operator lua_State (IntPtr ptr) {
                return new lua_State (ptr);
            }

            static public implicit operator IntPtr (lua_State ptr) {
                return ptr.state;
            }
        }

        public struct CharPtr {
            public CharPtr (IntPtr ptrString) : this () {
                str = ptrString;
            }

            static public implicit operator CharPtr (IntPtr ptr) {
                return new CharPtr (ptr);
            }

            static public implicit operator IntPtr (CharPtr ptr) {
                return ptr.str;
            }

            public static string StringFromNativeUtf8 (IntPtr nativeUtf8, int len = 0) {
                if (len == 0) {
                    while (System.Runtime.InteropServices.Marshal.ReadByte (nativeUtf8, len) != 0)
                        ++len;
                }

                if (len == 0)
                    return string.Empty;

                byte[] buffer = new byte[len];
                System.Runtime.InteropServices.Marshal.Copy (nativeUtf8, buffer, 0, buffer.Length);

                return Encoding.UTF8.GetString (buffer, 0, len);
            }

            static private string PointerToString (IntPtr ptr) {
                return System.Runtime.InteropServices.Marshal.PtrToStringAnsi (ptr);
            }

            static private string PointerToString (IntPtr ptr, int length) {
                return System.Runtime.InteropServices.Marshal.PtrToStringAnsi (ptr, length);
            }

            static private byte[] PointerToBuffer (IntPtr ptr, int length) {
                byte[] buff = new byte[length];
                System.Runtime.InteropServices.Marshal.Copy (ptr, buff, 0, length);
                return buff;
            }

            public override string ToString () {
                if (str == IntPtr.Zero)
                    return "";

                return PointerToString (str);
            }

            // Changed 2013-05-18 by Dirk Weltz
            // Changed because binary chunks, which are also transfered as strings
            // get corrupted by conversion to strings because of the encoding.
            public string ToString (int length) {
                if (str == IntPtr.Zero)
                    return "";

                byte[] buff = PointerToBuffer (str, length);
                // Are the first four bytes "ESC Lua". If yes, than it is a binary chunk.
                // Didn't check on version of Lua, because it isn't relevant.
                if (length > 3 && buff[0] == 0x1B && buff[1] == 0x4C && buff[2] == 0x75 && buff[3] == 0x61) {
                    // It is a binary chunk
                    StringBuilder s = new StringBuilder (length);
                    foreach (byte b in buff)
                        s.Append ((char) b);
                    return s.ToString ();
                } else
                    return PointerToString (str, length);
            }

            IntPtr str;
        }

        [StructLayout (LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct lua_Debug {
            public int @event;
			public CharPtr name;
			public CharPtr namewhat;
			public CharPtr what;
			public CharPtr source;
			public int currentline;
			public int linedefined;
			public int lastlinedefined;
			public byte nups;
			public byte nparams;
			public sbyte isvararg;
			public sbyte istailcall;
			[MarshalAs (UnmanagedType.ByValTStr, SizeConst = LUA_IDSIZE)]
			public string short_src;
			public IntPtr i_ci;
		}

        [StructLayout (LayoutKind.Sequential)]
		public struct luaL_Reg {
			public CharPtr name;
			//lua_CFunction
			public IntPtr func;
			public lua_CFunction Func {
				get {
					return func == IntPtr.Zero ? null : Marshal.GetDelegateForFunctionPointer<lua_CFunction> (func);
				}
				set {
					func = value == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate (value);
				}
			}
		}
        
    }
}