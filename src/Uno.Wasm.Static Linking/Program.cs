using System;
using System.Runtime.InteropServices;
using WebAssembly;

namespace Uno.Wasm.Sample
{ 
    public static class Program
    {
		[DllImport("side")]
		private static extern int test_add(int a, int b);
		[DllImport("side", EntryPoint = "test_add_float")]
		private static extern float test_add_float1(float a, float b);
		[DllImport("side")]
		private static extern double test_add_double(double a, double b);
		[DllImport("side")]
		private static extern int test_exception();
		[DllImport("side")]
		private static extern void test_png();

		static void Main()
		{
			var runtimeMode = Environment.GetEnvironmentVariable("UNO_BOOTSTRAP_MONO_RUNTIME_MODE");
			Console.WriteLine("Mono Runtime Mode: " + runtimeMode);

			Console.WriteLine($"test_add:{test_add(21, 21)}");
			Console.WriteLine($"test_float:{test_add_float1(21, 21)}");
			Console.WriteLine($"test_add_double:{test_add_double(21, 21)}");

			var now = DateTime.Now;
			Console.WriteLine($"now:{now} +1:{now.AddDays(1)} -1:{now.AddDays(-1)}");

			var validateEmAddFunctionResult = int.Parse(Runtime.InvokeJS($"Validation.validateEmAddFunction()", out var result2)) != 0;

			var idbFSValidation = Runtime.InvokeJS($"typeof IDBFS !== 'undefined'", out var _);

			var res = $"{runtimeMode};{test_add(21, 21)};{test_add_float1(21.1f, 21.2f)};{test_add_double(21.3, 21.4)};e{test_exception()};{validateEmAddFunctionResult};{idbFSValidation}";

			Runtime.InvokeJS($"Interop.appendResult(\"{res}\")", out var result);

			test_png();
		}
	}
}
