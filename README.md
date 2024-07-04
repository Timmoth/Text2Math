# Text2Math

Contains a well tested simple mathematical expression evaluator.

- [Overview](https://timmoth.github.io/Text2Math/)
- [Internals](https://timmoth.github.io/Text2Math/internals/)
- [Releases](https://timmoth.github.io/Text2Math/releases/)
- [Support](https://timmoth.github.io/Text2Math/support/)
- [Contributing](https://timmoth.github.io/Text2Math/contributing/)


## Language
```
expression   : term ((plus | minus ) term)*
term         : factor((mul | div | caret | mod) factor)*
factor       : number | variable | log | sin | cos | tan | sqrt | plus | minus | pi | e | lparen expression rparen

```

| Name              | Description                                                | Examples                       |
|-------------------|------------------------------------------------------------|--------------------------------|
| number            | double precision floating point number                     | "1.23", ".23", "4", "-1", "+2" |
| parentheses       | Grouping expressions to enforce precedence in calculations | "(1+2) / 3"                    |
| multiplication    | Multiplication of two numbers                              | "1 * 2"                        |
| division          | Division of one number by another                          | "1 / 2"                        |
| addition          | Addition of two numbers                                    | "1 + 2"                        |
| subtraction       | Subtraction of one number from another                     | "1 - 2"                        |
| exponent          | Raising a number to the power of another number            | "2 ^ 2"                        |
| natural logarithm | Natural logarithm (base e) of a number                     | "log 2", "log(pi/2)            |
| square root       | Square root of a number                                    | "sqrt 2", "sqrt(pi/2)          |
| sine              | Sine of an angle (in radians)                              | "sin 2", "sin(pi/2)            |
| cosine            | Cosine of an angle (in radians)                            | "cos 2", "cos(pi/2)            |
| tangent           | Tangent of an angle (in radians)                           | "tan 2", "tan(pi/2)            |
| pi                | The mathematical constant π (approximately 3.14159)        | "pi"                           |
| euler             | The mathematical constant e (approximately 2.71828)        | "e"                            |
| variable          | A named value passed in externally during evaluation       | "x", "testvar"                 |

## Usage

``` cs
var result = "sqrt(x^2 + (sin(x) / cos(x))^2) + log(e^y)".Evaluate(("x", 2), ("y", 3))
```

## Benchmarks

Benchmark Expression
```
sqrt(.4 ^ 2) - (4 * tan 5 - cos(-2)) / sin(e^4) + log(pi - 1.2)
```
Benchmark Results
| Method                              |     Mean |    Error |   StdDev |   Gen0 | Allocated |
|-------------------------------------|---------:|---------:|---------:|-------:|----------:|
| Tokenization                        | 282.2 ns |  5.32 ns |  5.47 ns | 0.0048 |      40 B |
| Tokenization + Parsing              | 710.9 ns | 13.44 ns | 14.38 ns | 0.0782 |     656 B |
| Tokenization + Parsing + Evaluation | 817.0 ns | 14.31 ns | 14.69 ns | 0.0782 |     656 B |

## Notes

- I've made the library as extensible as possible, it shouldn't be too difficult to add aditional functions - PR's are welcome!
- I've tried to make the library as efficient as possible by using readonly spans to keep memory allocation down