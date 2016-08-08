using System.Reflection;
using AssemblyConfigurationDetector;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssemblyConfigurationDetectorTest
{
    [TestClass]
    public class CorFlagsReaderTest
    {
        [TestMethod]
        [DeploymentItem("TestFiles")]
        public void AnyCpuAssembly_IsPureMSILAndPE32_IsTrue()
        {
            CorFlagsReader corFlagsReader = CorFlagsReader.ReadAssemblyMetadata("AnyCpu.dll");

            Assert.IsTrue(corFlagsReader.GetGeneralMachineType() == GeneralMachineType.AnyCpu);
        }

        [TestMethod]
        [DeploymentItem("TestFiles")]
        public void X86ManagedAssembly_IsNotPureMsilAndIsx86Architecture_IsTrue()
        {
            CorFlagsReader corFlagsReader = CorFlagsReader.ReadAssemblyMetadata("X86Assembly.dll");

            Assert.IsTrue(corFlagsReader.GetGeneralMachineType() == GeneralMachineType.X86);
        }

        [TestMethod]
        [DeploymentItem("TestFiles")]
        public void X64ManagedAssembly_IsNotPureMsilAndIsx86Architecture_IsTrue()
        {
            CorFlagsReader corFlagsReader = CorFlagsReader.ReadAssemblyMetadata("X64Assembly.dll");

            Assert.IsTrue(corFlagsReader.GetGeneralMachineType() == GeneralMachineType.X64);
        }

        [TestMethod]
        [DeploymentItem("TestFiles")]
        public void X64UnmanagedAssembly_IsNotPureMsilAndIsx86Architecture_IsTrue()
        {
            CorFlagsReader corFlagsReader = CorFlagsReader.ReadAssemblyMetadata("X64UnmanagedAssembly.dll");

            Assert.IsTrue(corFlagsReader.GetGeneralMachineType() == GeneralMachineType.X64);
        }

        [TestMethod]
        [DeploymentItem("TestFiles")]
        public void X86UnmanagedAssembly_IsNotPureMsilAndIsx86Architecture_IsTrue()
        {
            CorFlagsReader corFlagsReader = CorFlagsReader.ReadAssemblyMetadata("X86UnmanagedAssembly.dll");

            Assert.IsTrue(corFlagsReader.GetGeneralMachineType() == GeneralMachineType.X86);
        }
    }
}
