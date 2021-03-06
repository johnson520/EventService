﻿using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using EventService.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;

namespace EventService.Data
{
    public static class EventsTable
    {
        private const string PartitionKey = "event";

        private static readonly CloudStorageAccount azureStorage = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["AzureStorage"].ConnectionString
            );

        private static readonly CloudTableClient tableClient = azureStorage.CreateCloudTableClient();

        private static readonly CloudTable table = tableClient.GetTableReference("events");

        static EventsTable()
        {
            table.CreateIfNotExists();
        }

        public static EventModel Create(EventModel em)
        {
            em.eventId = NextEventId();

            var tableResult = table.Execute(TableOperation.Insert(new EventsTableEntity(em)));
            var ete = (EventsTableEntity)tableResult.Result;
            return ete?.theEvent;
        }

        public static EventModel Update(EventModel em)
        {
            var tableResult = table.Execute(TableOperation.Retrieve<EventsTableEntity>(PartitionKey, RowKey(em)));
            var ete = (EventsTableEntity)tableResult.Result;

            if (ete == null)
                return null;

            ete.theEvent = em;
            tableResult = table.Execute(TableOperation.Replace(ete));
            ete = (EventsTableEntity)tableResult.Result;
            return ete?.theEvent;
        }

        private static long NextEventId()
        {
            var events = GetAll();
            return events.Count > 0 ? events.Max(e => e.eventId) + 1 : 1;
        }

        public static EventModel GetOne(long id)
        {
            var tableResult = table.Execute(TableOperation.Retrieve<EventsTableEntity>(PartitionKey, RowKey(id)));
            var ete = (EventsTableEntity)tableResult.Result;
            return ete?.theEvent;
        }

        public static List<EventModel> GetAll()
        {
            return table.CreateQuery<EventsTableEntity>().Where(te => te.PartitionKey == PartitionKey).ToList().Select(te => te.theEvent).ToList();
        }

        private static string RowKey(EventModel em)
        {
            return RowKey(em.eventId);
        }

        private static string RowKey(long id)
        {
            return id.ToString("D5");
        }

        public static bool Delete(long id)
        {
            var tableResult = table.Execute(TableOperation.Retrieve<EventsTableEntity>(PartitionKey, RowKey(id)));
            var ete = (EventsTableEntity)tableResult.Result;

            if (ete == null)
                return false;

            tableResult = table.Execute(TableOperation.Delete(ete));
            return tableResult.Result != null;
        }

        private class EventsTableEntity : TableEntity
        {
            public EventsTableEntity()
            {
            }

            public EventsTableEntity(EventModel em)
            {
                PartitionKey = EventsTable.PartitionKey;
                RowKey = RowKey(em);

                _jsonEvent = JsonConvert.SerializeObject(em);
            }

            // ReSharper disable once MemberCanBePrivate.Local
            public string _jsonEvent { get; set; }

            public EventModel theEvent
            {
                get => JsonConvert.DeserializeObject<EventModel>(_jsonEvent);
                set => _jsonEvent = JsonConvert.SerializeObject(value);
            }
        }
    }
}
