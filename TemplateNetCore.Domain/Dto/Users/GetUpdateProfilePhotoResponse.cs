using System;

namespace TemplateNetCore.Domain.Dto.Users
{
    public class GetUpdateProfilePhotoResponse
    {
        public string Uri { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
