using System;
using System.Collections.Generic;
using System.Text;

namespace LeafFilter.HelpDesk.Model.Base
{
    public interface IStatusEntity : IConditionEntity 
    {        
        public int Order { get; set; }
    }
}
