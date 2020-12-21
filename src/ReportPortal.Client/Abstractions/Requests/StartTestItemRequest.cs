﻿using ReportPortal.Client.Abstractions.Models;
using ReportPortal.Client.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ReportPortal.Client.Abstractions.Requests
{
    /// <summary>
    /// Defines a content of request for service to create new test item in progress state.
    /// </summary>
    [DataContract]
    public class StartTestItemRequest
    {
        /// <summary>
        /// ID of parent launch to create new test item.
        /// </summary>
        [DataMember(Name = "launchUuid")]
        public string LaunchUuid { get; set; }

        private string _name;

        /// <summary>
        /// A short name of test item.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get { return _name; } set { _name = StringTrimmer.Trim(value, 1024); } }

        /// <summary>
        /// A long description of test item.
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = true)]
        public string Description { get; set; }

        /// <summary>
        /// Date time when new test item is created.
        /// </summary>
        [DataMember(Name = "startTime")]
        public string StartTimeString { get; set; } = DateTimeConverter.ConvertFrom(DateTime.UtcNow);

        public DateTime StartTime
        {
            get
            {
                return DateTimeConverter.ConvertTo(StartTimeString);
            }
            set
            {
                StartTimeString = DateTimeConverter.ConvertFrom(value);
            }
        }

        /// <summary>
        /// A type of test item.
        /// </summary>
        [DataMember(Name = "type")]
        public string TypeString { get { return EnumConverter.ConvertFrom(Type); } set { Type = EnumConverter.ConvertTo<TestItemType>(value); } }

        public TestItemType Type { get; set; } = TestItemType.Test;

        /// <summary>
        /// A list of tags.
        /// </summary>
        [Obsolete("Use Attributes instead of Tags.")]
        [DataMember(Name = "tags", EmitDefaultValue = false)]
        public IEnumerable<string> Tags { get; set; }

        /// <summary>
        /// Retry status indicator.
        /// </summary>
        [DataMember(Name = "retry")]
        public bool IsRetry { get; set; }

        /// <summary>
        /// Test Item to be marked as retry.
        /// </summary>
        [DataMember(Name = "retryOf")]
        public string RetryOf { get; set; }

        /// <summary>
        /// A list of parameters.
        /// </summary>
        [DataMember(Name = "parameters")]
        public IList<KeyValuePair<string, string>> Parameters { get; set; }

        /// <summary>
        /// A test item unique id.
        /// </summary>
        [DataMember(Name = "uniqueId", EmitDefaultValue = true)]
        public string UniqueId { get; set; }

        /// <summary>
        /// Test Case ID.
        /// </summary>
        [DataMember(Name = "testCaseId")]
        public string TestCaseId { get; set; }

        /// <summary>
        /// Code reference for test. Example: namespace + classname + methodname
        /// </summary>
        [DataMember(Name = "codeRef")]
        public string CodeReference { get; set; }

        /// <summary>
        /// Define if test item has stats. If false - considered as nested step.
        /// </summary>
        [DataMember(Name = "hasStats")]
        public bool HasStats { get; set; } = true;

        /// <summary>
        /// Test item attributes.
        /// </summary>
        [DataMember(Name = "attributes")]
        public IList<ItemAttribute> Attributes { get; set; }
    }
}
