using System;
using Xunit;

namespace Serialization.Tests
{
    public class UnitTest1
    {
        // c# has something called "attributes"
        // things you can put in brackets on top of stuff like methods
        // 
        [Fact] // marks this method for xUnit as a test method
        public void TrueShouldBeTrue()
        {
            Assert.True(true);
        }
            
        // (doesn't say "Fact" so this isn't a test method)
        public static void HelperMethod()
        {

        }
    }
}
