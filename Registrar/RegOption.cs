﻿using System;

namespace Registrar
{
    public class RegOption
    {
        private string _keyName = null;
        private string _subKeys = null;
        private IValidator _validator = null;
        private object _optionValue = null;
        private Type _optionType = null;

        public RegOption(string key_name, IValidator validator, Object value, Type value_type, string sub_keys = null)
        {
            _keyName = key_name;

            string keyOut;
            if (sub_keys != null)
            {
                if (sub_keys[0] != '/')
                {
                    sub_keys = '/' + sub_keys;

                }
                keyOut = sub_keys.Replace(@"/", @"\\");
                _subKeys = keyOut;
            }

            _validator = validator;
            _optionValue = value;
            _optionType = value_type;
        }

        // I need a way to check if the thing I am setting it to is valid,
        // And a way to check if the current value is valid.
        public ValidationResponse Validate(Object value = null)
        {
            bool option_valid = _validator.Validate(value);
            ValidationResponse response = new ValidationResponse
            {
                Successful = true,
                Information = "Successfully processed option."
            };

            if (_validator != null)
            {
                if (value == null)
                {
                    value = _optionValue;
                }

                if (!option_valid)
                {
                    response.Successful = false;
                    response.Information = _validator.Description();
                }
            }

            return response;
        }

        public Object OptionValue
        {
            get { return _optionValue; }
        }

        public ValidationResponse SetOptionValue(Object value)
        {
            ValidationResponse response = Validate(value);

            if (response.Successful)
            {
                _optionValue = Convert.ChangeType(value.ToString(), _optionType);
            }

            return response;
        }

        public string GetSubKeys()
        {
            return _subKeys;
        }

        public string GetKeyName()
        {
            return _keyName;
        }
    }
}
