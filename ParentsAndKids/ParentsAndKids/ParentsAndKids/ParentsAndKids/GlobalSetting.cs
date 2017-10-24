using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParentsAndKids {
    public class GlobalSetting {

        private static readonly GlobalSetting _instance = new GlobalSetting();

        /// <summary>
        ///     ctor().
        /// </summary>
        public GlobalSetting() {

        }

        public static GlobalSetting Instance {
            get { return _instance; }
        }
    }
}
