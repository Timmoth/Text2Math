namespace Text2Math;

/// <summary>
///     Base class for abstract syntax tree node
/// </summary>
public abstract record AstNode
{
    /// <summary>
    ///     Evaluates the current AST node and returns the result.
    /// </summary>
    /// <returns>The evaluated result.</returns>
    public abstract double Evaluate((string name, double value)[] variables);
}

/// <summary>
///     Represents a multiplication node
/// </summary>
/// <param name="Left">left factor</param>
/// <param name="Right">right factor</param>
public record MulNode(AstNode Left, AstNode Right) : AstNode
{
    /// <inheritdoc />
    public override double Evaluate((string name, double value)[] variables)
    {
        return Left.Evaluate(variables) * Right.Evaluate(variables);
    }
}

/// <summary>
///     Represents a exponent node, raises 'left' to the power of 'right'
/// </summary>
/// <param name="Left">left factor</param>
/// <param name="Right">right factor</param>
public record ExponentNode(AstNode Left, AstNode Right) : AstNode
{
    /// <inheritdoc />
    public override double Evaluate((string name, double value)[] variables)
    {
        return Math.Pow(Left.Evaluate(variables), Right.Evaluate(variables));
    }
}

/// <summary>
///     Represents a division node, divides 'left' by 'right'
/// </summary>
/// <param name="Left">left factor</param>
/// <param name="Right">right factor</param>
public record DivNode(AstNode Left, AstNode Right) : AstNode
{
    /// <inheritdoc />
    public override double Evaluate((string name, double value)[] variables)
    {
        return Left.Evaluate(variables) / Right.Evaluate(variables);
    }
}

/// <summary>
///     Represents an addition node
/// </summary>
/// <param name="Left">left factor</param>
/// <param name="Right">right factor</param>
public record AddNode(AstNode Left, AstNode Right) : AstNode
{
    /// <inheritdoc />
    public override double Evaluate((string name, double value)[] variables)
    {
        return Left.Evaluate(variables) + Right.Evaluate(variables);
    }
}

/// <summary>
///     Represents a subtraction node
/// </summary>
/// <param name="Left">left factor</param>
/// <param name="Right">right factor</param>
public record SubNode(AstNode Left, AstNode Right) : AstNode
{
    /// <inheritdoc />
    public override double Evaluate((string name, double value)[] variables)
    {
        return Left.Evaluate(variables) - Right.Evaluate(variables);
    }
}

/// <summary>
///     Represents a modulo node, performs left % right
/// </summary>
/// <param name="Left">left factor</param>
/// <param name="Right">right factor</param>
public record ModNode(AstNode Left, AstNode Right) : AstNode
{
    /// <inheritdoc />
    public override double Evaluate((string name, double value)[] variables)
    {
        return Left.Evaluate(variables) % Right.Evaluate(variables);
    }
}

/// <summary>
///     Represents a numeric node
/// </summary>
/// <param name="Value">Value</param>
public record NumberNode(double Value) : AstNode
{
    /// <inheritdoc />
    public override double Evaluate((string name, double value)[] variables)
    {
        return Value;
    }
}

/// <summary>
///     Represents a variable node
/// </summary>
/// <param name="Name">Name</param>
public record VariableNode(string Name) : AstNode
{
    /// <inheritdoc />
    public override double Evaluate((string name, double value)[] variables)
    {
        foreach (var (name, value) in variables)
        {
            if (name == Name)
            {
                return value;
            }
        }

        return 0;
    }
}

/// <summary>
///     Represents Pi
/// </summary>
public record PiNode : AstNode
{
    /// <inheritdoc />
    public override double Evaluate((string name, double value)[] variables)
    {
        return Math.PI;
    }
}

/// <summary>
///     Represents E
/// </summary>
public record EulerNode : AstNode
{
    /// <inheritdoc />
    public override double Evaluate((string name, double value)[] variables)
    {
        return Math.E;
    }
}

/// <summary>
///     Calculates the natural logarithm (base e) of the child node
/// </summary>
/// <param name="Child"></param>
public record LogNode(AstNode Child) : AstNode
{
    /// <inheritdoc />
    public override double Evaluate((string name, double value)[] variables)
    {
        return Math.Log(Child.Evaluate(variables));
    }
}

/// <summary>
///     Calculates the square root of the child node
/// </summary>
/// <param name="Child"></param>
public record SqrtNode(AstNode Child) : AstNode
{
    /// <inheritdoc />
    public override double Evaluate((string name, double value)[] variables)
    {
        return Math.Sqrt(Child.Evaluate(variables));
    }
}

/// <summary>
///     Calculates the sine of the child node
/// </summary>
/// <param name="Child"></param>
public record SinNode(AstNode Child) : AstNode
{
    /// <inheritdoc />
    public override double Evaluate((string name, double value)[] variables)
    {
        return Math.Sin(Child.Evaluate(variables));
    }
}

/// <summary>
///     Calculates the tangent of the child node
/// </summary>
/// <param name="Child"></param>
public record TanNode(AstNode Child) : AstNode
{
    /// <inheritdoc />
    public override double Evaluate((string name, double value)[] variables)
    {
        return Math.Tan(Child.Evaluate(variables));
    }
}

/// <summary>
///     Calculates the cosine of the child node
/// </summary>
/// <param name="Child"></param>
public record CosNode(AstNode Child) : AstNode
{
    /// <inheritdoc />
    public override double Evaluate((string name, double value)[] variables)
    {
        return Math.Cos(Child.Evaluate(variables));
    }
}

/// <summary>
///     Unary positive factor
/// </summary>
/// <param name="Child"></param>
public record PlusNode(AstNode Child) : AstNode
{
    /// <inheritdoc />
    public override double Evaluate((string name, double value)[] variables)
    {
        return Child.Evaluate(variables);
    }
}

/// <summary>
///     Unary negative factor
/// </summary>
/// <param name="Child"></param>
public record MinusNode(AstNode Child) : AstNode
{
    /// <inheritdoc />
    public override double Evaluate((string name, double value)[] variables)
    {
        return -Child.Evaluate(variables);
    }
}