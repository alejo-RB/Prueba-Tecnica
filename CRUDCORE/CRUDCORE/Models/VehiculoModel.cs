using System.ComponentModel.DataAnnotations;

namespace CRUDCORE.Models
{
    public class VehiculoModel
    {
        public int id { get; set; }

        [Required(ErrorMessage ="El campo Codigo es obligatorio")]
        public string? codigo { get; set; }
        [Required(ErrorMessage = "El campo Chasis es obligatorio")]
        public string? chasis { get; set; }
        [Required(ErrorMessage = "El campo Marca es obligatorio")]
        public string? marca { get; set; }
        [Required(ErrorMessage = "El campo Modelo es obligatorio")]
        public string? modelo { get; set; }
        [Required(ErrorMessage = "El campo Año del modelo es obligatorio")]
        public int? anio_modelo { get; set; }
        [Required(ErrorMessage = "El campo Color es obligatorio")]
        public string? color { get; set; }
        [Required(ErrorMessage = "El campo Estado es obligatorio")]
        public string? estado { get; set; }
        [Required(ErrorMessage = "El campo Fecha de registro es obligatorio")]
        public DateTime? fecha_registro { get; set; }
    }
}
