﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EntryPoint;

namespace EntryPointTests.ArgModels {
    public class IntegerArgsModel : BaseApplicationOptions {
        [OptionParameter(
            DoubleDashName = "default-zero",
            SingleDashChar = 'a')]
        public int DefaultZero { get; set; }

        [OptionParameter(
            DoubleDashName = "default-null",
            SingleDashChar = 'b')]
        public int? DefaultNull { get; set; }

        [OptionParameter(
            DoubleDashName = "default-7",
            SingleDashChar = 'c',
            ParameterDefaultBehaviour = ParameterDefaultEnum.CustomValue,
            ParameterDefaultValue = 7)]
        public int Default7 { get; set; }
    }
}