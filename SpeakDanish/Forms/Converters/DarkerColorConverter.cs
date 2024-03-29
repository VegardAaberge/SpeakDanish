﻿using System;
using System.Globalization;
using SpeakDanish.Extensions;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace SpeakDanish.Converters
{
    public class DarkerColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if(value is Boolean valueBoolean && parameter is Color color){
                if (valueBoolean)
                {
                    return color.Darker(0.7f);
                }
            }

            return parameter;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

