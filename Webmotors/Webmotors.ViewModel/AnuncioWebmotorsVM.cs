using System.ComponentModel.DataAnnotations;

namespace Webmotors.ViewModel
{
    public class AnuncioWebmotorsVM
    {
        public int Id { get; set; }

        [StringLength(45)]
        [Display(Name = "Marca")]
        public string Marca { get; set; }

        [StringLength(45)]
        [Display(Name = "Modelo")]        
        public string Modelo { get; set; }

        [StringLength(45)]
        [Display(Name = "Versão")]
        public string Versao { get; set; }
        
        [Display(Name = "Ano")]
        public int Ano { get; set; }

        [Display(Name = "Quilometragem")]
        public int Quilometragem { get; set; }

        [Display(Name = "Observação")]
        public string Observacao { get; set; }
    }
}
