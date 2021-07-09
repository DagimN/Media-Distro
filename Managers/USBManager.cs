using System;
using System.Collections.Generic;
using System.Management;

namespace Media_Distro.Managers
{
    public class USBManager
    {
        public static List<USBManager> deviceList = new List<USBManager>();
        private static List<string> idList = new List<string>();
        private static List<string> pathList = new List<string>();
        public string ID { get; set; }
        public string Path { get; set; }
        public DateTime Timestamp { get; set; }
        public int Count { get; set; }

        public USBManager()
        {
            ManageDevices();
        }

        private USBManager(string id, string path)
        {
            this.ID = id;
            this.Timestamp = DateTime.Now;
            this.Count = 0;
            this.Path = path;
        }

        public void ManageDevices(string path = null)
        {
            ManagementObjectSearcher diskDrives = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE InterfaceType='USB'");

            foreach (ManagementObject diskDrive in diskDrives.Get())
            {
                string DeviceID = diskDrive["PNPDeviceID"].ToString();
                string DriveLetter = "";
                string DriveDescription = "";

                ManagementObjectSearcher partitionSearcher = new ManagementObjectSearcher(String.Format(
                    "associators of {{Win32_DiskDrive.DeviceID='{0}'}} where AssocClass = Win32_DiskDriveToDiskPartition",
                    diskDrive["DeviceID"]));

                foreach (ManagementObject partition in partitionSearcher.Get())
                {
                    ManagementObjectSearcher logicalSearcher = new ManagementObjectSearcher(String.Format(
                        "associators of {{Win32_DiskPartition.DeviceID='{0}'}} where AssocClass = Win32_LogicalDiskToPartition",
                        partition["Name"]));

                    foreach (ManagementObject logical in logicalSearcher.Get())
                    {
                        ManagementObjectSearcher volumeSearcher = new ManagementObjectSearcher(String.Format(
                            "SELECT * FROM Win32_LogicalDisk where Name='{0}'",
                            logical["Name"]));

                        foreach (ManagementObject volume in volumeSearcher.Get())
                        {
                            DriveLetter = volume["Name"].ToString() + "\\";
                            if (volume["VolumeName"] != null)
                                DriveDescription = volume["VolumeName"].ToString();

                            if(path == null)
                            {
                                deviceList.Add(new USBManager(DeviceID, DriveLetter));
                                idList.Add(DeviceID);
                                pathList.Add(DriveLetter);
                            }
                            else
                            {
                                if (!idList.Contains(DeviceID))
                                {
                                    deviceList.Add(new USBManager(DeviceID, DriveLetter));
                                    idList.Add(DeviceID);
                                    pathList.Add(DriveLetter);
                                }
                                else
                                    foreach(USBManager device in deviceList)
                                        if(device.ID == DeviceID)
                                            if(device.Path == path)
                                                device.Timestamp = DateTime.Now;
                                            else
                                            {
                                                device.Path = path;
                                                device.Timestamp = DateTime.Now;
                                            }
                            }
                        }

                        volumeSearcher.Dispose();
                    }

                    logicalSearcher.Dispose();
                }

                partitionSearcher.Dispose();
            }

            diskDrives.Dispose();
        }

        public static bool ManageDevices(USBManager dev)
        {
            bool Exists = false;

            ManagementObjectSearcher diskDrives = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE InterfaceType='USB'");

            foreach (ManagementObject diskDrive in diskDrives.Get())
            {
                string DeviceID = diskDrive["PNPDeviceID"].ToString();
                string DriveLetter = "";
                string DriveDescription = "";

                ManagementObjectSearcher partitionSearcher = new ManagementObjectSearcher(String.Format(
                    "associators of {{Win32_DiskDrive.DeviceID='{0}'}} where AssocClass = Win32_DiskDriveToDiskPartition",
                    diskDrive["DeviceID"]));

                foreach (ManagementObject partition in partitionSearcher.Get())
                {
                    ManagementObjectSearcher logicalSearcher = new ManagementObjectSearcher(String.Format(
                        "associators of {{Win32_DiskPartition.DeviceID='{0}'}} where AssocClass = Win32_LogicalDiskToPartition",
                        partition["Name"]));

                    foreach (ManagementObject logical in logicalSearcher.Get())
                    {
                        ManagementObjectSearcher volumeSearcher = new ManagementObjectSearcher(String.Format(
                            "SELECT * FROM Win32_LogicalDisk where Name='{0}'",
                            logical["Name"]));

                        foreach (ManagementObject volume in volumeSearcher.Get())
                        {
                            DriveLetter = volume["Name"].ToString() + "\\";
                            if (volume["VolumeName"] != null)
                                DriveDescription = volume["VolumeName"].ToString();

                            if (dev != null)
                                if (dev.Path == DriveLetter && dev.ID == DeviceID)
                                    Exists = true;
                        }

                        volumeSearcher.Dispose();
                    }

                    logicalSearcher.Dispose();
                }

                partitionSearcher.Dispose();
            }

            diskDrives.Dispose();

            return Exists;
        }

        public void Add(string path)
        {
            ManageDevices(path);
        }

        public static bool Exists(string path, out USBManager device)
        {
            bool Exists = false;
            device = null;

            foreach(USBManager dev in deviceList)
            {
                if(dev.Path == path)
                {
                    Exists = ManageDevices(dev);
                    device = dev;
                }
            }

            return Exists;
        }
    }
}
