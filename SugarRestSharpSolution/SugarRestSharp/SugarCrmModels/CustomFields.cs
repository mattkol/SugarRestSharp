// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591

namespace SugarRestSharp.Models
{
	using System;
	using Newtonsoft.Json;
	

    /// <summary>
    /// A class which represents the custom_fields table.
    /// </summary>
	[ModuleProperty(ModuleName = "CustomFields", TableName="custom_fields")]
	public partial class CustomFields : EntityBase
	{
		[JsonProperty(PropertyName = "bean_id")]
		public virtual string BeanId { get; set; }

		[JsonProperty(PropertyName = "set_num")]
		public virtual int? SetNum { get; set; }

		[JsonProperty(PropertyName = "field0")]
		public virtual string Field0 { get; set; }

		[JsonProperty(PropertyName = "field1")]
		public virtual string Field1 { get; set; }

		[JsonProperty(PropertyName = "field2")]
		public virtual string Field2 { get; set; }

		[JsonProperty(PropertyName = "field3")]
		public virtual string Field3 { get; set; }

		[JsonProperty(PropertyName = "field4")]
		public virtual string Field4 { get; set; }

		[JsonProperty(PropertyName = "field5")]
		public virtual string Field5 { get; set; }

		[JsonProperty(PropertyName = "field6")]
		public virtual string Field6 { get; set; }

		[JsonProperty(PropertyName = "field7")]
		public virtual string Field7 { get; set; }

		[JsonProperty(PropertyName = "field8")]
		public virtual string Field8 { get; set; }

		[JsonProperty(PropertyName = "field9")]
		public virtual string Field9 { get; set; }

		[JsonProperty(PropertyName = "deleted")]
		public virtual sbyte? Deleted { get; set; }

	}
}