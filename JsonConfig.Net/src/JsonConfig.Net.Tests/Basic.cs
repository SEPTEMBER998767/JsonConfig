using System;
using System.IO;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace JsonConfig.Net.Tests
{
	[TestFixture]
	public abstract class BaseTest
	{
	    private static Assembly _testAssembly;
	    private static Assembly TestAssembly => _testAssembly ?? GetTestAssembly();

	    public static dynamic GetUUT(string name)
		{
			// read in all our JSON objects
			var jsonTests = TestAssembly.GetManifestResourceStream ("JsonConfig.Net.Tests.JSON." + name + ".json");
			var sReader = new StreamReader (jsonTests);
			return Config.ApplyJson (sReader.ReadToEnd (), new ConfigObject ());
		}

	    public Stream GetJsonStream(string name)
	    {
	        return TestAssembly.GetManifestResourceStream(name);
        }

        public static Assembly GetTestAssembly()
	    {
	        try
	        {
	            var executionPath = "D:\\Projects\\" +
	                                "JsonConfig\\JsonConfig.Net\\src\\JsonConfig.Net.Tests\\bin\\Debug\\netcoreapp1.0";
	            var exeFolder = new DirectoryInfo(executionPath);
	            var pluginAssemblyFile =
	                exeFolder.GetFiles("JsonConfig.Net.Tests.dll", SearchOption.AllDirectories).FirstOrDefault();
	            var asm =
	                _testAssembly =
	                    System.Runtime.Loader.AssemblyLoadContext.Default.LoadFromAssemblyPath(pluginAssemblyFile.FullName);
                return asm;
            }
	        catch
	        {
	            throw new Exception("Set The Project Solution Folder Path in Basic.cs file");
	        }
	       
	        
	    }
	
		
		[SetUp]
		public void SetUp ()
		{
		}
		[TearDown]
		public void TearDown ()
		{
		}
	}
	
}

