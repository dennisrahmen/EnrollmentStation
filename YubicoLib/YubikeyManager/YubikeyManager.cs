using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
using System.Text.RegularExpressions;


namespace YubicoLib.YubikeyManager
{

    public class YubmanConsole
    {
        public static string Cmdline = "C:\\Program Files (x86)\\Yubico\\YubiKey Manager\\ykman.exe";
        public static string Workdir = "C:\\Program Files (x86)\\Yubico\\YubiKey Manager";
        public string output = null;
        public string error = null;
        public int exitCode = 0;

        public static void setYKManPath(string ykmancliCmd, string ykmancliWorkdir)
        {
            Cmdline = ykmancliCmd;
            Workdir = ykmancliWorkdir;
        }
        private ProcessStartInfo _startInfo = new ProcessStartInfo();

        public void StartProcess(string subcommand, bool debug = false)
        {
            _startInfo.Arguments = subcommand;
            _startInfo.FileName = Cmdline;
            _startInfo.WorkingDirectory = Workdir;
            _startInfo.UseShellExecute = false;
            _startInfo.Verb = "runas";
            _startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            _startInfo.CreateNoWindow = true;
            _startInfo.RedirectStandardOutput = true;
            _startInfo.RedirectStandardError = true;


            using (Process p = new Process())
            {
                p.StartInfo = _startInfo;

                // start process
                p.Start();
                var _out = p.StandardOutput.ReadToEndAsync();
                var _err = p.StandardError.ReadToEndAsync();
                // wait for process to terminate
                p.WaitForExit();
                exitCode = p.ExitCode;
                output = _out.Result;
                error = _err.Result;
                if (debug)
                {
                    Console.WriteLine($"DEBUG EXIT: {exitCode}");
                    Console.WriteLine($"DEBUG OUT :{output}");
                    Console.WriteLine($"DEBUG ERR :{error}");
                }
            }

        }
        public bool OutputSearch(String search, bool toLower = true, bool trim = true, bool debug = false)
        {
            String _out = output;
            bool _ret = false;

            if (toLower)
            {
                _out = _out.ToLower();
            }
            if (trim)
            {
                _out = _out.Trim();
            }
            if (debug)
            {
                Console.WriteLine($"DEBUG OUT: {_out}");
            }
            if (!String.IsNullOrEmpty(_out))
            {
                if (_out.Contains(search))
                {
                    _ret = true;
                }
            }
            return _ret;
        }


        public string OutputRegSearch(Regex pattern, bool debug = false)
        {
            String _out = output;
            String _str = null;
            if (debug)
            {
                Console.WriteLine($"DEBUG OUT: {_out}");
            }
            if (!String.IsNullOrEmpty(_out))
            {
                if (pattern.IsMatch(_out))
                {
                    Match match = pattern.Match(_out);
                    _str = (match.Groups[1].Value);
                }
            }
            return _str;
        }


        public bool ErrorSearch(String search, bool toLower = true, bool trim = true, bool debug = false)
        {
            String _err = error;
            bool _ret = false;

            if (toLower)
            {
                _err = _err.ToLower();
            }
            if (trim)
            {
                _err = _err.Trim();
            }
            if (debug)
            {
                Console.WriteLine($"DEBUG ERR: {_err}");
            }
            if (!String.IsNullOrEmpty(_err))
            {
                if (_err.Contains(search))
                {
                    _ret = true;
                }
            }
            return _ret;
        }

        public string ErrorRegSearch(Regex pattern, bool debug = false)
        {
            String _err = error;
            String _str = null;
            if (debug)
            {
                Console.WriteLine($"DEBUG ERR: {_err}");
            }
            if (!String.IsNullOrEmpty(_err))
            {
                if (pattern.IsMatch(_err))
                {
                    Match match = pattern.Match(_err);
                    _str = (match.Groups[1].Value);
                }
            }
            return _str;
        }

    }


