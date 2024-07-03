## Lexer

[Tokens](https://github.com/Timmoth/Text2Math/blob/main/Text2Math/TokenType.cs) are the fundamental building blocks of a programming language, each serving a distinct purpose and conforming to a specific pattern that can be used to identify it from the input source code. A sequence of characters in the source code that matches a token's pattern is known as a [lexeme](https://github.com/Timmoth/Text2Math/blob/main/Text2Math/Token.cs).

The role of a [lexer (or tokenizer)](https://github.com/Timmoth/Text2Math/blob/main/Text2Math/Lexer.cs) is to process the source code and translate it into a sequence of tokens.

The tokens used in this project are as follows and are defined in the [TokenType](https://github.com/Timmoth/Text2Math/blob/main/Text2Math/TokenType.cs) enum.

| name   | example |
|--------|---------|
| number | 1.2     |
| plus   | +       |
| minus  | -       |
| mul    | *       |
| div    | /       |
| mod    | %       |
| lparen | (       |
| rparen | )       |
| caret  | ^       |
| log    | log     |
| pi     | pi      |
| euler  | e       |
| sqrt   | sqrt    |
| sin    | sin     |
| cos    | cos     |
| tan    | tan     |



The [lexer class](https://github.com/Timmoth/Text2Math/blob/main/Text2Math/Lexer.cs) processes the source code to produce a sequence of tokens. Each call to the `NextToken` method performs the following steps to update the `CurrentToken`:

- If the lexer has processed the entire source code, it will return an end-of-file (Eof) token.
- The lexer will skip over any whitespace (' ') it encounters.
- If the lexer encounters a digit or a '.' character, it will buffer them and return a numeric token.
- If the lexer encounters a single symbol or a sequence of letters, it will match them to a known token pattern from the table above.

## Parser

Our [parser's](https://github.com/Timmoth/Text2Math/blob/main/Text2Math/Parser.cs) job is to take the sequence of tokens produced by the lexer and use them to build an Abstract Syntax Tree (AST) which is comprised of nodes, each representing a specific construct from the source code. Once constructed, the AST can be traversed to execute or further process the program.

All AST node can be found [here](https://github.com/Timmoth/Text2Math/blob/main/Text2Math/AstNode.cs).

```
For the expression 1 + 2:

AdditionNode
├── NumericNode(1)
├── NumericNode(2)
```

```
For the expression pi + 2 * 3:

AdditionNode
├── PiNode
├── MultiplicationNode
    ├── NumericNode(2)
    └── NumericNode(4)
```

## Grammar

The grammar rules define how expressions are structured in the language:

```
term : factor ((mul | div | caret | mod) factor)*
factor : number | log | sin | cos | tan | sqrt | plus | minus | pi | e | lparen expression rparen
expression : term ((plus | minus) term)*
```

##### Term

`term : factor ((mul | div | caret | mod) factor)*`

A term consists of a factor followed by zero or more instances of a multiplication (*), division (/), exponentiation (^), or modulo (%) operator and another factor.

##### Factor

`factor : number | log | sin | cos | tan | sqrt | plus | minus | pi | e | lparen expression rparen`

- A number (e.g., 3, 4.5)
- A log function (e.g., log(10))
- A sin function (e.g., sin(pi/2))
- A cos function (e.g., cos(0))
- A tan function (e.g., tan(pi/4))
- A sqrt function (e.g., sqrt(4))
- A unary plus (+) indicating a positive number (e.g., +3)
- A unary minus (-) indicating a negative number (e.g., -5)
- The mathematical constants pi or e
- An expression enclosed in parentheses (lparen expression rparen)

##### Expression

`expression : term ((plus | minus) term)*`

An expression consists of a term followed by zero or more instances of a plus (+) or minus (-) operator and another term.

##### Evaluation

In our [implementation](https://github.com/Timmoth/Text2Math/blob/main/Text2Math/AstNode.cs), each node in the AST has an Evaluate method, which when called, returns the result of its operation. For instance, an AdditionNode has two child nodes; when its Evaluate method is called, it will call the Evaluate method on each of the child nodes and then return the sum of their results.