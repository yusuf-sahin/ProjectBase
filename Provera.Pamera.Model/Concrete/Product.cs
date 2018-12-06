using Provera.Pamera.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Provera.Pamera.Model.Concrete
{
    public class Product : IEntity,ITrackable,ISoftDeletable
    {
        public int Id { get ; set ; }
        public string CreatedBy { get ; set ; }
        public DateTime CreatedAt { get ; set ; }
        public string ModifiedBy { get ; set ; }
        public DateTime ModifiedAt { get ; set ; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Memo { get; set; }
 
    }
}
