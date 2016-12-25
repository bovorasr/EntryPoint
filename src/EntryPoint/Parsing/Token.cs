﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntryPoint.Parsing {
    internal class Token : IEquatable<Token> {
        public string Value { get; set; }
        public bool IsOption { get; set; }

        internal Token(string text, bool isOption) {
            Value = text;
            IsOption = isOption;
        }

        public bool Equals(Token other) {
            return this.Value == other.Value 
                && this.IsOption == other.IsOption;
        }


        // ** Helpers **

        // Determines if this token is a -o option
        public bool IsSingleDashOption() {
            return this.IsOption
                && this.Value.StartsWith(EntryPointApi.DASH_SINGLE)
               && !this.Value.StartsWith(EntryPointApi.DASH_DOUBLE);
        }

        // Determines if this token is a --opt option
        public bool IsDoubleDashOption() {
            return this.IsOption
                && this.Value.StartsWith(EntryPointApi.DASH_DOUBLE);
        }

        // Splits a -o option token into multiple tokens like:
        // [-abc]
        // to:
        // [-a] [-b] [-c]
        public List<Token> SplitSingleOptions() {
            if (!this.IsSingleDashOption()) {
                throw new InvalidOperationException(
                    $"arg.{nameof(SplitSingleOptions)}() should only be used with Single dash args");
            }

            return this
                .Value
                .Trim(EntryPointApi.DASH_SINGLE.ToCharArray())
                .ToCharArray()
                .Select(c => new Token(EntryPointApi.DASH_SINGLE + c, true))
                .ToList();
        }
    }
}