using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace bagAPI.Models
{
    public class Child
    {
        [Key]
        public int ChildId {get; set;}
        
        [Required]
        public string Name {get; set;}

        [DefaultValue (0)]
        public int Delivered {get; set;}

        //Many part of the relationship.
        //Child can have many toys, so we set up an ICollection to store them in. 
        ICollection<Toy> Toys;

    }
}