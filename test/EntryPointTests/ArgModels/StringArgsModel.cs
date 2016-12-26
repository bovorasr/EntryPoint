﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EntryPoint;

namespace EntryPointTests.ArgModels {
    public class StringArgsModel : BaseApplicationOptions {
        [OptionParameter(
            LongName = "default-null",
            ShortName = 'a')]
        public string DefaultNull { get; set; }

        [OptionParameter(
            LongName = "default-no-name",
            ShortName = 'b',
            DefaultValueBehaviour = DefaultValueBehaviourEnum.CustomValue,
            CustomDefaultValue = "NoName")]
        public string DefaultNoName { get; set; }
    }
}
