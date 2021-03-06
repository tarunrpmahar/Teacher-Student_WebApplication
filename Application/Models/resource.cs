//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Application.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class resource
    {
        public int re_id { get; set; }

        [Required(ErrorMessage = "Upload Image")]
        [DisplayName("Cover Page Image")]
        public string images { get; set; }

        [Required(ErrorMessage = "Enter the title")]
        [DisplayName("Title")]
        public string title { get; set; }

        [Required(ErrorMessage = "Enter the Author")]
        [DisplayName("Author")]
        public string author { get; set; }

        [Required(ErrorMessage = "Enter the Subject")]
        [DisplayName("Subject")]
        public string subjects { get; set; }

        [Required(ErrorMessage = "Enter year")]
        [DisplayName("Year")]
        public int years { get; set; }

        [Required(ErrorMessage = "Enter Descriptions")]
        [DisplayName("Descriptions")]
        public string descriptions { get; set; }
    }
}
