using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Provera.Pamera.API.ViewModels
{
    [DataContract(IsReference = true)]
    [JsonObject(IsReference = false)]
    public class ProductVM
    {
        public int Id
        {
            get;
            set;
        }

        //[Required(ErrorMessage = "Please enter name")]
        //[StringLength(60, MinimumLength = 2)]
        public string Name
        {
            get;
            set;
        }

        //[Required(ErrorMessage = "Please enter description")]
        //[StringLength(100, MinimumLength = 2)]
        public string Description
        {
            get;
            set;
        }

        public string Memo
        {
            get;
            set;
        }

        public ProductVM()
        {
        }
    }
}
