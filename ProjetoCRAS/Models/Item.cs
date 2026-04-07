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

        public Item(int IDItem, string NomeItem, List<TipoDeItem> TipoDeItem) {
            this.IDItem = IDItem;
            this.NomeItem = NomeItem;
            DataCadastroItem = DateTime.Now;
            TipoDeItems = new List<TipoDeItem>();
        }

        //Adiciona um item
        public void AdicionarTipoItem(TipoDeItem novoTipo, Usuario user) {
            TipoDeItems.Add(novoTipo);
            Historico h = new Historico(user.NomeUsuario, "Item Adicionado"); //TODO: Trocar a string por uma formatada com o nome do tipo de item
            h.AdicionarHistoricoLista(h); //Adiciona a ação no histórico
        }

        //Remove um item
        public void RemoveTipoItem(TipoDeItem itemRemovido, Usuario user)
        {
            if (TipoDeItems.Contains(itemRemovido)) {
                TipoDeItems.Remove(itemRemovido);
                Historico h = new Historico(user.NomeUsuario, "Item Removido"); //TODO: Trocar a string por uma formatada com o nome do tipo de item
                h.AdicionarHistoricoLista(h);
            }
            
        }

    }
}