    public class YubikeyInfo
    {
        public string devicetype { get; private set; } = null;
        public string serial { get; private set; } = null;
        public string firmware { get; private set; } = null;
        public string formfactor { get; private set; } = null;
        public string usbinterface { get; private set; } = null;
        public string nfcinterface { get; private set; } = null;
        public string appprotected { get; private set; } = null;
        public string otpusb { get; private set; } = null;
        public string otpnfc { get; private set; } = null;
        public string fidou2fusb { get; private set; } = null;
        public string fidou2fnfc { get; private set; } = null;
        public string openpgpusb { get; private set; } = null;
        public string openpgpnfc { get; private set; } = null;
        public string pivusb { get; private set; } = null;
        public string pivnfc { get; private set; } = null;
        public string oathusb { get; private set; } = null;
        public string oathnfc { get; private set; } = null;
        public string fido2usb { get; private set; } = null;
        public string fido2nfc { get; private set; } = null;
        public bool hasCCID { get; private set; } = false;
        public bool hasOTP { get; private set; } = false;
        public bool hasFIDO { get; private set; } = false;
        public string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        public bool GetYubikeyInfo(string serialnumber)
        {
            devicetype = null;
            serial = null;
            firmware = null;
            formfactor = null;
            usbinterface = null;
            nfcinterface = null;
            appprotected = null;
            otpusb = null;
            otpnfc = null;
            fidou2fusb = null;
            fidou2fnfc = null;
            openpgpusb = null;
            openpgpnfc = null;
            pivusb = null;
            pivnfc = null;
            oathusb = null;
            oathnfc = null;
            fido2usb = null;
            fido2nfc = null;
            hasCCID = false;
            hasOTP = false;
            hasFIDO = false;
            string _str = null;
            bool _success = false;

            var yu = new YubmanConsole();

            yu.StartProcess("--device " + serialnumber + " info");

            if (yu.exitCode == 0)
            {
                _success = true;
                string[] keys = new string[] { "Device type:", "Serial number:", "Firmware version:", "Form factor:",
                        "Enabled USB interfaces:", "NFC interface is","Configured applications are protected by a lock code", "OTP", "FIDO U2F", "OpenPGP", "PIV", "OATH", "FIDO2" };
                var comparison = StringComparison.InvariantCultureIgnoreCase;
                string[] infovalues = new string[] { "Enabled", "Disabled", "Not available" };

                using (StringReader strReader1 = new StringReader(yu.output))
                {
                    int i = 0;
                    while (strReader1.Peek() >= 1)
                    {
                        _str = strReader1.ReadLine();
                        i++;
                        string sKeyResult = keys.FirstOrDefault<string>(s => _str.StartsWith(s, comparison));
                        switch (sKeyResult)
                        {
                            case "Device type:":
                                devicetype = _str.Replace("Device type:", "").Trim();
                                break;
                            case "Serial number:":
                                serial = _str.Replace("Serial number:", "").Trim();
                                break;
                            case "Firmware version:":
                                firmware = _str.Replace("Firmware version:", "").Trim();
                                break;
                            case "Form factor:":
                                formfactor = _str.Replace("Form factor:", "").Trim();
                                break;
                            case "Enabled USB interfaces:":
                                usbinterface = _str.Replace("Enabled USB interfaces:", "").Trim();
                                if (usbinterface.Contains("OTP"))
                                {
                                    hasOTP = true;
                                }
                                if (usbinterface.Contains("CCID"))
                                {
                                    hasCCID = true;
                                }
                               if (usbinterface.Contains("FIDO"))
                                {
                                    hasFIDO = true;
                                }
                                break;
                            case "NFC interface is":
                                _str = _str.Replace("NFC interface is", "").Trim();
                                if (_str.Contains("enabled"))
                                {
                                    nfcinterface = "enabled";
                                }
                                else if (_str.Contains("disabled"))
                                {
                                    nfcinterface = "disabled";
                                }
                                else
                                {
                                    nfcinterface = "N/A";
                                }
                                break;
                            case "Configured applications are protected by a lock code":
                                appprotected = "Enabled";
                                break;
                            case "OTP":
                                otpusb = infovalues[2];
                                otpnfc = infovalues[2];
                                // first column
                                _str = _str.Replace("OTP", "").Trim();
                                // second column
                                if (_str.StartsWith(infovalues[0]))
                                {
                                    _str = ReplaceFirst(_str, infovalues[0], "").Trim();
                                    otpusb = infovalues[0];
                                }
                                else if (_str.StartsWith(infovalues[1]))
                                {
                                    _str = ReplaceFirst(_str, infovalues[1], "").Trim();
                                    otpusb = infovalues[1];
                                }
                                else if (_str.StartsWith(infovalues[2]))
                                {
                                    _str = ReplaceFirst(_str, infovalues[2], "").Trim();
                                    otpusb = infovalues[2];
                                }
                                // Maybe there is third column for NFC
                                if (!string.IsNullOrEmpty(_str))
                                {
                                    if (_str.StartsWith(infovalues[0]))
                                    {
                                        _str = ReplaceFirst(_str, infovalues[0], "").Trim();
                                        otpnfc = infovalues[0];
                                    }
                                    else if (_str.StartsWith(infovalues[1]))
                                    {
                                        _str = ReplaceFirst(_str, infovalues[1], "").Trim();
                                        otpnfc = infovalues[1];
                                    }
                                    else if (_str.StartsWith(infovalues[2]))
                                    {
                                        _str = ReplaceFirst(_str, infovalues[2], "").Trim();
                                        otpnfc = infovalues[2];
                                    }
                                }
                                break;
                            case "FIDO U2F":
                                fidou2fusb = infovalues[2];
                                fidou2fnfc = infovalues[2];
                                // first column
                                _str = _str.Replace("FIDO U2F", "").Trim();
                                // second column
                                if (_str.StartsWith(infovalues[0]))
                                {
                                    _str = ReplaceFirst(_str, infovalues[0], "").Trim();
                                    fidou2fusb = infovalues[0];
                                }
                                else if (_str.StartsWith(infovalues[1]))
                                {
                                    _str = ReplaceFirst(_str, infovalues[1], "").Trim();
                                    fidou2fusb = infovalues[1];
                                }
                                else if (_str.StartsWith(infovalues[2]))
                                {
                                    _str = ReplaceFirst(_str, infovalues[2], "").Trim();
                                    fidou2fusb = infovalues[2];
                                }
                                // Maybe there is third column for NFC
                                if (!string.IsNullOrEmpty(_str))
                                {
                                    if (_str.StartsWith(infovalues[0]))
                                    {
                                        _str = ReplaceFirst(_str, infovalues[0], "").Trim();
                                        fidou2fnfc = infovalues[0];
                                    }
                                    else if (_str.StartsWith(infovalues[1]))
                                    {
                                        _str = ReplaceFirst(_str, infovalues[1], "").Trim();
                                        fidou2fnfc = infovalues[1];
                                    }
                                    else if (_str.StartsWith(infovalues[2]))
                                    {
                                        _str = ReplaceFirst(_str, infovalues[2], "").Trim();
                                        fidou2fnfc = infovalues[2];
                                    }
                                }
                                break;
                            case "OpenPGP":
                                openpgpusb = infovalues[2];
                                openpgpnfc = infovalues[2];
                                // first column
                                _str = _str.Replace("OpenPGP", "").Trim();
                                // second column
                                if (_str.StartsWith(infovalues[0]))
                                {
                                    _str = ReplaceFirst(_str, infovalues[0], "").Trim();
                                    openpgpusb = infovalues[0];
                                }
                                else if (_str.StartsWith(infovalues[1]))
                                {
                                    _str = ReplaceFirst(_str, infovalues[1], "").Trim();
                                    openpgpusb = infovalues[1];
                                }
                                else if (_str.StartsWith(infovalues[2]))
                                {
                                    _str = ReplaceFirst(_str, infovalues[2], "").Trim();
                                    openpgpusb = infovalues[2];
                                }
                                // Maybe there is third column for NFC
                                if (!string.IsNullOrEmpty(_str))
                                {
                                    if (_str.StartsWith(infovalues[0]))
                                    {
                                        _str = ReplaceFirst(_str, infovalues[0], "").Trim();
                                        openpgpnfc = infovalues[0];
                                    }
                                    else if (_str.StartsWith(infovalues[1]))
                                    {
                                        _str = ReplaceFirst(_str, infovalues[1], "").Trim();
                                        openpgpnfc = infovalues[1];
                                    }
                                    else if (_str.StartsWith(infovalues[2]))
                                    {
                                        _str = ReplaceFirst(_str, infovalues[2], "").Trim();
                                        openpgpnfc = infovalues[2];
                                    }
                                }
                                break;
                            case "PIV":
                                pivusb = infovalues[2];
                                pivnfc = infovalues[2];
                                // first column
                                _str = _str.Replace("PIV", "").Trim();
                                // second column
                                if (_str.StartsWith(infovalues[0]))
                                {
                                    _str = ReplaceFirst(_str, infovalues[0], "").Trim();
                                    pivusb = infovalues[0];
                                }
                                else if (_str.StartsWith(infovalues[1]))
                                {
                                    _str = ReplaceFirst(_str, infovalues[1], "").Trim();
                                    pivusb = infovalues[1];
                                }
                                else if (_str.StartsWith(infovalues[2]))
                                {
                                    _str = ReplaceFirst(_str, infovalues[2], "").Trim();
                                    pivusb = infovalues[2];
                                }
                                // Maybe there is third column for NFC
                                if (!string.IsNullOrEmpty(_str))
                                {
                                    if (_str.StartsWith(infovalues[0]))
                                    {
                                        _str = ReplaceFirst(_str, infovalues[0], "").Trim();
                                        pivnfc = infovalues[0];
                                    }
                                    else if (_str.StartsWith(infovalues[1]))
                                    {
                                        _str = ReplaceFirst(_str, infovalues[1], "").Trim();
                                        pivnfc = infovalues[1];
                                    }
                                    else if (_str.StartsWith(infovalues[2]))
                                    {
                                        _str = ReplaceFirst(_str, infovalues[2], "").Trim();
                                        pivnfc = infovalues[2];
                                    }
                                }
                                break;
                            case "OATH":
                                oathusb = infovalues[2];
                                oathnfc = infovalues[2];
                                // first column
                                _str = _str.Replace("OATH", "").Trim();
                                // second column
                                if (_str.StartsWith(infovalues[0]))
                                {
                                    _str = ReplaceFirst(_str, infovalues[0], "").Trim();
                                    oathusb = infovalues[0];
                                }
                                else if (_str.StartsWith(infovalues[1]))
                                {
                                    _str = ReplaceFirst(_str, infovalues[1], "").Trim();
                                    oathusb = infovalues[1];
                                }
                                else if (_str.StartsWith(infovalues[2]))
                                {
                                    _str = ReplaceFirst(_str, infovalues[2], "").Trim();
                                    oathusb = infovalues[2];
                                }
                                // Maybe there is third column for NFC
                                if (!string.IsNullOrEmpty(_str))
                                {
                                    if (_str.StartsWith(infovalues[0]))
                                    {
                                        _str = ReplaceFirst(_str, infovalues[0], "").Trim();
                                        oathnfc = infovalues[0];
                                    }
                                    else if (_str.StartsWith(infovalues[1]))
                                    {
                                        _str = ReplaceFirst(_str, infovalues[1], "").Trim();
                                        oathnfc = infovalues[1];
                                    }
                                    else if (_str.StartsWith(infovalues[2]))
                                    {
                                        _str = ReplaceFirst(_str, infovalues[2], "").Trim();
                                        oathnfc = infovalues[2];
                                    }
                                }
                                break;
                            case "FIDO2":
                                fido2usb = infovalues[2];
                                fido2nfc = infovalues[2];
                                // first column
                                _str = _str.Replace("FIDO2", "").Trim();
                                // second column
                                if (_str.StartsWith(infovalues[0]))
                                {
                                    _str = ReplaceFirst(_str, infovalues[0], "").Trim();
                                    fido2usb = infovalues[0];
                                }
                                else if (_str.StartsWith(infovalues[1]))
                                {
                                    _str = ReplaceFirst(_str, infovalues[1], "").Trim();
                                    fido2usb = infovalues[1];
                                }
                                else if (_str.StartsWith(infovalues[2]))
                                {
                                    _str = ReplaceFirst(_str, infovalues[2], "").Trim();
                                    fido2usb = infovalues[2];
                                }
                                // Maybe there is third column for NFC
                                if (!string.IsNullOrEmpty(_str))
                                {
                                    if (_str.StartsWith(infovalues[0]))
                                    {
                                        _str = ReplaceFirst(_str, infovalues[0], "").Trim();
                                        fido2nfc = infovalues[0];
                                    }
                                    else if (_str.StartsWith(infovalues[1]))
                                    {
                                        _str = ReplaceFirst(_str, infovalues[1], "").Trim();
                                        fido2nfc = infovalues[1];
                                    }
                                    else if (_str.StartsWith(infovalues[2]))
                                    {
                                        _str = ReplaceFirst(_str, infovalues[2], "").Trim();
                                        fido2nfc = infovalues[2];
                                    }
                                }
                                break;
                        }
                    }
                }
            }
            return _success;
        }

