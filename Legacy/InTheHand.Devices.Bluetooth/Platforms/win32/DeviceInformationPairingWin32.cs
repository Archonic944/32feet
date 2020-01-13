﻿//-----------------------------------------------------------------------
// <copyright file="DeviceInformationPairing.Win32.cs" company="In The Hand Ltd">
//   Copyright (c) 2017 In The Hand Ltd, All rights reserved.
//   This source code is licensed under the MIT License - see License.txt
// </copyright>
//-----------------------------------------------------------------------

using InTheHand.Devices.Bluetooth;
using System;

namespace InTheHand.Devices.Enumeration
{
    partial class DeviceInformationPairing
    {
        private BLUETOOTH_DEVICE_INFO _deviceInfo;

        internal DeviceInformationPairing(BLUETOOTH_DEVICE_INFO info)
        {
            _deviceInfo = info;
        }

#if !UNITY
        private DeviceInformationCustomPairing GetCustom()
        {
            return new DeviceInformationCustomPairing(_deviceInfo);
        }
#endif

        private bool GetIsPaired()
        {
            return _deviceInfo.fAuthenticated;
        }

        public DevicePairingResult Pair()
        {
            int result = NativeMethods.BluetoothAuthenticateDevice(IntPtr.Zero, IntPtr.Zero, ref _deviceInfo, null, 0);

            if (result == 0)
            {
                _deviceInfo.fAuthenticated = true;
            }

            return new DevicePairingResult(result);
        }

        public DeviceUnpairingResult Unpair()
        {
            ulong addr = _deviceInfo.Address;
            int result = NativeMethods.BluetoothRemoveDevice(ref addr);
            return new DeviceUnpairingResult(result);
        }
    }
}