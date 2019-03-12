namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CMS_User
    {
        [Key]
        public int uid { get; set; }

        [StringLength(50)]
        public string uname { get; set; }

        [Required]
        [StringLength(50)]
        public string upwd { get; set; }

        [StringLength(50)]
        public string nname { get; set; }

        [StringLength(50)]
        public string mobile { get; set; }

        [StringLength(50)]
        public string face { get; set; }

        public int admin { get; set; }
    }
}
