﻿//-----------------------------------------------------------------------
// <copyright file="Radio.cs" company="In The Hand Ltd">
//   Copyright (c) 2017-18 In The Hand Ltd, All rights reserved.
//   This source code is licensed under the MIT License - see License.txt
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
#if WINDOWS_UWP
using Windows.Devices.Radios;
#endif

namespace InTheHand.Devices.Radios
{
    /// <summary>
    /// Represents a radio device on the system.
    /// </summary>
    /// <remarks>
    /// <para/><list type="table">
    /// <listheader><term>Platform</term><description>Version supported</description></listheader>
    /// <item><term>Android</term><description>Android 4.4 and later</description></item>
    /// <item><term>iOS</term><description>iOS 9.0 and later</description></item>
    /// <item><term>macOS</term><description>OS X 10.7 and later</description></item>
    /// <item><term>tvOS</term><description>tvOS 9.0 and later</description></item>
    /// <item><term>Windows UWP</term><description>Windows 10</description></item>
    /// <item><term>Windows Phone Store</term><description>Windows Phone 8.1 or later</description></item>
    /// <item><term>Windows Phone Silverlight</term><description>Windows Phone 8.0 or later</description></item>
    /// <item><term>Windows (Desktop Apps)</term><description>Windows 7 or later</description></item></list>
    /// </remarks>
    public sealed partial class Radio
    {
        /// <summary>
        /// A static, asynchronous method that retrieves a collection of <see cref="Radio"/> objects representing radio devices existing on the system.
        /// </summary>
        /// <returns>An asynchronous retrieval operation. When the operation is complete, contains a list of Radio objects describing available radios.</returns>
        /// <remarks>
        /// <para/><list type="table">
        /// <listheader><term>Platform</term><description>Version supported</description></listheader>
        /// <item><term>Android</term><description>Android 4.4 and later</description></item>
        /// <item><term>iOS</term><description>iOS 9.0 and later</description></item>
        /// <item><term>macOS</term><description>OS X 10.7 and later</description></item>
        /// <item><term>tvOS</term><description>tvOS 9.0 and later</description></item>
        /// <item><term>Windows UWP</term><description>Windows 10</description></item>
        /// <item><term>Windows Phone Store</term><description>Windows Phone 8.1 or later</description></item>
        /// <item><term>Windows Phone Silverlight</term><description>Windows Phone 8.0 or later</description></item>
        /// <item><term>Windows (Desktop Apps)</term><description>Windows 7 or later</description></item></list>
        /// </remarks>
        public static async Task<IReadOnlyList<Radio>> GetRadiosAsync()
        {
            List<Radio> radios = new List<Radio>();

#if WINDOWS_UWP || __ANDROID__ || __UNIFIED__ || WIN32 || WINDOWS_PHONE_APP || WINDOWS_PHONE
            await DoGetRadiosAsync(radios);
#endif
            return radios.AsReadOnly();
        }

        /// <summary>
        /// An asynchronous method that retrieves a value indicating what access the current user has to the radio represented by this object.
        /// In circumstances where user permission is required to access the radio, this method prompts the user for permission.
        /// Consequently, always call this method on the UI thread.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <para/><list type="table">
        /// <listheader><term>Platform</term><description>Version supported</description></listheader>
        /// <item><term>Windows UWP</term><description>Windows 10</description></item>
        /// <item><term>Windows (Desktop Apps)</term><description>Windows 7 or later (Not required)</description></item>
        /// </remarks>
        public static async Task<RadioAccessStatus> RequestAccessAsync()
        {
#if WINDOWS_UWP || WIN32
            return await DoRequestAccessAsync();

#else
            return RadioAccessStatus.Unspecified;
#endif
        }

        private Radio()
        {
        }

        /// <summary>
        /// An asynchronous operation that attempts to set the state of the radio represented by this object.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks>
        /// <para/><list type="table">
        /// <listheader><term>Platform</term><description>Version supported</description></listheader>
        /// <item><term>Android</term><description>Android 4.4 and later</description></item>
        /// <item><term>Windows UWP</term><description>Windows 10</description></item>
        /// <item><term>Windows (Desktop Apps)</term><description>Windows 7 or later</description></item></list>
        /// </remarks>
        public Task<RadioAccessStatus> SetStateAsync(RadioState value)
        {
#if WINDOWS_UWP || __ANDROID__ || WIN32
            return DoSetStateAsync(value);

#else
            return Task.FromResult(RadioAccessStatus.Unspecified);
#endif
        }

