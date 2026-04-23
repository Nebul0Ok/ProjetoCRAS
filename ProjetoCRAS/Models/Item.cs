using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCRAS.Models
{
    public class Item
    {
        public int IDItem { get; set; }
        public string NomeItem { get; set; }
        public DateTime DataCadastroItem { get; set; }
        public List<TipoDeItem> TipoDeItems { get; set; }

        public Item(int IDItem, string NomeItem)
        {
            this.IDItem = IDItem;
            this.NomeItem = NomeItem;
            DataCadastroItem = DateTime.Now;
            TipoDeItems = new List<TipoDeItem>();
        }

        // Adiciona um tipo ao item
        public bool AdicionarTipoItem(TipoDeItem novoTipo, Usuario user)
        {
            if (novoTipo == null)
                return false;

            if (TipoDeItems.Any(t => t.IDTipo == novoTipo.IDTipo))
                return false;

            TipoDeItems.Add(novoTipo);

            Historico h = new Historico(user.NomeUsuario,$"Tipo '{novoTipo.NomeTipo}' adicionado ao item '{NomeItem}'");

            h.AdicionarHistoricoLista(h);

            return true;
        }

        // Remove um tipo do item
        public bool RemoveTipoItem(TipoDeItem itemRemovido, Usuario user)
        {
            if (itemRemovido == null)
                return false;

            var tipoExistente = TipoDeItems.FirstOrDefault(t => t.IDTipo == itemRemovido.IDTipo);

            if (tipoExistente == null)
                return false;

            TipoDeItems.Remove(tipoExistente);

            Historico h = new Historico(user.NomeUsuario,$"Tipo '{tipoExistente.NomeTipo}' removido do item '{NomeItem}'");

            h.AdicionarHistoricoLista(h);

            return true;
        }

        // Faz Update de tipo de item
        public bool AtualizarTipoItem(TipoDeItem tipoAtualizado, Usuario user)
        {
            if (tipoAtualizado == null)
                return false;

            var tipoExistente = TipoDeItems.FirstOrDefault(t => t.IDTipo == tipoAtualizado.IDTipo);

            if (tipoExistente == null)
                return false;

            tipoExistente.NomeTipo = tipoAtualizado.NomeTipo;
            tipoExistente.QuantidadeTipoEstoque = tipoAtualizado.QuantidadeTipoEstoque;
            tipoExistente.QuantidadeTipoProduto = tipoAtualizado.QuantidadeTipoProduto;
            tipoExistente.Medida = tipoAtualizado.Medida;

            Historico h = new Historico(user.NomeUsuario, $"Tipo '{tipoExistente.NomeTipo}' atualizado no item '{NomeItem}'");
            h.AdicionarHistoricoLista(h);

            return true;
        }
    }
}