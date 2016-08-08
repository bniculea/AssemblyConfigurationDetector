using System;
using System.IO;

namespace AssemblyConfigurationDetector
{
    public class AssemblyArchitectureGrabber
    {
        public MachineType GetAssemblyMachineType(string assemblyPath)
        {
            using (FileStream fileStream = new FileStream(assemblyPath, FileMode.Open, FileAccess.Read))
            using (BinaryReader binaryReader = new BinaryReader(fileStream))
            {
                fileStream.Seek(0x3c, SeekOrigin.Begin);
                Int32 peOffset = binaryReader.ReadInt32();
                fileStream.Seek(peOffset, SeekOrigin.Begin);
                UInt32 peHead = binaryReader.ReadUInt32();

                if (peHead != 0x00004550) //// "PE\0\0", little-endian
                {
                    throw new Exception("Can't find pe header");
                }

                MachineType machineType = (MachineType) binaryReader.ReadUInt16();

                return machineType;
            }
        }

        public ushort GetImageArchitecture(string filepath)
        {
            using (var stream = new System.IO.FileStream(filepath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            using (var reader = new System.IO.BinaryReader(stream))
            {
                //check the MZ signature to ensure it's a valid Portable Executable image
                if (reader.ReadUInt16() != 23117)
                    throw new BadImageFormatException("Not a valid Portable Executable image", filepath);

                // seek to, and read, e_lfanew then advance the stream to there (start of NT header)
                stream.Seek(0x3A, System.IO.SeekOrigin.Current);
                stream.Seek(reader.ReadUInt32(), System.IO.SeekOrigin.Begin);

                // Ensure the NT header is valid by checking the "PE\0\0" signature
                if (reader.ReadUInt32() != 17744)
                    throw new BadImageFormatException("Not a valid Portable Executable image", filepath);

                // seek past the file header, then read the magic number from the optional header
                stream.Seek(20, System.IO.SeekOrigin.Current);
                return reader.ReadUInt16();
            }
        }

    }
}
