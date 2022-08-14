using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WsCACC.Model
{
    public class Retorno
    {
        public bool success { get; set; }
        public object data { get; set; }
        public List<ErrorItem> itens { get; set; }

        public Retorno()
        {
            this.success = false;
            this.itens = new List<ErrorItem>();
        }

        public void addItem(string message)
        {
            itens.Add(new ErrorItem { message = message });
        }
    }

    public class ErrorItem
    {
        public string message { get; set; }
    }
}
