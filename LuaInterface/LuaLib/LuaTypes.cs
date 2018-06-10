/*
 * This file is part of LuaInterface.
 * 
 * Copyright (C) 2003-2005 Fabio Mascarenhas de Queiroz.
 * Copyright (C) 2009 Joshua Simmons <simmons.44@gmail.com>
 * Copyright (C) 2012 Megax <http://megax.yeahunter.hu/>
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.  IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using LuaInterface.Extensions;
using LuaCore = Lua.NET.Lua;
namespace LuaInterface
{
	public enum LuaTypes : int
	{
		None 			= LuaCore.LUA_TNONE,
		Nil 			= LuaCore.LUA_TNIL,
		Boolean 		= LuaCore.LUA_TBOOLEAN,
		LightUserdata	= LuaCore.LUA_TLIGHTUSERDATA,
		Number 			= LuaCore.LUA_TNUMBER,
		String 			= LuaCore.LUA_TSTRING,
		Table 			= LuaCore.LUA_TTABLE,
		Function 		= LuaCore.LUA_TFUNCTION,
		UserData 		= LuaCore.LUA_TUSERDATA,
		Thread 			= LuaCore.LUA_TTHREAD
	}
}