        public void print()
        {
            Console.WriteLine($"Devicetype       : {devicetype}");
            Console.WriteLine($"Serialnumber     : {serial}");
            Console.WriteLine($"Firmware         : {firmware}");
            Console.WriteLine($"Formfactor       : {formfactor}");
            Console.WriteLine($"USB Interface    : {usbinterface}");
            Console.WriteLine($"USB Mode         : OTP:{hasOTP} CCID:{hasCCID} FIDO:{hasFIDO}");
            Console.WriteLine($"NFC interface is : {nfcinterface}");
            Console.WriteLine($"App Protected    : {appprotected}");
            Console.WriteLine($"OTP              : {otpusb} {otpnfc}");
            Console.WriteLine($"FIDO U2F         : {fidou2fusb} {fidou2fnfc}");
            Console.WriteLine($"OpenPGP          : {openpgpusb} {openpgpnfc}");
            Console.WriteLine($"PIV              : {pivusb} {pivnfc}");
            Console.WriteLine($"OATH             : {oathusb} {oathnfc}");
            Console.WriteLine($"FIDO2            : {fido2usb} {fido2nfc}");
        }
    }
    public class YubmanUtil
    {
        public YubmanConsole yu = new YubmanConsole();

        public bool CheckOneYubikeyPresent(out string errmsg)
        {
            yu.StartProcess("info");
            bool _ret = false;
            errmsg = null;
            if (yu.exitCode != 0)
            {
                if (yu.ErrorSearch("no yubikey detected!"))
                {
                    errmsg = "No Yubikey found!";
                }
                else if (yu.ErrorSearch("multiple yubikeys detected"))
                {
                    errmsg = "Multiple Yubikeys found!";
                }
                else
                {
                    errmsg = "Unknown Error";
                }
                _ret = false;

            }
            else
            {
                _ret = true;
            }

            return _ret;

        }

