using System;
using System.Reflection;


  namespace AssemblyConfigurationDetector
{
    public class AssemblyValidator
    {
        public bool IsValid(string assemblyPath)
        {
            try
            {
                AssemblyName.GetAssemblyName(assemblyPath);
            }
            catch (BadImageFormatException ex)
            {
                return false;
            }
            return true;
        }
    }
}
