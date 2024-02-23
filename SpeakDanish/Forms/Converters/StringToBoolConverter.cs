﻿using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace SpeakDanish.Converters
{
	public class StringToBoolConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value?.ToString() is string valueString)
                return valueString.Trim().Length > 0;
            return value;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