        public int CheckYubikeyPresent()
        {
            yu.StartProcess("list");
            int devnr = 0;
            
            if (yu.exitCode == 0)
            {

                StringReader strReader1 = new StringReader(yu.output);
                while (true)
                {
                    string devtype = strReader1.ReadLine();
                    if (devtype != null) 
                    {
                        devnr++;
                    }
                    else
                    {
                        break;
                    }
                }

            }
            return devnr;
        }

        // May list multiple yubikeys
        public bool ListYubikey(out string snr)
        {
            bool _success = false;
            yu.StartProcess("list");

            if (yu.exitCode == 0)
            {
                snr = yu.output.Trim();
                _success = true;
            }
            else
            {
                snr = null;
            }

            return _success;
        }

        // May get multiple serials
        public bool GetYubikeySerial(out string snr)
        {
            bool _success = false;
            yu.StartProcess("list -s");

            if (yu.exitCode == 0)
            {
                snr = yu.output.Trim();
                _success = true;
            }
            else
            {
                snr = null;
            }

            return _success;
        }

        public bool GetFirstorDefaultYubikeySerial(out string snr)
        {
            bool _success = false;
            yu.StartProcess("list -s");

            if (yu.exitCode == 0)
            {
                string output  = yu.output.Trim();
                using (StringReader strReader1 = new StringReader(output))
                {
                    string tmp = strReader1.ReadLine().Trim();
                    if (!string.IsNullOrEmpty(tmp))
                    {
                        snr = tmp;
                        _success = true;
                    }     
                    else
                    {
                        snr = null;
                        _success = true;
                    }
                }                    
            }
            else
            {
                snr = null;
            }

            return _success;
        }

