// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;

namespace MicroserviceAralık.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new List<ApiResource>()
       {
           new ApiResource("ResourceCatalog")
           {
               Scopes={ "CatalogReadPermission", "CatalogFullPermission" }
           },
           new ApiResource("ResourceDiscount")
           {
               Scopes={ "DiscountReadPermission", "DiscountFullPermission" }
           }
           ,
           new ApiResource("ResourceOrder")
           {
               Scopes={ "OrderReadPermission", "OrderFullPermission" }
           },
            new ApiResource("ResourceCargo")
           {
               Scopes={ "CargoReadPermission", "CargoFullPermission" }
           },
             new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
          
       };

        public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>()
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),

        };

        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>()
        {
            new ApiScope("CatalogReadPermission","Read Access To Catalog Resource"),
            new ApiScope("CatalogFullPermission","Full Access To Catalog Resource"),

            new ApiScope("DiscountReadPermission","Read Access To Discount Resource"),
            new ApiScope("DiscountFullPermission","Full Access To Discount Resource"),

            new ApiScope("OrderReadPermission","Read Access To Order Resource"),
            new ApiScope("OrderFullPermission","Full Access To Order Resource"),

            new ApiScope("CargoReadPermission","Read Access To Cargo Resource"),
            new ApiScope("CargoFullPermission","Full Access To Cargo Resource"),


            new ApiScope(IdentityServerConstants.LocalApi.ScopeName),


        };


        public static IEnumerable<Client> Clients => new List<Client>()
        {
            new Client{
            ClientId ="VisitorId",
            ClientName ="Visitor Client",
            AllowedGrantTypes =GrantTypes.ClientCredentials,
            ClientSecrets = { new Secret("VisitorSecret".Sha256()) },
            AllowedScopes={ "CatalogReadPermission", "DiscountReadPermission" } //OrderReadPermission

            },

            //admin
            new Client
            {
                  ClientId ="AdminId",
                  ClientName ="Admin Client",
                  AllowedGrantTypes =GrantTypes.ResourceOwnerPassword,
                  ClientSecrets = { new Secret("AdminSecret".Sha256()) },
                  AllowedScopes={ "CatalogFullPermission", "DiscountFullPermission" , "OrderFullPermission","CargoFullPermission", IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                IdentityServerConstants.LocalApi.ScopeName
                } ,
                  AccessTokenLifetime=720

            }
        };
    }
}

