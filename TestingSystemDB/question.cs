namespace TestingSystemDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("testing_system.questions")]
    public partial class Question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Question()
        {
            tests = new HashSet<Test>();
        }

        public int id { get; set; }

        public int discipline_id { get; set; }

        [Required]
        [StringLength(255)]
        public string question_text { get; set; }

        [Required]
        [StringLength(100)]
        public string correct_answer { get; set; }

        [StringLength(100)]
        public string incorrect_answer1 { get; set; }

        [StringLength(100)]
        public string incorrect_answer2 { get; set; }

        public bool? is_free_text { get; set; }

        public virtual Discipline discipline { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Test> tests { get; set; }
    }
}