        public bool GetYubikeySerial(out string[] serials)
        {
            bool _success = false;
            yu.StartProcess("list -s");
            List<string> stringList = new List<string>();
            if (yu.exitCode == 0)
            {
                string output = yu.output.Trim();
                _success = true;
                using (StringReader strReader1 = new StringReader(output))
                {
                    while (strReader1.Peek()> -1)
                    {
                        string tmp = strReader1.ReadLine().Trim();                        
                        if (!string.IsNullOrEmpty(tmp))
                        {
                            stringList.Add(tmp);
                        }
                    }                     
                }
                string[] stringArray = stringList.ToArray();
                serials = stringArray;
            }
            else
            {
                serials = null;
            }

            return _success;
        }

        public bool GetYubikeyMode(string serialnumber, out bool OTP, out bool CCID, out bool FIDO, out string mode)
        {

            bool _success = false;
            string _str  = null;
            Regex pattern = new Regex(@": ([A-Z+0-9]*)", RegexOptions.Multiline);
            yu.StartProcess("--device " + serialnumber + " mode");
            OTP = false;
            CCID = false;
            FIDO = false;
            mode = null;
            if (yu.exitCode == 0)
            {
                _str = yu.OutputRegSearch(pattern);
                OTP = _str.Contains("OTP");
                CCID = _str.Contains("CCID");
                FIDO = _str.Contains("FIDO");
                mode = _str;
                _success = true;
            }
            return _success;
        }

