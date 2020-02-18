using System.ComponentModel.DataAnnotations;

namespace GerenciamentoEvento.DTO {
    public class VendaDTO {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int Capacidade { get; set; }

        public System.DateTime Data { get; set; }

        public double Preco { get; set; }

        public int CasaDeShowID { get; set; }

        public string Estilo { get; set; }

        public string Imagem { get; set; }
        public bool Status { get; set; }

        public int Qtd { get; set; }

       
        public string Usuario { get; set; }

        public int Total { get; set; }

    }
}