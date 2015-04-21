
using System;
using System.IO;
using System.Reflection;

namespace SAB.Utility
{
	public static class UtilPath
	{
		public static string AssemblyDirectory
		{
			get
			{
				string codeBase = Assembly.GetExecutingAssembly().CodeBase;
				var uri = new UriBuilder(codeBase);
				string path = Uri.UnescapeDataString(uri.Path);
				return Path.GetDirectoryName(path);
			}
		}

		public static string TestOutputDirectory
		{
			get
			{
				return Path.Combine(AssemblyDirectory, @"..\..\..\TestOutput\");
			}
		}
	}
}
