﻿//-----------------------------------------------------------------------
// <copyright file="RfcommDeviceService.Portable.cs" company="In The Hand Ltd">
//   Copyright (c) 2017 In The Hand Ltd, All rights reserved.
//   This source code is licensed under the MIT License - see License.txt
// </copyright>
//-----------------------------------------------------------------------

using System.IO;
using System.Threading.Tasks;

namespace InTheHand.Devices.Bluetooth.Rfcomm
{
    partial class RfcommDeviceService
    {
        private static async Task<RfcommDeviceService> FromIdAsyncImpl(string deviceId)
        {
            return null;
        }
        
        private static string GetDeviceSelectorImpl(RfcommServiceId serviceId)
        {
            return string.Empty;
        }


        private BluetoothDevice _device = null;
        private RfcommServiceId _service = null;

        private BluetoothDevice GetDevice()
        {
            return _device;
        }

        private RfcommServiceId GetServiceId()
        {
            return _service;
        }
        
        private Task<Stream> OpenStreamAsyncImpl()
        {
            return Task.FromResult<Stream>(null);
        }
    }
}