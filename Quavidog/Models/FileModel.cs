using Microsoft.AspNetCore.Mvc;

namespace Quavidog.Models
{
    public class FileModel
    {
        public string Table { get; set; } = string.Empty;
        public string Column { get; set; } = string.Empty;
        public long Id { get; set; }
    }
}
