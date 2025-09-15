using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FabricaPastas.BD.Data.Entity
{

    //#region indices
    //[Index(nameof(Tipo_Cliente_Id), Name = "Tipo_Cliente_Id_UQ", IsUnique = true)]
    //[Index(nameof(Descripcion),
    //Name = "Descripcion", IsUnique = false)]
    //#endregion
    public class Tipo_Cliente : EntityBase
    {

        //[JsonPropertyName("id")]
        //public int Id { get; set; }

        #region Clave primaria
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("tipo_Cliente_Id")]
        public int Tipo_Cliente_Id { get; set; }
        #endregion

        #region Atributos 
        [JsonPropertyName("descripcion")]
        [Required(ErrorMessage = "El campo Descripción es obligatorio")]
        [MaxLength(255, ErrorMessage = "Máximo número de caracteres {1}")]
        public string? Descripcion { get; set; }
        #endregion






    }


}
