﻿using System;
using System.Runtime.InteropServices;

namespace EnrollmentStation.Code
{
    public class YubikeyNeoManager : IDisposable
    {
        [DllImport("Binaries\\libykneomgr-0.dll", EntryPoint = "ykneomgr_global_init", CharSet = CharSet.Auto, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        private static extern YubicoNeoReturnCode YkNeoManagerGlobalInit(int initFlags);

        [DllImport("Binaries\\libykneomgr-0.dll", EntryPoint = "ykneomgr_global_done", CharSet = CharSet.Auto, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        private static extern void YkNeoManagerGlobalDone();

        [DllImport("Binaries\\libykneomgr-0.dll", EntryPoint = "ykneomgr_init", CharSet = CharSet.Auto, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        private static extern YubicoNeoReturnCode YkNeoManagerInit(ref IntPtr dev);

        [DllImport("Binaries\\libykneomgr-0.dll", EntryPoint = "ykneomgr_done", CharSet = CharSet.Auto, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        private static extern void YkNeoManagerDone(IntPtr dev);

        [DllImport("Binaries\\libykneomgr-0.dll", EntryPoint = "ykneomgr_get_mode", CharSet = CharSet.Auto, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        private static extern YubicoNeoModeEnum YkNeoManagerGetMode(IntPtr dev);

        [DllImport("Binaries\\libykneomgr-0.dll", EntryPoint = "ykneomgr_modeswitch", CharSet = CharSet.Auto, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        private static extern YubicoNeoReturnCode YkNeoManagerSetMode(IntPtr dev, YubicoNeoModeEnum mode);

        [DllImport("Binaries\\libykneomgr-0.dll", EntryPoint = "ykneomgr_get_serialno", CharSet = CharSet.Auto, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        private static extern int YkNeoManagerGetSerialNumber(IntPtr dev);

        [DllImport("Binaries\\libykneomgr-0.dll", EntryPoint = "ykneomgr_discover", CharSet = CharSet.Auto, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        private static extern YubicoNeoReturnCode YkNeoManagerDiscover(IntPtr dev);

        [DllImport("Binaries\\libykneomgr-0.dll", EntryPoint = "ykneomgr_get_version_major", CharSet = CharSet.Auto, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        private static extern byte YkNeoManagerGetVersionMajor(IntPtr dev);

        [DllImport("Binaries\\libykneomgr-0.dll", EntryPoint = "ykneomgr_get_version_minor", CharSet = CharSet.Auto, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        private static extern byte YkNeoManagerGetVersionMinor(IntPtr dev);

        [DllImport("Binaries\\libykneomgr-0.dll", EntryPoint = "ykneomgr_get_version_build", CharSet = CharSet.Auto, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        private static extern byte YkNeoManagerGetVersionBuild(IntPtr dev);

        [DllImport("Binaries\\libykneomgr-0.dll", EntryPoint = "ykneomgr_list_devices", CharSet = CharSet.Auto, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        private static extern YubicoNeoReturnCode YkNeoManagerListDevices(IntPtr dev, IntPtr buffer, ref int length);

        public static YubikeyNeoManager Instance { get; } = new YubikeyNeoManager();

        private bool _isDisposed;
        private IntPtr _currentDevice;

        private YubikeyNeoManager()
        {
            Init();
        }

        public void Init()
        {
            YubicoNeoReturnCode code = YkNeoManagerGlobalInit(1);

            if (code != YubicoNeoReturnCode.YKNEOMGR_OK)
                throw new Exception("Unable to init: " + code);

            YkNeoManagerInit(ref _currentDevice);
        }

        public void Close()
        {
            YkNeoManagerDone(_currentDevice);
            _currentDevice = IntPtr.Zero;

            YkNeoManagerGlobalDone();
        }

        public void Dispose()
        {
            if (_isDisposed)
                return;
            _isDisposed = true;

            YkNeoManagerDone(_currentDevice);
            _currentDevice = IntPtr.Zero;

            YkNeoManagerGlobalDone();
        }

        public int GetSerialNumber()
        {
            if (_isDisposed)
                return -1;

            if (_currentDevice == IntPtr.Zero)
                throw new Exception("Not initialized");

            return YkNeoManagerGetSerialNumber(_currentDevice);
        }

        public Version GetVersion()
        {
            if (_isDisposed)
                return new Version();

            if (_currentDevice == IntPtr.Zero)
                throw new Exception("Not initialized");

            var major = YkNeoManagerGetVersionMajor(_currentDevice);
            var minor = YkNeoManagerGetVersionMinor(_currentDevice);
            var build = YkNeoManagerGetVersionBuild(_currentDevice);

            return new Version(major, minor, build);
        }

        public YubicoNeoMode GetMode()
        {
            if (_isDisposed)
                return new YubicoNeoMode(0);

            if (_currentDevice == IntPtr.Zero)
                throw new Exception("Not initialized");

            return new YubicoNeoMode(YkNeoManagerGetMode(_currentDevice));
        }

        public void SetMode(YubicoNeoModeEnum mode)
        {
            if (_isDisposed)
                return;

            if (_currentDevice == IntPtr.Zero)
                throw new Exception("Not initialized");

            YubicoNeoReturnCode code = YkNeoManagerSetMode(_currentDevice, mode);

            if (code != YubicoNeoReturnCode.YKNEOMGR_OK)
                throw new Exception("Unable to set mode: " + code);
        }

        public bool RefreshDevice()
        {
            if (_isDisposed)
                return false;

            YubicoNeoReturnCode res = YkNeoManagerDiscover(_currentDevice);

            if (res == YubicoNeoReturnCode.YKNEOMGR_OK)
                return true;

            if (res == YubicoNeoReturnCode.YKNEOMGR_NO_DEVICE)
                return false;

            if (res == YubicoNeoReturnCode.YKNEOMGR_BACKEND_ERROR)
            {
                Close();
                Init();

                res = YkNeoManagerDiscover(_currentDevice);

                if (res == YubicoNeoReturnCode.YKNEOMGR_OK)
                    return true;

                return false;
            }

            throw new Exception("Unable to find device: " + res);
        }
    }
}