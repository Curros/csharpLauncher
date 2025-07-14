using csharpLauncher.Enums;
using csharpLauncher.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpLauncher.Services
{
    public class StepConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Model.StepBase);
        }

        public override object? ReadJson(JsonReader reader, Type objectType,
            object? existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var typeToken = jObject["Type"];
            if (typeToken == null)
                throw new JsonSerializationException("Missing Type property");

            var stepType = typeToken.ToObject<StepType>();
            StepBase target;

            switch (stepType)
            {
                case StepType.RunApp:
                    target = new Model.StepRunApp();
                    break;
                case StepType.Wait:
                    target = new Model.StepWait();
                    break;
                default:
                    throw new NotSupportedException($"Step type {stepType} not supported");
            }

            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
