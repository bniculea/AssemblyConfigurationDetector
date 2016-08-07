using AssemblyConfigurationDetector;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssemblyConfigurationDetectorTest
{
    [TestClass]
    public class AssemblyValidatorTest
    {
        [TestMethod]
        [DeploymentItem("TestFiles")]
        public void XmlAsAssembly_IsValid_ReturnsFalse()
        {
            AssemblyValidator assemblyValidator = new AssemblyValidator();

            bool actual = assemblyValidator.IsValid("XmlAsDll.dll");
            bool expected = false;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DeploymentItem("TestFiles")]
        public void ValidAssembly_IsValid_ReturnsTrue()
        {
            AssemblyValidator assemblyValidator = new AssemblyValidator();

            bool actual = assemblyValidator.IsValid("ValidAssembly.dll");
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DeploymentItem("TestFiles")]
        public void ValidAssembly_IsValidMultipleCalls_NoExceptionThrown()
        {
            AssemblyValidator assemblyValidator = new AssemblyValidator();

            assemblyValidator.IsValid("ValidAssembly.dll");
            assemblyValidator.IsValid("ValidAssembly.dll");
            assemblyValidator.IsValid("ValidAssembly.dll");
            assemblyValidator.IsValid("ValidAssembly.dll");
      
        }
    }
}
