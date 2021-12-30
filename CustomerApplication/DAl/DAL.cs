using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApplication.DAl
{
    public interface IDAL
    {
        public string GUID { get; set; }
        public void Add();
        public void Update();

    }


    public class EfDAl : IDAL
    {
        public string GUID { get; set; }
        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }

    public class AdoDAl : IDAL
    {
        public string GUID { get; set; }
        public AdoDAl()
        {
            this.GUID = System.Guid.NewGuid().ToString();

        }
      
        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }


}
