using System.ComponentModel.DataAnnotations;

namespace lab8_solution.Models;

public class Patient
{
    public int PatientID {get; set;} // Primary Key
    
    [Display(Name = "First Name")]
    [StringLength(20, MinimumLength = 3)]
    public string FirstName {get; set;} = string.Empty;
    
    [Display(Name = "Last Name")]
    [StringLength(20, MinimumLength = 3)]
    public string LastName {get; set;} = string.Empty;
    
    [Display(Name = "Admittance Date")]
    [DataType(DataType.Date)]
    public DateTime AdmitDate {get; set;}

    [Display(Name = "Description of Symptoms")]
    public string SymptomDescription {get; set;} = string.Empty;
}