        /// <summary>
        /// Gets an enumeration value that describes what kind of radio this object represents.
        /// </summary>
        /// <value>The kind of this radio.</value>
        /// <remarks>
        /// <para/><list type="table">
        /// <listheader><term>Platform</term><description>Version supported</description></listheader>
        /// <item><term>Android</term><description>Android 4.4 and later</description></item>
        /// <item><term>iOS</term><description>iOS 9.0 and later</description></item>
        /// <item><term>macOS</term><description>OS X 10.7 and later</description></item>
        /// <item><term>tvOS</term><description>tvOS 9.0 and later</description></item>
        /// <item><term>Windows UWP</term><description>Windows 10</description></item>
        /// <item><term>Windows Phone Store</term><description>Windows Phone 8.1 or later</description></item>
        /// <item><term>Windows Phone Silverlight</term><description>Windows Phone 8.0 or later</description></item>
        /// <item><term>Windows (Desktop Apps)</term><description>Windows 7 or later</description></item></list>
        /// </remarks>
        public RadioKind Kind
        {
            get
            {
#if WINDOWS_UWP || __ANDROID__ || __UNIFIED__ || WIN32 || WINDOWS_APP || WINDOWS_PHONE_APP || WINDOWS_PHONE
                return GetKind();

#else
                return RadioKind.Other;
#endif
            }
        }

        /// <summary>
        /// Gets the name of the radio represented by this object.
        /// </summary>
        /// <value>The radio name.</value>
        /// <remarks>
        /// <para/><list type="table">
        /// <listheader><term>Platform</term><description>Version supported</description></listheader>
        /// <item><term>Android</term><description>Android 4.4 and later</description></item>
        /// <item><term>iOS</term><description>iOS 9.0 and later</description></item>
        /// <item><term>macOS</term><description>OS X 10.7 and later</description></item>
        /// <item><term>tvOS</term><description>tvOS 9.0 and later</description></item>
        /// <item><term>Windows UWP</term><description>Windows 10</description></item>
        /// <item><term>Windows Phone Store</term><description>Windows Phone 8.1 or later</description></item>
        /// <item><term>Windows Phone Silverlight</term><description>Windows Phone 8.0 or later</description></item>
        /// <item><term>Windows (Desktop Apps)</term><description>Windows 7 or later</description></item></list>
        /// </remarks>
        public string Name
        {
            get
            {
#if WINDOWS_UWP || __ANDROID__ || __UNIFIED__ || WIN32 || WINDOWS_APP || WINDOWS_PHONE_APP || WINDOWS_PHONE
                return GetName();
#else
                return string.Empty;
#endif
            }
        }

        /// <summary>
        /// Gets the current state of the radio represented by this object.
        /// </summary>
        /// <value>The current radio state.</value>
        /// <remarks>
        /// <para/><list type="table">
        /// <listheader><term>Platform</term><description>Version supported</description></listheader>
        /// <item><term>Android</term><description>Android 4.4 and later</description></item>
        /// <item><term>iOS</term><description>iOS 9.0 and later</description></item>
        /// <item><term>macOS</term><description>OS X 10.7 and later</description></item>
        /// <item><term>tvOS</term><description>tvOS 9.0 and later</description></item>
        /// <item><term>Windows UWP</term><description>Windows 10</description></item>
        /// <item><term>Windows Phone Store</term><description>Windows Phone 8.1 or later</description></item>
        /// <item><term>Windows Phone Silverlight</term><description>Windows Phone 8.0 or later</description></item>
        /// <item><term>Windows (Desktop Apps)</term><description>Windows 7 or later</description></item></list>
        /// </remarks>
        public RadioState State
        {
            get
            {
#if WINDOWS_UWP ||  __ANDROID__ || __UNIFIED__ || WIN32 || WINDOWS_APP || WINDOWS_PHONE_APP || WINDOWS_PHONE
                return GetState();
#else
                return RadioState.Unknown;
#endif
            }
        }
    }
}