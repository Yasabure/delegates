using DelegatesEvents;

var lista = new Lista();

lista.Notificar += Notificar;
lista.Add("A");
lista.Add("B");
lista.Add("C");

Action<Lista> action = new Action<Lista>(i => Console.WriteLine(i));
Func<Lista, bool> func = new Func<Lista, bool>(i => i.Id == 1);
Predicate<Lista> pred = new Predicate<Lista>(i => i.Id == 3);

var exist = lista.ExistItem(pred);
lista.PrintAllItems(action);
Console.WriteLine(exist);

static void Notificar()
{
    Console.WriteLine("Fui Notificado");
}
