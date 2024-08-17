using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aeg.ProjectManager.Models.Project
{
    public class Project
    {
        public Project()
        {
            this.Personels = new HashSet<Personel.Personel>();
        }
        
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Maximum lenght must be 50 characters.")]
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(25, ErrorMessage = "Maximum lenght must be 25 characters.")]
        public string PriorityStatus { get; set; }
        public int DoneRatio { get; set; }
        public DateTime? DoneDate { get; set; }
        public bool doneStatus { get; set; }    
        public virtual ICollection<Personel.Personel> Personels { get; set; }
    }
}