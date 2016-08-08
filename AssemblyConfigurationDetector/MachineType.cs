namespace AssemblyConfigurationDetector
{
    public enum MachineType : ushort
    {
        ImageFileMachineUnknown = 0x0,
        ImageFileMachineAm33 = 0x1d3,
        ImageFileMachineAmd64 = 0x8664,
        ImageFileMachineArm = 0x1c0,
        ImageFileMachineEbc = 0xebc,
        ImageFileMachineI386 = 0x14c,
        ImageFileMachineIa64 = 0x200,
        ImageFileMachineM32R = 0x9041,
        ImageFileMachineMips16 = 0x266,
        ImageFileMachineMipsfpu = 0x366,
        ImageFileMachineMipsfpu16 = 0x466,
        ImageFileMachinePowerpc = 0x1f0,
        ImageFileMachinePowerpcfp = 0x1f1,
        ImageFileMachineR4000 = 0x166,
        ImageFileMachineSh3 = 0x1a2,
        ImageFileMachineSh3Dsp = 0x1a3,
        ImageFileMachineSh4 = 0x1a6,
        ImageFileMachineSh5 = 0x1a8,
        ImageFileMachineThumb = 0x1c2,
        ImageFileMachineWcemipsv2 = 0x169
    }
}
