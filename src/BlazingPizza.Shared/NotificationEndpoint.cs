using System.ComponentModel.DataAnnotations;

namespace BlazingPizza
{
    public class NotificationEndpoint
    {
        [Key]
        public string UserId { get; set; }

        public string Url { get; set; }
    }
}
