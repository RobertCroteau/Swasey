﻿using System;
using System.Linq;
using System.Threading.Tasks;

using Swasey.Model;

namespace Swasey
{

    public delegate Task<string> SwaggerJsonLoader(Uri uri);

    public delegate void SwaseyOperationWriter(string name, string content, IOperationDefinition definition);

    public delegate void SwaseyEnumWriter(string name, string content, IEnumDefinition definition);

    public delegate void SwaseyModelWriter(string name, string content, IModelDefinition definition);


    internal static class Defaults
    {

        public const string DefaultApiNamespace = "Service.Client.Api";

        public const string DefaultModelNamespace = "Service.Client.Model";

        public static Task<string> DefaultSwaggerJsonLoader(Uri uri)
        {
            throw new NotImplementedException();
        }

        public static void DefaultSwaseyEnumWriter(string name, string content, IEnumDefinition definition)
        {
            throw new NotImplementedException();
        }

        public static void DefaultSwaseyModelWriter(string name, string content, IModelDefinition definition)
        {
            throw new NotImplementedException();
        }

        public static void DefaultSwaseyOperationWriter(string name, string content, IOperationDefinition definition)
        {
            throw new NotImplementedException();
        }

    }
}