        public string GetYubikeyMode(string serialnumber)
        {
            string _str = null;
            Regex pattern = new Regex(@": ([A-Z+0-9]*)", RegexOptions.Multiline);

            yu.StartProcess("--device " + serialnumber + " mode");

            if (yu.exitCode == 0)
            {
                _str = yu.OutputRegSearch(pattern);
            }
            return _str;
        }

        
        public bool SetYubikeyMode(string serialnumber, bool mOTP, bool mCCID, bool mFIDO, bool debug = false)
        {
            string mode = "--device " + serialnumber + " mode ";
            bool first = false;
            bool _success = false;
            if (mOTP | mCCID | mFIDO)
            {
                if (mOTP)
                {
                    mode += "OTP";
                    first = true;
                }
                if (mCCID)
                {
                    if (first)
                    {
                        mode += "+CCID";
                    }
                    else
                    {
                        mode += "CCID";
                        first = true;
                    }
                }
                if (mFIDO)
                {
                    if (first)
                    {
                        mode += "+FIDO";
                    }
                    else
                    {
                        mode += "FIDO";
                        first = true;
                    }
                }
                mode += " -f";
            }
            // Set Mode
            yu.StartProcess(mode);
            if (yu.exitCode == 0)
            {
                _success = true;
            }

            if (debug)
            {
                Console.WriteLine($"DEBUG EXIT:{yu.exitCode}");
                Console.WriteLine($"DEBUG OUT :{yu.output}");
                Console.WriteLine($"DEBUG ERR :{yu.error}");
            }

            return _success;
        }
    }
}
