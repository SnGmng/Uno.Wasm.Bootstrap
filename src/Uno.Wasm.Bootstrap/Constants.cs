﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Uno.Wasm.Bootstrap
{
	internal class Constants
	{
		// NOTE: The SDK version may be overriden by an installation of the https://www.nuget.org/packages/Uno.Wasm.MonoRuntime nuget package
		public const string DefaultSdkUrl = @"https://unowasmbootstrap.azureedge.net/runtime/mono-wasm-9c2187f3d7d.zip";
		public const string DefaultAotSDKUrl = @"https://unowasmbootstrap.azureedge.net/runtime/wasm-release-Linux-9c2187f3d7d65d8192ca107111bba673fe715797.zip";

		/// <summary>
		/// Min version of the emscripten SDK. Must be aligned with mono's SDK build in <see cref="DefaultAotSDKUrl"/>.
		/// </summary>
		/// <remarks>
		/// The emscripten version use by mono can be found here:
		/// https://github.com/mono/mono/blob/master/sdks/builds/wasm.mk#L4
		/// </remarks>
		public static Version EmscriptenMinVersion { get; } = new Version("1.39.18");
	}
}
