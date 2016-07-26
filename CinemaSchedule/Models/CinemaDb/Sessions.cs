namespace CinemaSchedule
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Sessions
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Theater { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Movie { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "date")]
        public DateTime Date { get; set; }

        [Key]
        [Column(Order = 4)]
        public TimeSpan Time { get; set; }
    }
}
