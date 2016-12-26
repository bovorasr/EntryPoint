﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EntryPoint;

namespace EntryPointTests.ArgModels {
    public class BoolArgsModel : BaseApplicationOptions {
        [OptionParameter(
            LongName = "default-false",
            ShortName = 'a')]
        public bool DefaultFalse { get; set; }

        [OptionParameter(
            LongName = "default-null",
            ShortName = 'b')]
        public bool? DefaultNull { get; set; }

        [OptionParameter(
            LongName = "default-true",
            ShortName = 'c',
            DefaultValueBehaviour = DefaultValueBehaviourEnum.CustomValue,
            CustomDefaultValue = true)]
        public bool DefaultTrue { get; set; }
    }
}
