//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#pragma warning disable
namespace WildlifeAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Sighting
    {
/*        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]*/
        public int ID { get; set; }
        public int SpeciesID { get; set; }
        public decimal XCoordinate { get; set; }
        public decimal YCoordinate { get; set; }
        public System.DateTime TimeStamp { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string County { get; set; }
    }
}
