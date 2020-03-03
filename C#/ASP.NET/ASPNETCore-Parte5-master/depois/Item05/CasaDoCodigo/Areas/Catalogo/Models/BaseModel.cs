using System;
using System.Runtime.Serialization;

namespace CasaDoCodigo.Areas.Catalogo.Models
{
    [DataContract]
    public abstract class BaseModel : IComparable
    {
        [DataMember]
        public int Id { get; set; }

        public int CompareTo(object obj)
        {
            if (!(obj is BaseModel outro)) return 1;

            return Id.CompareTo(outro.Id);
        }

        public override bool Equals(object obj)
        {
            return obj is BaseModel model &&
                   Id == model.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
