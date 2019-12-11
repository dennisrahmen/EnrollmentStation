using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using YubicoLib.YubikeyPiv;
using YubicoLib.YubikeyManager;
using System.IO;

namespace YubicoLib.TestTool
{
    class Program
    {
        static void Main(string[] args)
        {



            // PIV
            List<string> devices = YubikeyPivManager.Instance.ListDevices(false).ToList();

            Console.WriteLine($"[PIV] Found {devices.Count:N0} devices");

            foreach (string device in devices)
            {
                PrintPiv(device);
            }

            bool success;
            bool ccid, otp, fido;
            string errmsg;
            string serial;
            string mode;

            YubmanConsole.setYKManPath(@"E:\proj\EnrollmentStation-master\EnrollmentStation\bin\Release\Binaries\YubikeyManager\ykman.exe", @"E:\proj\EnrollmentStation-master\EnrollmentStation\bin\Release\Binaries\YubikeyManager");

            // Using XKMAN Tool 
            Console.WriteLine($"[YKMAN] Cmdline {YubmanConsole.Cmdline}");
            Console.WriteLine($"[YKMAN] CmdWorkDir {YubmanConsole.Workdir}");

            var y = new YubmanUtil();
               
            int ybdevcount = y.CheckYubikeyPresent();
            Console.WriteLine($"[YKMAN] Yubikey present: {ybdevcount}");

            if (ybdevcount >= 1)
            {
                if (y.GetFirstorDefaultYubikeySerial(out serial))
                {
                    Console.WriteLine($"[YKMAN] First Serial is: {serial}");
                }
            }

            bool present = y.CheckOneYubikeyPresent(out errmsg);
            Console.WriteLine($"[YKMAN] One Yubikey present: {present} {errmsg}");

            if (present)
            {
                success = y.GetYubikeySerial(out serial);
                Console.WriteLine($"[YKMAN] Serial : {serial}");
                mode = y.GetYubikeyMode(serial);
                Console.WriteLine($"[YKMAN] Current Mode : {mode}");
                success = y.GetYubikeyMode(serial,out otp, out ccid, out fido, out mode);
                Console.WriteLine($"[YKMAN] Current Mode : {mode} OTP:{otp} CCID {ccid} FIDO:{fido}");
            }
            else
            {
                if (!(string.IsNullOrEmpty(errmsg)) && (errmsg.Contains("Multiple Yubikeys found")))
                {
                    Console.WriteLine("Multiple Yubikeys found");
                    success = y.ListYubikey(out string info);
                    success = y.GetYubikeySerial(out serial);
                    StringReader strReader1 = new StringReader(info);
                    StringReader strReader2 = new StringReader(serial);
                    string devtype, devserial = null;
                    int devnr = 0;
                    while (true)
                    {
                        devtype = strReader1.ReadLine();
                        devserial = strReader2.ReadLine();
                        if ((devtype != null) && (devserial != null))
                        {
                            devnr++;
                            Console.WriteLine($"Device: {devnr}");
                            Console.WriteLine($"Type  : {devtype}");
                            Console.WriteLine($"Serial: {devserial}");
                            Console.WriteLine($"Mode  : {y.GetYubikeyMode(devserial)}\r\n"); 
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            string[] serialnumbers;
           
            success = y.GetYubikeySerial(out serialnumbers);
            if (success)
            {
                foreach (string s in serialnumbers)
                {
                    var yi = new YubikeyInfo();
                    yi.GetYubikeyInfo(s);
                    yi.print();
                    Console.WriteLine();
                }
            }
        }
       
        static void PrintPiv(string name)
        {
            Console.WriteLine($"[PIV] Device: {name}");

            if (!YubikeyPivManager.Instance.IsValidDevice(name))
            {
                Console.WriteLine("      Not a valid PIV device");
            }
            else
            {
                using (YubikeyPivDevice device = YubikeyPivManager.Instance.OpenDevice(name))
                {
                    Console.WriteLine($"      Version : {device.GetVersion()}");

                    byte[] chuid;
                    if (device.GetCHUID(out chuid))
                        Console.WriteLine($"      CHUID   : {BitConverter.ToString(chuid).Replace("-", "")}");
                    else
                        Console.WriteLine("      CHUID   : N/A");

                    Console.WriteLine($"      PinTries: {device.GetPinTriesLeft():N0}");
                    Console.WriteLine($"      SerialNumber: {device.GetSerialNumber():D0}");

                    X509Certificate2 cert = device.GetCertificate9a();

                    if (cert != null)
                    {
                        Console.WriteLine($"      Cert 9A, Subject: {cert.SubjectName}");
                        Console.WriteLine($"               Issuer : {cert.IssuerName}");
                        Console.WriteLine($"               Start  : {cert.NotBefore.ToUniversalTime():O}");
                        Console.WriteLine($"               Expiry : {cert.NotAfter.ToUniversalTime():O}");
                        Console.WriteLine($"               Serial : {cert.SerialNumber}");
                        Console.WriteLine($"               Finger : {cert.Thumbprint}");
                    }
                    else
                        Console.WriteLine("      Cert 9A : N/A");
                }
            }            
            Console.WriteLine();
        }
    }
}
