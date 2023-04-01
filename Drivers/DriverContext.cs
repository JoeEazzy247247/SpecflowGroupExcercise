using BoDi;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowGroupExcercise.Drivers
{
    public class DriverContext
    {
        public IPlaywright _playwright;
        public IBrowser _browser;
        public IPage _page;
        public IObjectContainer _container;
    }
}
