namespace DelegatesEvents
{
    public delegate void Notificacao();
    public class Lista
    {
        private List<Lista> _items = new List<Lista>();
        public int Id {get ; set ; }
        public string Item {get ; set ;}
        public DateTime DataCriacao => DateTime.Now;
        public IReadOnlyCollection<Lista> GetListas => _items;
        public event Notificacao Notificar;

        public void Add(string item)
        {
            var itemLista = new Lista();
            itemLista.Id += this._items.Count;
            itemLista.Item = item;
            this._items.Add(itemLista);
            EventHandler();
        }
        public void EventHandler()
        {
            Notificar();
        }
        public void PrintAllItems(Action<Lista> action)
        {
            this._items.ForEach(action);
            //this._items.ForEach(s => Console.WriteLine(s));
        }

        public Lista GetItemById(Func<Lista, bool> func)
        {
            return this._items.FirstOrDefault(func);
        }
        public bool ExistItem(Predicate<Lista> pred)
        {
            return this._items.Exists(pred);
        }

        
    }
}

