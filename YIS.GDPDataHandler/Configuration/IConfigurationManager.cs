﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YIS.GDPDataHandler.Configuration
{
    public interface IConfigurationManager
    {
        NameValueCollection AppSettings { get; }
        void ClearCachedSettings();
    }
}
