namespace Lua.NET {
    public static partial class Lua {
        static Lua () {
            DynamicLibraryPath.RegisterPathForDll (LIBNAME);
        }
    }
}