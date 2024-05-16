using System.Security.Cryptography.X509Certificates;

namespace ASP_NET_Core_MVC_Academy.Models
{
    public class Academy
    {
        // инициализируется коллекция Groups типа HashSet<Group>(), используется для хранения групп в академии
        public Academy()
        {
            this.Groups = new HashSet<Group>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? EMail { get; set; }

        public ICollection<Group> Groups { get; set; } // коллекция групп, принадлежащих к данной академии
    }
}
