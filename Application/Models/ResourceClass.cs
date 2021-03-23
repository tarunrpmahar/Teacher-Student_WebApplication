using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Application.Models
{
    public class ResourceClass
    {
        public int ResId { get; set; }

        [Required(ErrorMessage = "Upload Image")]
        [DisplayName("Cover Page Image")]
        public string Images { get; set; }

        [Required(ErrorMessage = "Enter the title")]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Enter Author")]
        [DisplayName("Author")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Enter Subjects")]
        [DisplayName("Subject")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Enter year")]
        [DisplayName("Year")]
        public int Years { get; set; }

        [Required(ErrorMessage = "Enter Descriptions")]
        [DisplayName("Descriptions")]
        public string Files { get; set; }
    }
}