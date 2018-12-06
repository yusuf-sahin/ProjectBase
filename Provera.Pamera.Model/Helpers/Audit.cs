using System;
using Provera.Pamera.Model.Abstract;

namespace Provera.Pamera.Model.Helpers
{
    public class Audit:IEntity
    {
        public Audit()
        {
        }

        public int Id { get; set; }
        public string TableName { get; set; }
        public DateTime DateTime { get; set; }
        public string KeyValues { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
    }
}
