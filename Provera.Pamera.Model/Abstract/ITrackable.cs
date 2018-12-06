using System;
using System.Collections.Generic;
using System.Text;

namespace Provera.Pamera.Model.Abstract
{
    public interface ITrackable
    {
        string CreatedBy { set; get; }
        DateTime CreatedAt { get; set; }
        string ModifiedBy { set; get; }
        DateTime ModifiedAt { get; set; }       
    }
}
