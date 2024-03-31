using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tcc.EntityModels
{
    public class EntityBase
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Required]
        [Column("dt_creation")]
        public DateTime DateCreation { get; set; }
        [Required]
        [Column("dt_modified")]
        public DateTime DateModification { get; set; }

        public void Generate()
        {
            Id = Guid.NewGuid();
            DateCreation = DateTime.Now;
            DateModification = DateTime.Now;
        }
    }
}
