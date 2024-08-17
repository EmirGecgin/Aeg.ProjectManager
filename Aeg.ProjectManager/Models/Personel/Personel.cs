using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aeg.ProjectManager.Models.Personel
{
    public class Personel
    {
        public Personel()
        {
           this.Projects = new HashSet<Project.Project>();
        }
        [Key]
        public int Id { get; set; }
        
        public string email { get; set; }
        [StringLength(25,ErrorMessage ="Maximum lenght must be 25 characters.")]
        public string password { get; set; }
        [StringLength(15, ErrorMessage = "Maximum lenght must be 15 characters.")]
        [Display(Name = "Authority")]
        public string Auth { get; set; }
        [StringLength(50, ErrorMessage = "Maximum lenght must be 50 characters.")]
        public string NameSurname { get; set; }
        public string PersonelImage { get; set; }
        [StringLength(15, ErrorMessage = "Maximum lenght must be 15 characters.")]
        public string PersonelId { get; set; }
        [StringLength(25, ErrorMessage = "Maximum lenght must be 25 characters.")]
        public string Department { get; set; }
        [StringLength(25, ErrorMessage = "Maximum lenght must be 25 characters.")]
        public string Duty { get; set; }
        public string PositionDescription { get; set; }
        [StringLength(15, ErrorMessage = "Maximum lenght must be 15 characters.")]
        public string Phone { get; set; }
        public string Address { get; set; }
        [StringLength(25, ErrorMessage = "Maximum lenght must be 25 characters.")]
        public string MaritalStatus { get; set; }
        [StringLength(25, ErrorMessage = "Maximum lenght must be 25 characters.")]
        public string NearlyInfo { get; set; }
        [StringLength(25, ErrorMessage = "Maximum lenght must be 25 characters.")]
        public string NearlyNameSurname { get; set; }
        [StringLength(25, ErrorMessage = "Maximum lenght must be 25 characters.")]
        public string NearlyPhoneNumber { get; set; }
        [StringLength(25, ErrorMessage = "Maximum lenght must be 25 characters.")]
        public string NearlyId { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? StartDate { get; set; }
        public virtual ICollection<Project.Project> Projects { get; set; }
    }
}