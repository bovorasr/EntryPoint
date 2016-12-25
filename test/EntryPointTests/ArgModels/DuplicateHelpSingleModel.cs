﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EntryPoint;

namespace EntryPointTests.ArgModels {
    public class DuplicateHelpSingleModel : BaseApplicationOptions {
        [Option(DoubleDashName = "alpha", SingleDashChar = 'h')]
        public bool Alpha { get; set; }
    }
}
