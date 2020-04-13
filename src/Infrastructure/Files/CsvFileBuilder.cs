﻿using Clean_Architecture_Asp_Net_Core_Starter.Application.Common.Interfaces;
using Clean_Architecture_Asp_Net_Core_Starter.Application.TodoLists.Queries.ExportTodos;
using Clean_Architecture_Asp_Net_Core_Starter.Infrastructure.Files.Maps;
using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Clean_Architecture_Asp_Net_Core_Starter.Infrastructure.Files
{
    public class CsvFileBuilder : ICsvFileBuilder
    {
        public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

                csvWriter.Configuration.RegisterClassMap<TodoItemRecordMap>();
                csvWriter.WriteRecords(records);
            }

            return memoryStream.ToArray();
        }
    }
}
