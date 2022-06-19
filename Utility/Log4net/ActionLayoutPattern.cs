using log4net.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Log4net
{
    public class ActionLayoutPattern: PatternLayout
    {
        public ActionLayoutPattern()
        {
            this.AddConverter("actionInfo", typeof(ActionConverter));
        }
    }
}
