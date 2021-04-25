# International Recipe Converter
## Intro
What is a `Cup`, `Gallon`, `Pint` or `Quart`? Those units might be confusing to different observers. It might be useful to put then all in perspective through the lens of standardised metrics.

For our first problem, we will take a recipe and will try to convert it into something with consistent units.

## Requirements
### Convert cooking units to SI units
Here is a list of standard cooking units:

Cooking Unit|SI unit
---|---
Cup|0.24 l
Gallon|3.79 l
Fluid Ounce|29.57 ml
Pint|0.47 l
Quart|0.95 l
Tablespoon|14.79 ml
Teaspoon|4.93 ml

~~Based on this table, every cooking unit should be converted to an SI unit equivalent.~~

### No 100s
~~If the cooking unit is more than `100` of any SI unit, it should be converted to the next grade of it. For example, `100 ml` should be `0.1 l` instead. However, `10 ml` is fine by itself.~~

### Reverse conversion
~~Given recipes with `ml` and `l` units, you should be able to convert them back to cooking units.~~

### Is recipe valid?
~~A recipe might miss an amount. For example "Pour 5 spoons of sugar and tablespoons". Here tablespoons are missing the amount. For scenarios like this, we should not try to guess the amount was and should not allow to even start working with such a recipe.~~

### Chaos fixing
~~Some recipes are inconsistent in the way they define cooking units (after all, we're all people and not machines, right?). For example, if you have `3 teaspoons`, there should be an option to convert it to `1 tablespoon`. Similar to `100 ml` being converted to `0.1 l`, we should pick the largest appropriate unit of cooking as well.~~

### File extension
~~Recipe files should end with `.recipe`. Any file that does not should be rejected.~~

### No non-recipe files
~~If a file has no cooking or other units of volume then it should be rejected. This includes an empty file.~~