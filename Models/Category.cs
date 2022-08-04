using System.Text.Json.Serialization;

namespace APIs.NET
{
    public class Category
    {
        //[Key]
        public Guid CategoryId { get; set; }

        //[Required]
        //[MaxLength(150)]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Peso { get; set; }

        //creamos una relacion virtual para poder hacer la relacion con la tabla Task
        [JsonIgnore]
        public virtual ICollection<Task> Task { get; set; }
    }
}