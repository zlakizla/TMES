using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;


namespace AECSCore
{
    public class Worker : Person
    {
        #region Properties

        private IEnumerable<Tool> _tools;
        public IEnumerable<Tool> Tools 
        { 
            get
            {
                if(_tools == null)
                {
                    _tools = new List<Tool>();
                }
                return _tools;
            }
            set
            {
                _tools = value;
            }
        }
        
        #endregion Properties

        #region Methods 
        
      

        #endregion Methods



    }
}
