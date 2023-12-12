using PaldinoCrafts.Website.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PaldinoCrafts.Website.Util
{
    public class ProductUtils
    {

        public static IEnumerable<Product> readProducts(String data_filename)
        {
            using StreamReader file_reader = File.OpenText(data_filename);

            return JsonSerializer.Deserialize<Product[]>(file_reader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }


        public static void writeProducts(String data_filename, IEnumerable<Product> products)
        {
            //Save the rating data.
            using FileStream output_stream = File.OpenWrite(data_filename);
            JsonSerializer.Serialize<IEnumerable<Product>>(
                new Utf8JsonWriter(
                        output_stream, 
                        new JsonWriterOptions
                            {
                                SkipValidation = true,
                                Indented = true
                            }),
                products
            );
        }
    }
}
