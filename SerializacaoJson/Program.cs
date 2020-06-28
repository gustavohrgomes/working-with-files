using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using SerializacaoJson.Entitites;

namespace SerializacaoJson
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<WeatherForecast> weatherForecast = new List<WeatherForecast>();

            string jsonFileInput = @"D:\temp\input.json";
            string jsonFileOutput = @"D:\temp\output.json";

            using (var jsonReader = File.OpenText(jsonFileInput))
            {
                weatherForecast = JsonSerializer.Deserialize<IEnumerable<WeatherForecast>>(jsonReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }

            using (var jsonWriter = File.OpenWrite(jsonFileOutput))
            {
                JsonSerializer.Serialize(new Utf8JsonWriter(jsonWriter,
                    new JsonWriterOptions
                    {
                        Indented = true,
                        SkipValidation = true
                    }),
                    weatherForecast
                    );
            }
        }
    }
}
