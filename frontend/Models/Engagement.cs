using System.ComponentModel.DataAnnotations;

namespace frontend.Models
{
    public class Engagement
    {
        public string ID { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Client { get; set; } = string.Empty;
        public string Employee { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime Started { get; set; }

        [DataType(DataType.Date)]
        public DateTime Ended { get; set; }
    }
}
