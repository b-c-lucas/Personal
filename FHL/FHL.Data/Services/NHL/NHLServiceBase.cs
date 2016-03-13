using Newtonsoft.Json;
using System;

namespace FHL.Data.Services.NHL
{
    public abstract class NHLServiceBase
    {
        private static readonly Lazy<JsonSerializer> JsonSerializerLazy = new Lazy<JsonSerializer>();

        protected static JsonSerializer JsonSerializer => JsonSerializerLazy.Value;
    }
}
