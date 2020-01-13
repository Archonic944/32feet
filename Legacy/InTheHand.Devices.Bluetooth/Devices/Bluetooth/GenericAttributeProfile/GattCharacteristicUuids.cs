﻿//-----------------------------------------------------------------------
// <copyright file="GattCharacteristicUuids.cs" company="In The Hand Ltd">
//   Copyright (c) 2015-18 In The Hand Ltd, All rights reserved.
//   This source code is licensed under the MIT License - see License.txt
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Reflection;

namespace InTheHand.Devices.Bluetooth.GenericAttributeProfile
{
    /// <summary>
    /// Provides characteristic UUIDs for common GATT characteristics.
    /// </summary>
    /// <remarks>To view a list of all Bluetooth SIG-defined characteristic UUIDs, see <a href="https://www.bluetooth.com/specifications/gatt/characteristics">Bluetooth SIG-defined Characteristic UUIDs</a>.</remarks>
    public static class GattCharacteristicUuids
    {
        /// <summary>
        /// Returns the Uuid for a characteristic given the Uniform Type Identifier.
        /// </summary>
        /// <param name="bluetoothUti">Uniform Type Identifier of the characteristic e.g. org.bluetooth.characteristic.aerobic_heart_rate_lower_limit</param>
        /// <returns>The characteristic Uuid on success else Guid.Empty.</returns>
        public static Guid FromBluetoothUti(string bluetoothUti)
        {
            string requestedUti = bluetoothUti.ToLower();
            if (!requestedUti.StartsWith("org.bluetooth.characteristic"))
            {
                requestedUti = "org.bluetooth.characteristic" + bluetoothUti.ToLower();
            }

#if !NETSTANDARD1_4
            var fields = typeof(GattCharacteristicUuids).GetFields(BindingFlags.Static | BindingFlags.Public);
            foreach(var field in fields)
            {
                var attr = field.GetCustomAttribute(typeof(BluetoothUtiAttribute));
                if(attr != null && ((BluetoothUtiAttribute)attr).Uti == requestedUti)
                {
                    return (Guid)field.GetValue(null);
                }
            }
#endif

            return Guid.Empty;
        }

