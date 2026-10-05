using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace CliniqaxSystem.Infrastructure.Security
{
    public static class HardwareFingerprint
    {
        public static string GetMachineHardwareId()
        {
            var builder = new StringBuilder();

            builder.Append(GetWmiProperty("Win32_Processor", "ProcessorId"));
            builder.Append(GetWmiProperty("Win32_BaseBoard", "SerialNumber"));
            builder.Append(GetWmiProperty("Win32_DiskDrive", "SerialNumber"));

            string source = builder.ToString();
            if (string.IsNullOrWhiteSpace(source))
            {
                source = Environment.MachineName + Environment.UserName + Environment.OSVersion;
            }

            byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(source));
            return Convert.ToHexString(hash);
        }

        private static string GetWmiProperty(string wmiClass, string propertyName)
        {
            try
            {
                using var searcher = new ManagementObjectSearcher($"SELECT {propertyName} FROM {wmiClass}");
                foreach (var item in searcher.Get())
                {
                    var val = item[propertyName]?.ToString();
                    if (!string.IsNullOrWhiteSpace(val))
                        return val.Trim();
                }
            }
            catch { }
            return string.Empty;
        }
    }
}
