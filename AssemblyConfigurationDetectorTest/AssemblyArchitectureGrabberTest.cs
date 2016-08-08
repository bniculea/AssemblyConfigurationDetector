using AssemblyConfigurationDetector;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssemblyConfigurationDetectorTest
{
    [TestClass]
    public class AssemblyArchitectureGrabberTest
    {
        [TestMethod]
        [DeploymentItem("TestFiles")]
        public void AnyCpuAssembly_GetMachineType_CorrectMachineTypeReturned()
        {
            AssemblyArchitectureGrabber assemblyArchitectureGrabber = new AssemblyArchitectureGrabber();
            MachineType actualMachineType = assemblyArchitectureGrabber.GetAssemblyMachineType("AnyCpu.dll");
            MachineType expectedMachineType = MachineType.ImageFileMachineI386;

            Assert.AreEqual(expectedMachineType, actualMachineType);
        }

        [TestMethod]
        [DeploymentItem("TestFiles")]
        public void X86Assembly_GetMachineType_CorrectMachineTypeReturned()
        {
            AssemblyArchitectureGrabber assemblyArchitectureGrabber = new AssemblyArchitectureGrabber();
            MachineType actualMachineType = assemblyArchitectureGrabber.GetAssemblyMachineType("X86Assembly.dll");
            MachineType expectedMachineType = MachineType.ImageFileMachineI386;

            Assert.AreEqual(expectedMachineType, actualMachineType);
        }

        [TestMethod]
        [DeploymentItem("TestFiles")]
        public void X64Assembly_GetMachineType_CorrectMachineTypeReturned()
        {
            AssemblyArchitectureGrabber assemblyArchitectureGrabber = new AssemblyArchitectureGrabber();
            MachineType actualMachineType = assemblyArchitectureGrabber.GetAssemblyMachineType("X64Assembly.dll");
            MachineType expectedMachineType = MachineType.ImageFileMachineAmd64;

            Assert.AreEqual(expectedMachineType, actualMachineType);
        }

        [TestMethod]
        [DeploymentItem("TestFiles")]
        public void DUMDUMDUm()
        {
            AssemblyArchitectureGrabber assemblyArchitectureGrabber = new AssemblyArchitectureGrabber();

            ushort val = assemblyArchitectureGrabber.GetImageArchitecture("AnyCpu.dll");
            ushort val2 = assemblyArchitectureGrabber.GetImageArchitecture("X86Assembly.dll");
            ushort val3 = assemblyArchitectureGrabber.GetImageArchitecture("X64Assembly.dll");
            

        }
    }
}
