using Chromely.Core.Configuration;
using Chromely.Core.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client_Interface.ChromelyControllers
{
    [ControllerProperty(Name = "MatchmakingController", Route = "matchamking")]
    public class MatchmakingController : ChromelyController
    {

        private readonly IChromelyConfiguration _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="DemoController"/> class.
        /// </summary>
        public MatchmakingController(IChromelyConfiguration config)
        {
            _config = config;

        
        }
    }
}
