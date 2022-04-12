namespace Card_Sanctum.Infrastructure.InitialSeed
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class InitialDataConfiguration<T> : IEntityTypeConfiguration<T>
        where T : class
    {
        private readonly string filePath;

        public InitialDataConfiguration(string _filePath)
        {
            filePath = _filePath;
        }

        public void Configure(EntityTypeBuilder<T> builder)
        {
            string? jsonData = GetFromFile();

            if (jsonData != null)
            {
                List<T> data = JsonConvert.DeserializeObject<List<T>>(jsonData);

                builder.HasData(data);
            }
        }

        private string? GetFromFile()
        {
            string? result = null;

            if (File.Exists(filePath))
            {
                result = File.ReadAllText(filePath);
            }

            return result;
        }
    }
}
