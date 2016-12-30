﻿using EntryPoint.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntryPoint {

    /// <summary>
    /// The base class which must be derived from for an OptionsModel  implementation
    /// </summary>
    public abstract class BaseCliArguments : ICliHelpable {
        /// <summary>
        /// The base class which must be derived from for an OptionsModel implementation
        /// </summary>
        /// <param name="utilityName">The name of your utility or application</param>
        public BaseCliArguments(string utilityName) {
            UtilityName = utilityName;
        }
        internal BaseCliArguments() { }

        internal string UtilityName { get; set; }
    
        /// <summary>
        /// All trailing arguments left after the list of Options and OptionParameters
        /// </summary>
        public string[] Operands { get; internal set; }


        // ** Baked in Options **
        
        [Option(
            LongName = "help", ShortName = 'h')]
        [Help(
            "Display the Help Documentation")]
        public bool HelpRequested { get; set; }
    }

}