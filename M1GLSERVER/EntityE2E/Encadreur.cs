using System.Collections.Generic;

namespace M1GLSERVER.EntityE2E
{
    public class Encadreur : Utilisateur
    {
        public ICollection<Memoire> Memoires { get; set; }
    }
}
