﻿using David_Studio_Server.Database.Base;
using David_Studio_Server.Database.Models.Content.Services;
using System.Text.Json.Serialization;

namespace David_Studio_Server.Database.Models.Content.Translation
{
    public class Translation : Identity
    {
        public Translation()
        {
            ServiceTitleTranslations = new HashSet<ServiceTranslation>();
            ServiceDescriptionTranslations = new HashSet<ServiceTranslation>();
        }

        public string Text { get; set; } = null!;
        public int LanguageId { get; set; }

        [JsonIgnore]
        public virtual Language Language { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<ServiceTranslation> ServiceTitleTranslations { get; set; }
        [JsonIgnore]
        public virtual ICollection<ServiceTranslation> ServiceDescriptionTranslations { get; set; }
    }
}
