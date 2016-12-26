﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Reflection;
using EntryPoint.Exceptions;
using EntryPoint.Internals;
using EntryPoint.Parsing;
using EntryPoint.OptionModel;

namespace EntryPoint.Parsing {
    internal static class Mapper {

        // Takes the input from the API and orchestrates the process of population
        public static Model MapOptions(Model model, ParseResult parseResult) {
            
            // Validate Model and Arguments
            model.ValidateNoDuplicateNames();
            ValidateTokensForDuplicateOptions(model, parseResult.TokenGroups);

            // Populate ArgumentsModel
            StoreOptions(model, parseResult);
            StoreOperands(model, parseResult);
            HandleUnusedOptions(model, parseResult.TokenGroups);

            return model;
        }

        static void StoreOptions(Model model, ParseResult parseResult) {
            foreach (var tokenGroup in parseResult.TokenGroups) {
                var modelOption = model.FindByToken(tokenGroup.Option);

                object value = modelOption.Definition.OptionStrategy.GetValue(modelOption, tokenGroup);
                modelOption.Property.SetValue(model.ApplicationOptions, value);
            }
            model.ApplicationOptions.Operands = parseResult.Operands.Select(t => t.Value).ToArray();
        }

        static void StoreOperands(Model model, ParseResult parseResult) {
            var operands = parseResult.Operands;
            foreach (var operand in model.Operands) {
                if (parseResult.OperandProvided(operand)) {
                    object value = operand.OperandStrategy.GetValue(operand, parseResult);
                    operand.Property.SetValue(model.ApplicationOptions, value);
                }
            }
        }

        // if an option was not provided, Validate whether it's marked as required
        static void HandleUnusedOptions(Model model, List<TokenGroup> usedOptions) {
            var requiredOption = model
                .WhereNotIn(usedOptions)
                .FirstOrDefault(mo => mo.Property.OptionIsRequired());

            if (requiredOption != null) {
                ValidateRequiredOption(requiredOption.Property, requiredOption.Definition);
            }
        }

        // If a property has a Required attribute, enforce the requirement
        static void ValidateRequiredOption(PropertyInfo property, BaseOptionAttribute option) {
            if (property.OptionIsRequired()) {
                throw new OptionRequiredException(
                    $"The option {EntryPointApi.DASH_SINGLE}{option.ShortName}/"
                    + $"{EntryPointApi.DASH_DOUBLE}{option.LongName} "
                    + "was not included, but is a required option");
            }
        }

        static void ValidateTokensForDuplicateOptions(Model model, List<TokenGroup> tokenGroups) {
            var duplicates = tokenGroups
                .Select(a => model.FindByToken(a.Option).Definition)
                .Duplicates(new BaseOptionAttributeEqualityComparer());

            if (duplicates.Any()) {
                throw new DuplicateOptionException(
                    $"Duplicate options were entered for " 
                    + $"${string.Join("/", duplicates.Select(o => o.LongName))}");
            }
        }
    }
}
