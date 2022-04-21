// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using Nima.Instagram.Server.Middleware.IdentityServer.Controllers.Consent;

namespace Nima.Instagram.Server.Middleware.IdentityServer.Controllers.Device
{
    public class DeviceAuthorizationInputModel : ConsentInputModel
    {
        public string UserCode { get; set; }
    }
}