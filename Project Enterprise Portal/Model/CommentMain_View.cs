namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CommentMain_View
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cmid { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int aid { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int uid { get; set; }

        public DateTime? cmtime { get; set; }

        [StringLength(50)]
        public string cmhtml { get; set; }

        [StringLength(40)]
        public string title { get; set; }

        [StringLength(10)]
        public string author { get; set; }

        public DateTime? ctime { get; set; }

        public DateTime? ptime { get; set; }

        public bool? istop { get; set; }

        public int? state { get; set; }

        public int? hits { get; set; }

        public int? comments { get; set; }

        [Column(TypeName = "text")]
        public string ahtml { get; set; }

        [StringLength(50)]
        public string uname { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string upwd { get; set; }

        [StringLength(50)]
        public string nname { get; set; }

        [StringLength(50)]
        public string mobile { get; set; }

        [StringLength(50)]
        public string face { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int admin { get; set; }
    }
}
