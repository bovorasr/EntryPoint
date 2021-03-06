﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EntryPoint;
using EntryPoint.Exceptions;
using EntryPointTests.Arguments.Helpers;

namespace EntryPointTests.Arguments.AppOptionModels {
    public class HelpWithRequiredArgsModel : BaseCliArguments {
        public HelpWithRequiredArgsModel() : base("APP_NAME") { }

        [Required]
        [OptionParameter(
            LongName: "param-required",
            ShortName: 'r')]
        [Help("PARAM_REQUIRED_HELP_STRING")]
        public int ParamRequired { get; set; }

        [OptionParameter(LongName: "param-2",
                         ShortName: 'o')]
        [Help("PARAM_OPTIONAL_HELP_STRING")]
        public string StringOption { get; set; }

        [Required]
        [Operand(1)]
        public string OneOperand { get; set; }

        public override void OnHelpInvoked(string helpText) {
            throw new HelpTriggeredSuccessException();
        }

        public override void OnUserFacingException(UserFacingException e, string message) {
            throw e;
        }
    }
}
