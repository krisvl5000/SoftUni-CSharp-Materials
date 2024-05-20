using ForumApp2024.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp2024.Infrastructure.Data.Models
{
    [Comment("Posts table")]
    public class Post
    {
        [Key]
        [Comment("Post Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.TitleMaxLength)]
        [Comment("Post title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(ValidationConstants.ContentMaxLength)]
        [Comment("Post content")]
        public string Content { get; set; } = string.Empty;
    }
}
