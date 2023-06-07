

namespace Breakout.Factories;

/// <summary>
/// Defines a factory that can parse input data and create instances of a model object of 
/// type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of the model object that this factory can create.</typeparam>
public interface IModelFactory<out T> {
    /// <summary>
    /// Parses the input data string and returns a new instance of the model object of type 
    /// <typeparamref name="T"/> with the parsed data.
    /// </summary>
    /// <param name="string">The input data string to parse.</param>
    /// <returns>A new instance of the model object of type <typeparamref name="T"/> 
    /// with the parsed data.</returns>
    T Parse (string @string);
}