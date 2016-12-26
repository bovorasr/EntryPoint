﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EntryPoint;

namespace EntryPointTests.ArgModels {
    public class RequiredParameterArgsModel : BaseApplicationOptions {
        [OptionParameter(
            LongName = "param-required",
            ShortName = 'r')]
        [OptionRequired]
        public int ParamRequired { get; set; }

        [OptionParameter(
            LongName = "param-optional",
            ShortName = 'o',
            DefaultValueBehaviour = DefaultValueBehaviourEnum.CustomValue,
            CustomDefaultValue = 7)]
        public int ParamOptional { get; set; }
    }
}
