﻿//-----------------------------------------------------------------------
// <copyright file="BluetoothUtiAttribute.cs" company="In The Hand Ltd">
//   Copyright (c) 2018 In The Hand Ltd, All rights reserved.
//   This source code is licensed under the MIT License - see License.txt
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace InTheHand.Devices.Bluetooth
{
    /// <summary>
    /// Attribute to attach a Uniform Type Identifier to a Bluetooth UUID.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class BluetoothUtiAttribute : Attribute
    {
        public BluetoothUtiAttribute() { }

        public BluetoothUtiAttribute(string uti)
        {
            Uti = uti;
        }

        public string Uti
        {
            get;
            private set;
        }
    }
}