        /// <summary>
        /// Lower limit of the heart rate where the user enhances his endurance while exercising.
        /// </summary>
        [BluetoothUti("org.bluetooth.characteristic.aerobic_heart_rate_lower_limit")]
        public static readonly Guid AerobicHeartRateLowerLimit = new Guid(0x00002A7E, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        [BluetoothUti("org.bluetooth.characteristic.aerobic_heart_rate_upper_limit")]
        public static readonly Guid AerobicHeartRateUpperLimit = new Guid(0x00002A84, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        [BluetoothUti("org.bluetooth.characteristic.aerobic_threshold")]
        public static readonly Guid AerobicThreshold = new Guid(0x00002A7F, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        [BluetoothUti("org.bluetooth.characteristic.age")]
        public static readonly Guid Age = new Guid(0x00002A80, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        [BluetoothUti("org.bluetooth.characteristic.aggregate")]
        public static readonly Guid Aggregate = new Guid(0x00002A5A, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        /// <summary>
        /// Gets the Bluetooth SIG-defined AlertCategoryId characteristic UUID.
        /// </summary>
        [BluetoothUti("org.bluetooth.characteristic.alert_category_id")]
        public static readonly Guid AlertCategoryId = new Guid(0x00002A43, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        /// <summary>
        /// Gets the Bluetooth SIG-Defined AlertCategoryIdBitMask characteristic UUID
        /// </summary>
        public static readonly Guid AlertCategoryIdBitMask = new Guid(0x00002A42, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        /// <summary>
        /// Gets the Bluetooth SIG-defined AlertLevel characteristic UUID.
        /// </summary>
        public static readonly Guid AlertLevel = new Guid(0x00002A06, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        /// <summary>
        /// Gets the Bluetooth SIG-defined AlertNotificationControlPoint characteristic UUID.
        /// </summary>
        public static readonly Guid AlertNotificationControlPoint = new Guid(0x00002A44, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        /// <summary>
        /// Gets the Bluetooth SIG-defined AlertStatus characteristic UUID.
        /// </summary>
        public static readonly Guid AlertStatus = new Guid(0x00002A3F, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        public static readonly Guid Altitude = new Guid(0x00002AB3, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        public static readonly Guid AnaerobicHeartRateLowerLimit = new Guid(0x00002A81, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        public static readonly Guid AnaerobicHeartRateUpperLimit = new Guid(0x00002A82, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        public static readonly Guid AnaerobicThreshold = new Guid(0x00002A83, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        public static readonly Guid Analog = new Guid(0x00002A58, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        public static readonly Guid ApparentWindDirection = new Guid(0x00002A73, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        public static readonly Guid ApparentWindSpeed = new Guid(0x00002A72, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        public static readonly Guid Appearance = new Guid(0x00002A01, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        public static readonly Guid BarometricPressureTrend = new Guid(0x00002AA3, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        /// <summary>
        /// Gets the Bluetooth SIG-defined Battery Level Characteristic UUID.
        /// </summary>
        public static readonly Guid BatteryLevel = new Guid(0x00002A19, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        /// <summary>
        /// Gets the Bluetooth SIG-defined Blood Pressure Feature Characteristic UUID.
        /// </summary>
        public static readonly Guid BloodPressureFeature = new Guid(0x00002A49, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        /// <summary>
        /// Gets the Bluetooth SIG-defined Blood Pressure Measurement Characteristic UUID.
        /// </summary>
        public static readonly Guid BloodPressureMeasurement = new Guid(0x00002A35, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        public static readonly Guid BodyCompositionFeature = new Guid(0x00002A9B, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        public static readonly Guid BodyCompositionMeasurement = new Guid(0x00002A9C, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        /// <summary>
        /// Gets the Bluetooth SIG-defined Body Sensor Location Characteristic UUID.
        /// </summary>
        public static readonly Guid BodySensorLocation = new Guid(0x00002A38, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        public static readonly Guid BondManagementControlPoint = new Guid(0x00002AA4, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        public static readonly Guid BondManagementFeature = new Guid(0x00002AA5, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        /// <summary>
        /// Gets the Bluetooth SIG-defined BootKeyboardInputReport characteristic UUID.
        /// </summary>
        public static readonly Guid BootKeyboardInputReport = new Guid(0x00002A22, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        /// <summary>
        /// Gets the Bluetooth SIG-defined BootKeyboardOutputReport characteristic UUID.
        /// </summary>
        public static readonly Guid BootKeyboardOutputReport = new Guid(0x00002A32, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        /// <summary>
        /// Gets the Bluetooth SIG-defined BootMouseInputReport characteristic UUID.
        /// </summary>
        public static readonly Guid BootMouseInputReport = new Guid(0x00002A33, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        public static readonly Guid CentralAddresResolution = new Guid(0x00002AA6, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        public static readonly Guid CgmFeature = new Guid(0x00002AA8, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        public static readonly Guid CgmMeasurment = new Guid(0x00002AA7, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        public static readonly Guid CgmSessionRunTime = new Guid(0x00002AAB, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        public static readonly Guid CgmSessionStartTime = new Guid(0x00002AAA, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        public static readonly Guid CgmSpecificOpsControlPoint = new Guid(0x00002AAC, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        public static readonly Guid CgmStatus = new Guid(0x00002AA9, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        /// <summary>
        /// Gets the Bluetooth SIG-defined Csc Feature Characteristic UUID.
        /// </summary>
        public static readonly Guid CscFeature = new Guid(0x00002A5C, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        /// <summary>
        /// Gets the Bluetooth SIG-defined Csc Measurement Characteristic UUID.
        /// </summary>
        public static readonly Guid CscMeasurement = new Guid(0x00002A5B, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        /// <summary>
        /// Gets the Bluetooth SIG-defined CurrentTime characteristic UUID.
        /// </summary>
        public static readonly Guid CurrentTime = new Guid(0x00002A2B, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        /// <summary>
        /// Gets the Bluetooth SIG-defined CyclingPowerControlPoint characteristic UUID.
        /// </summary>
        public static readonly Guid CyclingPowerControlPoint = new Guid(0x00002A66, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        /// <summary>
        /// Gets the Bluetooth SIG-defined CyclingPowerFeature characteristic UUID.
        /// </summary>
        public static readonly Guid CyclingPowerFeature = new Guid(0x00002A65, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        /// <summary>
        /// Gets the Bluetooth SIG-defined CyclingPowerMeasurement characteristic UUID.
        /// </summary>
        public static readonly Guid CyclingPowerMeasurement = new Guid(0x00002A63, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        /// <summary>
        /// Gets the Bluetooth SIG-defined CyclingPowerVector characteristic UUID.
        /// </summary>
        public static readonly Guid CyclingPowerVector = new Guid(0x00002A64, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        public static readonly Guid DatabaseChangeIncrement = new Guid(0x00002A99, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        /// <summary>
        /// Gets the Bluetooth SIG-defined DateTime characteristic UUID.
        /// </summary>
        public static readonly Guid DateOfBirth = new Guid(0x00002A85, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        public static readonly Guid DateOfThresholdAssessment = new Guid(0x00002A86, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        public static readonly Guid DateTime = new Guid(0x00002A08, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        /// <summary>
        /// Gets the Bluetooth SIG-defined DayDateTime characteristic UUID.
        /// </summary>
        public static readonly Guid DayDateTime = new Guid(0x00002A0A, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        /// <summary>
        /// Gets the Bluetooth SIG-defined DayOfWeek characteristic UUID.
        /// </summary>
        public static readonly Guid DayOfWeek = new Guid(0x00002A09, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        public static readonly Guid DescriptorValueChanged = new Guid(0x00002A7D, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        public static readonly Guid DeviceName = new Guid(0x00002A00, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        public static readonly Guid DewPoint = new Guid(0x00002A7B, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        public static readonly Guid Digital = new Guid(0x00002A56, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        /// <summary>
        /// Gets the Bluetooth SIG-defined DstOffset characteristic UUID.
        /// </summary>
        public static readonly Guid DstOffset = new Guid(0x00002A0D, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        public static readonly Guid Elevation = new Guid(0x00002A6C, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        //...
    }
}