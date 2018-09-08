﻿using System;

namespace Registrar
{
    public class RegOption
    {
        private string _keyName = null;
        private string _subKeys = null;
        private IValidator _validator = null;
        private object _optionValue = null;

        public RegOption(string key_name, string sub_keys, IValidator validator, Object value)
        {
            _keyName = key_name;
            _subKeys = sub_keys;
            _validator = validator;
            _optionValue = value;
        }

        public ValidationResponse Validate(Object value = null)
        {
            ValidationResponse response = new ValidationResponse();
            if (value == null)
            {
                value = _optionValue;
            }

            if (_validator != null)
            {
                bool option_valid = _validator.Validate(value);
                if (!option_valid)
                {
                    response.Successful = false;
                    response.Information = _validator.Description();
                    //return _validator.Description();
                }
                else
                {
                    response.Successful = true;
                    response.Information = "Successfully processed option.";
                }
            }

            return response;
        }

        public Object OptionValue
        {
            get { return _optionValue; }
            set { _optionValue = Validate(value); }
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

    public interface IValidator
    {
        bool Validate(object value);
        string Description();
    }

    public class ValidationResponse
    {
        public bool Successful { get; set; }
        public string Information { get; set; }
    }
}