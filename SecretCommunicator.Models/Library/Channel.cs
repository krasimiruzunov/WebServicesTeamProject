using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using SecretCommunicator.Models.Interfaces;

namespace SecretCommunicator.Models.Library
{
    [DataContract]
    public class Channel : IIdentifier
    {
        [DataMember(Name = "Id")]
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "CreatedDateTime")]
        public DateTime CreatedDateTime { get; set; }

        //[DataMember]
        public string Password { get; set; }

        [DataMember]
        public int NumberOfMessages { get; set; }

        [BsonIgnore]
        [DataMember]
        public List<Message> Messages { get; set; }

        public Channel()
        {
            Messages = new List<Message>();
        }
 
    }
}
