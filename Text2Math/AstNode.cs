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
    public abstract double Evaluate();
}

/// <summary>
///     Represents a multiplication node
/// </summary>
/// <param name="Left">left factor</param>
/// <param name="Right">right factor</param>
public record MulNode(AstNode Left, AstNode Right) : AstNode
{
    /// <inheritdoc />
    public override double Evaluate()
    {
        return Left.Evaluate() * Right.Evaluate();
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
    public override double Evaluate()
    {
        return Math.Pow(Left.Evaluate(), Right.Evaluate());
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
    public override double Evaluate()
    {
        return Left.Evaluate() / Right.Evaluate();
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
    public override double Evaluate()
    {
        return Left.Evaluate() + Right.Evaluate();
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
    public override double Evaluate()
    {
        return Left.Evaluate() - Right.Evaluate();
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
    public override double Evaluate()
    {
        return Left.Evaluate() % Right.Evaluate();
    }
}

/// <summary>
///     Represents a numeric node
/// </summary>
/// <param name="Value">Value</param>
public record NumberNode(double Value) : AstNode
{
    /// <inheritdoc />
    public override double Evaluate()
    {
        return Value;
    }
}

/// <summary>
///     Represents Pi
/// </summary>
public record PiNode : AstNode
{
    /// <inheritdoc />
    public override double Evaluate()
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
    public override double Evaluate()
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
    public override double Evaluate()
    {
        return Math.Log(Child.Evaluate());
    }
}

/// <summary>
///     Calculates the square root of the child node
/// </summary>
/// <param name="Child"></param>
public record SqrtNode(AstNode Child) : AstNode
{
    /// <inheritdoc />
    public override double Evaluate()
    {
        return Math.Sqrt(Child.Evaluate());
    }
}

/// <summary>
///     Calculates the sine of the child node
/// </summary>
/// <param name="Child"></param>
public record SinNode(AstNode Child) : AstNode
{
    /// <inheritdoc />
    public override double Evaluate()
    {
        return Math.Sin(Child.Evaluate());
    }
}

/// <summary>
///     Calculates the tangent of the child node
/// </summary>
/// <param name="Child"></param>
public record TanNode(AstNode Child) : AstNode
{
    /// <inheritdoc />
    public override double Evaluate()
    {
        return Math.Tan(Child.Evaluate());
    }
}

/// <summary>
///     Calculates the cosine of the child node
/// </summary>
/// <param name="Child"></param>
public record CosNode(AstNode Child) : AstNode
{
    /// <inheritdoc />
    public override double Evaluate()
    {
        return Math.Cos(Child.Evaluate());
    }
}

/// <summary>
///     Unary positive factor
/// </summary>
/// <param name="Child"></param>
public record PlusNode(AstNode Child) : AstNode
{
    /// <inheritdoc />
    public override double Evaluate()
    {
        return Child.Evaluate();
    }
}

/// <summary>
///     Unary negative factor
/// </summary>
/// <param name="Child"></param>
public record MinusNode(AstNode Child) : AstNode
{
    /// <inheritdoc />
    public override double Evaluate()
    {
        return -Child.Evaluate();
    }
}