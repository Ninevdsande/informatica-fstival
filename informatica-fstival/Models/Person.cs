using System;
using System.ComponentModel.DataAnnotations;

namespace informatica_fstival.Models
{
    public class Person
    {
        [Required (ErrorMessage = "Gelieve uw voornaam in te vullen")]
        public string FirstName { get; set; }
      
        [Required (ErrorMessage = "Gelieve uw achternaam in te vullen")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "E-mailadres is verplicht")]
        [EmailAddress(ErrorMessage = "Geen geldig email adres")]
        public string Email { get; set; }
        public string Telefoon { get; set; }
        public string Address { get; set; }
      
        [Required(ErrorMessage = "Gelieve uw opmerking of vraag achter te laten")]
        public string Description { get; set; }

    }
}
