﻿using System;

namespace Registrar
{
    public class Option
    {
        private string _keyName = null;
        private string _subKey = null;
        private Validator _validator = null;
        private object _optionValue = null;

        public Option(string key_name, string sub_key, Validator validator, Object value)
        {
            _keyName = key_name;
            _subKey = sub_key;
            _validator = validator;
            _optionValue = value;
        }

        public bool RunValidators(Object value = null)
        {
            if (value == null)
            {
                value = _optionValue;
            }

            if (_validator != null)
            {
                bool option_valid = _validator.Validate(value);
                if (!option_valid)
                {
                    return false;
                }
            }
            
            return true;
        }

        public Object OptionValue
        {
            get { return _optionValue; }
            set { _optionValue = RunValidators(value); }
        }

        public string GetKeyName()
        {
            if (_subKey != null)
            {
                return _subKey + "\\" + _keyName;
            }
            return _keyName;
        }
    }

    public abstract class Validator
    {
        public abstract bool Validate(object value);
    }
}