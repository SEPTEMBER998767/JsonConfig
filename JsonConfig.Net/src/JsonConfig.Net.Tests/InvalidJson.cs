using System.Runtime.Serialization;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace JsonConfig.Net.Tests
{
	[TestFixture()]
	public class InvalidJson
	{
		[Test]
        public void EvidentlyInvalidJson ()
		{
			dynamic scope = Config.Global;
			Assert.Throws<Newtonsoft.Json.JsonReaderException>(()=> scope.ApplyJson ("jibberisch"));
		}
        [Test]
		public void MissingObjectIdentifier()
		{	
			dynamic scope = Config.Global;
			var invalid_json = @" { [1, 2, 3] }";
		    Assert.Throws<Newtonsoft.Json.JsonReaderException>(() => scope.ApplyJson(invalid_json));
		}
	}
}

