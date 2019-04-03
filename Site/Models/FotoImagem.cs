using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Site.Models
{
    public class FotoImagem
    {

        public int Id { get; set; }

        public int TipoEvento { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Insira uma descrição para foto")]
        [StringLength(50, ErrorMessage = "Digite entre 10 a 50 caracteres", MinimumLength = 10)]
        public string Descricao { get; set; }

        public bool Ativo { get; set; }

        [Display(Name = "Imagem")]
        public byte[] Path { get; set; }



        public static List<SelectListItem> ListTypeEvent()
        {
            return new List<SelectListItem>() {
                new SelectListItem() { Value = "1", Text = "Aniversário" },
                new SelectListItem() { Value = "2", Text = "Casamento" },
                new SelectListItem() { Value = "3", Text = "Confraternização" },
                new SelectListItem() { Value = "4", Text = "Casas Noturna" },
                new SelectListItem() { Value = "5", Text = "Debutante" },
                new SelectListItem() { Value = "6", Text = "Baile de Formatura" },
            };
        }
    }
}