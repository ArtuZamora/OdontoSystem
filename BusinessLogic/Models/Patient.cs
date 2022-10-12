using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Models
{
    public class Patient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Código")]
        public long Id { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(50)]
        [Display(Name = "Tipo de paciente")]
        public string TypeName { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(50)]
        [Display(Name = "Primer nombre")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(50)]
        [Display(Name = "Segundo nombre")]

        public string MiddleName { get; set; }


        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(50)]
        [Display(Name = "Apellidos")]

        public string LastName { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [RegularExpression("^[0-9]{2}$", ErrorMessage = "Debe ser una edad válida")]
        [Display(Name = "Edad")]
        public int Age  { get;   set;}



        [Required(ErrorMessage = "El campo es requerido")]
        [MinLength(5, ErrorMessage = "La dirección debe tener más de 5 caracteres")]
        [MaxLength(255)]
        [Display(Name = "Dirección")]
        public string? Address { get; set; }


        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^[0-9]{4}(['\'-]?|['\'s])[0-9]{4}$", ErrorMessage = "Digita un número de telefono válido")]
        [Display(Name = "Teléfono")]
        public string? CellPhone  { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [RegularExpression(@"^\\S+@\\S+\\.\\S+$", ErrorMessage = "Digita un email válido.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string? email { get; set; }



        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de registro")]
        public DateTime RegisterDate { get; set; }





    }
}
